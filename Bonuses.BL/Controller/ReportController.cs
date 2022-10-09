using Bonuses.BL.Model;
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

		public ReportController()
		{
			Report = GetPath();
		}

		public Report Report { get; }

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

		//public string StartBonusesReport(Table<Bonus> table, Group group, bool cancel)
		//{
		//	string message = "";

		//	if (cancel == true)
		//	{
		//		message = "cancel";

		//		//TODO: Событие вызова сообщений ShowMessage(string message);

		//		return message;
		//	}

		//	try
		//	{
		//		_app = new Word.Application() { Visible = true };
		//		_doc = _app.Documents.Open(Report.Path, false, true);
		//	}
		//	catch
		//	{
		//		return "Не удалось открыть файл.";
		//	}

		//	var date = new Date();
		//	Month month = date.TodayMonth;

		//	ReplaceDate(month);

		//	int columnCount = table.Headers.Length;
		//	int rowCount = table.Rows.Count + 1;
		//	CreateTable(rowCount, columnCount);
		//	PasteBonuses(_doc.Tables[1], bonusController);

		//	// TODO: Добавить папку для сохранения.
		//	_doc.Save($"О показателях {group.Name} {month.Name.ToUpper()} {DateTime.Now.Year}г.docx");

		//	try
		//	{
		//		_doc.Close();
		//		_app.Quit();
		//	}
		//	catch { }

		//	return "Успешно.";
		//}

		//private void ReplaceDate(Month month)
		//{
		//	string findText = "<!DocDate>";
		//	string replacementText = $"от  \"  {DateTime.Now.Day}  \" {month.NameOf} {DateTime.Now.Year} года";
		//	SearchReplace(findText, replacementText, Word.WdReplace.WdReplaceOne);

		//	findText = "<!DescriptionMonth>";
		//	replacementText = $"за {month.Name.ToLowerCase} месяц {DateTime.Now.Year} г";
		//	SearchReplace(findText, replacementText, Word.WdReplace.WdReplaceOne);

		//	findText = "<!HeaderMonth>";
		//	replacementText = $"за  {month.Name} {DateTime.Now.Year} года";
		//	SearchReplace(findText, replacementText, Word.WdReplace.WdReplaceOne);
		//}

		//private Word.Find SearchReplace(string findText, string replacementText, Word.WdReplace replace)
		//{
		//	Word.Find findObject = Application.Selection.Find;
		//	findObject.ClearFormatting();
		//	findObject.Text = findText;
		//	findObject.Replacement.ClearFormatting();
		//	findObject.Replacement.Text = replacementText;

		//	//object replaceOne = Word.WdReplace.wdReplaceOne;

		//	findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
		//ref missing, ref missing, ref missing, ref missing, ref missing,
		//ref replace, ref missing, ref missing, ref missing, ref missing);

		//	return findObject;
		//}

		////private void CreateTable(int rowCount, int columnCount);
		////{
		////	// подсчитать координаты таблицы.
		////	string findText = "<!Table>";
		////	string replacementText = "";
		////	Word.Range tableLocation = SearchReplace(findText, replacementText, Word.WdReplace.WdReplaceOne); // 1
		////	//Word.Find location = SearchReplace(findText, replacementText, Word.WdReplace.WdReplaceOne); // 2
		////	//Word.Range tableLocation = this.Range(location.End, location.End); // 2
			
		////	//Word.Range tableLocation = this.Range(ref start, ref end); // возможно оставить.
		////	this.Tables.Add(tableLocation, rowCount, columnCount);
		////	Word.Table table = this.Tables[1];
		////	table.Range.Font.Size = 10.5;
		////	table.Columns.DistributeWidth(); 	
		////}

		//private void PasteBonuses(Word.Table table, BonusController bonusController)
		//{
		//	for (int i = 1; i <= table.ColumnCount; i++)
		//	{
		//		table.Cell(1, i).Range.Text = bonusController.Headers[i - 1];
		//	}

		//	for (int i = 2; i <= table.RowCount; i++)
		//	{
		//		table.Cell(i, 1).Range.Text = i;
		//		table.Cell(i, 2).Range.Text = bonusController.Bonuses[i - 2].Employee.Name;
		//		table.Cell(i, 3).Range.Text = bonusController.Bonuses[i - 2].Employee.Position.Name;
		//		table.Cell(i, 4).Range.Text = bonusController.Bonuses[i - 2].Detection.Description;
		//		table.Cell(i, 5).Range.Text = bonusController.Bonuses[i - 2].Count;
		//	}

		//	table.Rows[1].Range.Font.Style = Bold;
		//}

		private void Save()
		{
			Save(new List<Report>() { Report });
		}

	}
}
