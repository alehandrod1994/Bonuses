using Bonuses.BL.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Bonuses.BL.Controller
{
	public class ReportController : DocumentController
	{
		private Word.Application _app;
		private Word.Document _doc;
		private Word.Range _location;

		private Status _status = Status.Start;
		private Dictionary<Status, string> _messages;
		private Logger _logger = LogManager.GetCurrentClassLogger();

		public ReportController()
		{
			_messages = new Dictionary<Status, string>()
			{
				{ Status.Cancel, "Отмена."},
				{ Status.Failed, "Не удалось открыть файл \"О показателях (шаблон)\". Возможно, он сейчас используется."},
				{ Status.NotSave, "Не удалось сохранить."},
				{ Status.Start, "Начало подсчёта."},
				{ Status.Success, "Успешно."},
			};

			Report = GetReport();
		}

		public Report Report { get; private set; }
		public string NewFilePath { get; private set; }

		public event EventHandler ShutdownCalculate;

		private Report GetReport()
		{
			List<Report> reports = Load<Report>();
			return reports.Count > 0 ? reports.First() : new Report();
		}

		public string AutoImportReport(string keyFolder, string month, string keyFile)
		{
			try
			{
				string path = AutoImport(Report.SourceDirectory, keyFolder, month, keyFile, Report.Extention);
				Report = new Report(path, Report.SourceDirectory);
			}
			catch { }

			return Report.FileName;
		}

		public string Import()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.FileName = "";
			ofd.Filter = "Документ Word (*.doc; *docx) | *.doc; *.docx";
			ofd.Title = "Выберите файл \"О показателях (шаблон)\"";

			if (ofd.ShowDialog() != DialogResult.Cancel)
			{
				try
				{
					Report.Path = ofd.FileName;
					Report.FileName = ofd.SafeFileName;
				}
				catch
				{
					MessageBox.Show("Недопустимый формат файла");
				}
			}

			return Report.FileName;
		}

		public string DragDrop(string file)
		{
			var fi = new FileInfo(file);

			if (fi.Extension.Contains(".doc"))
			{
				Report.Path = file;
				Report.FileName = fi.Name;
			}

			return Report.FileName;
		}

		private bool OpenConnection()
		{
			try
			{
				_app = new Word.Application() { Visible = false };
				_doc = _app.Documents.Open(Report.Path, ReadOnly: false, Visible: true);
				_doc.Activate();
				return true;
			}
			catch
			{
				_status = Status.Failed;
				_logger.Info(_messages[_status]);
				//ShutdownCalculate?.Invoke(_messages[_status], null);
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

		private void CancelCalculate()
		{
			_status = Status.Cancel;
			_logger.Info(_messages[_status]);
			//ShutdownCalculate?.Invoke(_messages[_status], null);	
		}

		public Status StartBonusesReport(List<Bonus> bonuses, Group group, Date date, bool cancel, IProgress<int> progress)
		{
			if (cancel == true)
			{
				_status = Status.Cancel;
				_logger.Info(_messages[_status]);
				ShutdownCalculate?.Invoke(_messages[_status], null);
				return _status;
			}

			if (!OpenConnection())
			{
				return _status;
			}

			SetDate(date.TodayMonth);

			if (_doc.Tables.Count < 2)
			{
				var headers = new string[]
				{
					"№ п/п",
					"Ф.И.О.",
					"Должность/ структурное подразделение",
					"Наименование показателя (критерия)",
					"Количество/ средняя оценка"
				};
				CreateTable(headers);
			}
			PasteBonuses(bonuses, progress);

			string directory = Directory.GetParent(Report.Path).FullName;
			string newFileName = $"О показателях {group.Name} {date.TodayMonth.Name.ToUpper()} {DateTime.Now.Year}г.docx";
			string newFilePath = $"{directory}\\{newFileName}";

			try
			{
				_doc.SaveAs(newFilePath);
				NewFilePath = newFilePath;
			}
			catch
			{
				_status = Status.NotSave;
				_logger.Info(_messages[_status]);
				//ShutdownCalculate?.Invoke(_messages[_status], null);	
				CloseConnection();
				return _status;
			}
			
			CloseConnection();
			_status = Status.Success;
			_logger.Info(_messages[_status]);
			return _status;
		}

		private void SetDate(Month month)
		{
			object findText = "<!DocDate>";
			object replacementText = $"от  \"{DateTime.Now.Day}\" {month.OfName} {DateTime.Now.Year} года";
			_location = SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);

			findText = "<!DescriptionMonth>";
			replacementText = $"за {month.Name.ToLower()} месяц {DateTime.Now.Year} г";
			_location = SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);

			findText = "<!HeaderMonth>";
			replacementText = $"за  {month.Name} {DateTime.Now.Year} года";
			_location = SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);
		}

		private Word.Range SearchReplace(object findText, object replacementText, Word.WdReplace replace)
		{
			//Word.Range range = _app.ActiveDocument.Content;
			Word.Range range = _doc.Content;
			range.Find.ClearFormatting(); 
			range.Find.Execute(FindText: findText, ReplaceWith: replacementText, Replace: replace);

			return range;
		}

		private void CreateTable(string[] headers)
		{
			//object findText = "<!Table>";
			//object replacementText = "";
			//Word.Range tableLocation = SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);

			//int columnCount = tableData.Headers.Length;
			//int rowCount = tableData.Rows.Count + 1;

			//_doc.Tables.Add(tableLocation, rowCount, columnCount);
			//Word.Table table = _doc.Tables[1];
			//table.Borders.Enable = 1;
			//table.Columns.DistributeWidth();
			//table.Rows.Height = 60;



			//table.Range.Font.Size = 10.5f;
			//table.Range.Bold = 0;

			_location.InsertParagraphAfter();
			_location.SetRange(_location.End, _location.End);

			_doc.Tables.Add(_location, 2, headers.Length);
			Word.Table table = _doc.Tables[1];
			table.Borders.Enable = 1;			
			table.Range.Font.Size = 10.5f;

			for (int i = 1; i <= table.Columns.Count; i++)
			{
				table.Cell(1, i).Range.Text = headers[i - 1];
			}

			FormatTableWidth(headers);
		}

		private void FormatTableWidth(string[] headers)
		{
			Word.Table table = _doc.Tables[1];

			if (headers[0].Contains("№") || headers[0].Contains("Номер"))
			{
				int columnCount = headers.Length;
				float firstColumnWidth = 30;
				float tableWidth = 488;
				table.Columns[1].PreferredWidth = firstColumnWidth;
				float columnWidth = (tableWidth - firstColumnWidth) / (columnCount - 1);

				for (int i = 2; i <= table.Columns.Count; i++)
				{
					table.Columns[i].PreferredWidth = columnWidth;
				}
			}
			else
			{
				table.Columns.DistributeWidth();
			}
		}

		private void PasteBonuses(List<Bonus> bonuses, IProgress<int> progress)
		{
			Word.Table table = _doc.Tables[1];
			table.Range.Bold = 0;

			int linesCount = bonuses.Count;
			for (int i = 0; i < bonuses.Count; i++)
			{
				table.Rows.Add();

				//table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
				//table.Cell(i + 2, 2).Range.Text = bonuses[i].Employee.Name;
				//table.Cell(i + 2, 3).Range.Text = bonuses[i].Employee.Position.Name;
				//table.Cell(i + 2, 4).Range.Text = bonuses[i].Detection.Description;
				//table.Cell(i + 2, 5).Range.Text = bonuses[i].Count.ToString();

				table.Rows[i + 2].Cells[1].Range.Text = (i + 1).ToString();
				table.Rows[i + 2].Cells[2].Range.Text = bonuses[i].Employee.Name;
				table.Rows[i + 2].Cells[3].Range.Text = bonuses[i].Employee.Position.Name;
				table.Rows[i + 2].Cells[4].Range.Text = bonuses[i].Detection.Description;
				table.Rows[i + 2].Cells[5].Range.Text = bonuses[i].Count.ToString();

				progress.Report(CalculateProgress(i + 1, linesCount));
			}

			int lastRowIndex = table.Rows.Count;
			table.Rows[lastRowIndex].Delete();
		}

		private int CalculateProgress(int currentIndex, int maxCount)
		{
			return currentIndex * 100 / maxCount;
		}

		private void Save()
		{
			Save(new List<Report>() { Report });
		}

		public void Save(Report report)
		{
			Save(new List<Report>() { report });
		}
	}
}
