using Bonuses.BL.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;

namespace Bonuses.BL.Controller
{
	public class ReportController : ControllerBase
	{
		private Word.Application _app;
		private Word.Document _doc;

		private Status _status = Status.Start;
		private Dictionary<Status, string> _messages = new Dictionary<Status, string>();
		private Logger _logger = LogManager.GetCurrentClassLogger();

		public ReportController()
		{
			_messages.Add(Status.Cancel, "Отмена.");
			_messages.Add(Status.Failed, "Не удалось открыть файл \"О показателях (шаблон)\". Возможно, он сейчас используется.");
			_messages.Add(Status.Pause, "Остановлено.");
			_messages.Add(Status.Start, "Начало подсчёта.");
			_messages.Add(Status.Success, "Успешно.");

			Report = GetPath();
		}

		public Report Report { get; }

		public event EventHandler ShutdownCalculate;

		public Report GetPath()
		{
			List<Report> reports = Load<Report>();
			return reports.Count > 0 ? reports.First() : new Report();
		}

		public string AutoImport(string sourceFolder, string keyFolder, string month, string keyFile)
		{
			string nextFolder = "";
			DirectoryInfo dir = new DirectoryInfo(sourceFolder);
			foreach (DirectoryInfo directory in dir.GetDirectories())
			{
				if (directory.Name.ToString().ToUpper().Contains(keyFolder) && directory.Name.ToString().ToUpper().Contains(month.ToUpper()))
				{
					nextFolder = directory.Name;

					break;
				}
			}

			dir = new DirectoryInfo(sourceFolder + nextFolder);
			foreach (FileInfo files in dir.GetFiles())
			{
				if ((files.Name.ToString().ToUpper().Contains(keyFile) || files.Name.ToString().ToUpper().Contains(month.ToUpper()))
					&& !files.Name.ToString().Contains("$"))
				{
					Report.Path = sourceFolder + nextFolder + @"\" + files.Name;
					var fi = new FileInfo(Report.Path);
					Report.FileName = fi.Name;

					break;
				}
			}

			return Report.Path;
		}

		public string DragDrop(string key, string file, string fullPath)
		{
			var fi = new FileInfo(file);

			if (file.ToUpper().Contains(key))
			{
				Report.Path = file;
				Report.FileName = fi.Name;
				fullPath = file;
			}

			Save();

			return fullPath;
		}

		private bool OpenConnection()
		{
			try
			{
				_app = new Word.Application() { Visible = true };
				_doc = _app.Documents.Open(Report.Path, ReadOnly: false, Visible: true);
				_doc.Activate();
				return true;
			}
			catch
			{
				_status = Status.Failed;
				_logger.Info(_messages[_status]);
				ShutdownCalculate?.Invoke(_messages[_status], null);
				return false;
			}
		}

		private bool CloseConnection()
		{
			try
			{
				_doc.Close();
				_app.Quit();
				return true;
			}
			catch
			{
				_logger.Info("Не удалось корректно закрыть файл \"О показателях (шаблон)\".");
				return false;
			}
		}

		public string StartBonusesReport(Table<Bonus> tableBonuses, Group group, Date date, bool cancel)
		{
			if (cancel == true)
			{
				_status = Status.Cancel;
				_logger.Info(_messages[_status]);
				ShutdownCalculate?.Invoke(_messages[_status], null);
				return null;
			}

			if (!OpenConnection()) return null;

			ReplaceDate(date.TodayMonth);		
			CreateTable(tableBonuses);
			PasteBonuses(_doc.Tables[1], tableBonuses);

			string directory = Directory.GetParent(Report.Path).FullName;
			string newFileName = $"О показателях {group.Name} {date.TodayMonth.Name.ToUpper()} {DateTime.Now.Year}г.docx";
			string newFilePath = $"{directory}\\{newFileName}";
			_doc.SaveAs(newFilePath);

			CloseConnection();

			_status = Status.Success;
			_logger.Info(_messages[_status]);
			return newFilePath;
		}

		private void ReplaceDate(Month month)
		{
			object findText = "<!DocDate>";
			object replacementText = $"от  \"{DateTime.Now.Day}\" {month.OfName} {DateTime.Now.Year} года";
			SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);

			findText = "<!DescriptionMonth>";
			replacementText = $"за {month.Name.ToLower()} месяц {DateTime.Now.Year} г";
			SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);

			findText = "<!HeaderMonth>";
			replacementText = $"за  {month.Name} {DateTime.Now.Year} года";
			SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);
		}

		private Word.Range SearchReplace(object findText, object replacementText, Word.WdReplace replace)
		{
			Word.Range range = _app.ActiveDocument.Content; 
			range.Find.ClearFormatting(); 
			range.Find.Execute(FindText: findText, ReplaceWith: replacementText, Replace: replace);

			return range;
		}

		private void CreateTable<T>(Table<T> tableData)
		{
			object findText = "<!Table>";
			object replacementText = "";
			Word.Range tableLocation = SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);
			
			int columnCount = tableData.Headers.Length;
			int rowCount = tableData.Rows.Count + 1;

			_doc.Tables.Add(tableLocation, rowCount, columnCount);
			Word.Table table = _doc.Tables[1];
			table.Borders.Enable = 1;
			table.Columns.DistributeWidth();			

			if (tableData.Headers[0].Contains("№") || tableData.Headers[0].Contains("Номер"))
			{
				float firstColumnWidth = 28;
				float tableWidth = 488;
				table.Columns[1].PreferredWidth = firstColumnWidth;
				float columnWidth = (tableWidth - firstColumnWidth) / (columnCount - 1);

				for(int i = 2; i <= table.Columns.Count; i++)
				{
					table.Columns[i].PreferredWidth = columnWidth;
				}
			}				
			
			table.Range.Font.Size = 10.5f;
			table.Range.Bold = 0;
		}

		private void PasteBonuses(Word.Table table, Table<Bonus> tableBonuses)
		{
			for (int i = 1; i <= table.Columns.Count; i++)
			{
				table.Cell(1, i).Range.Text = tableBonuses.Headers[i - 1];
			}

			for (int i = 2; i <= table.Rows.Count; i++)
			{
				table.Cell(i, 1).Range.Text = (i - 1).ToString();
				table.Cell(i, 2).Range.Text = tableBonuses.Rows[i - 2].Employee.Name;
				table.Cell(i, 3).Range.Text = tableBonuses.Rows[i - 2].Employee.Position.Name;
				table.Cell(i, 4).Range.Text = tableBonuses.Rows[i - 2].Detection.Description;
				table.Cell(i, 5).Range.Text = tableBonuses.Rows[i - 2].Count.ToString();
			}

			table.Rows[1].Range.Bold = 20;
			//table.Columns[2].Range.Font.Size = 12;
			table.Rows.DistributeHeight();
		}

		private void Save()
		{
			Save(new List<Report>() { Report });
		}

	}
}
