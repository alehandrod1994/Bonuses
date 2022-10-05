﻿using Bonuses.BL.Model;
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

		//public string CalculateBonuses(Group group, BonusController bonusController)
		//{
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
		//	Month month = date.Months[DateTime.Today.Month - 1];

		//	ReplaceDate(month);

		//	int columnCount = bonusController.Headers.Length;
		//	int rowCount = bonusController.Bonuses.Count + 1;
		//	CreateTable(rowCount, columnCount);
		//	PasteBonuses(_doc.Tables[1], bonusController);

		//	_doc.SaveAs($"О показателях {group.Name} {month.Name.ToUpper()} {DateTime.Now.Year}г.docx");

		//	try
		//	{
		//		_doc.Close();
		//		_app.Quit();
		//	}
		//	catch { }

		//	return "Успешно.";
		//}

		//public void ReplaceDate(Month month)
		//{
		//	// TODO: замена даты вверху документа.
		//	string findText = "<!DocDate>";
		//	string replacementText = $"от  \"  {DateTime.Now.Day}  \" {month.OfName} {DateTime.Now.Year} года";
		//	SearchReplace(findText, replacementText, Word.WdReplace.WdReplaceOne);

		//	// TODO: замена месяца в описании.
		//	findText = "<!DescriptionMonth>";
		//	replacementText = $"за {month.Name.ToLower()} месяц {DateTime.Now.Year} г";
		//	SearchReplace(findText, replacementText, Word.WdReplace.WdReplaceOne);

		//	// TODO: замена месяца в заголовке таблицы.
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

		//public void CreateTable(int rowCount, int columnCount)
		//{
		//	// подсчитать координаты таблицы.
		//	string findText = "<!Table>";
		//	string replacementText = "";
		//	Word.Range tableLocation = SearchReplace(findText, replacementText, Word.WdReplace.WdReplaceOne); // 1
		//	//Word.Find location = SearchReplace(findText, replacementText, Word.WdReplace.WdReplaceOne); // 2
		//	//Word.Range tableLocation = this.Range(location.End, location.End); // 2

		//	Word.Range tableLocation = this.Range(ref start, ref end); // возможно оставить.
		//	this.Tables.Add(tableLocation, 1, columnCount);
		//	Word.Table table = this.Tables[1];
		//	table.Range.Font.Size = 10.5;
		//	table.Columns.DistributeWidth();
		//}

		//public void PasteBonuses(Word.Table table, BonusController bonusController)
		//{
		//	for (int i = 1; i <= table.Columns.Count; i++)
		//	{
		//		table.Cell(1, i).Range.Text = bonusController.Headers[i - 1];
		//	}

		//	for (int i = 2; i <= table.Rows.Count; i++)
		//	{
		//		table.Cell(i, 1).Range.Text = i;
		//		table.Cell(i, 2).Range.Text = bonusController.Bonuses[i - 2].Employee.Name;
		//		table.Cell(i, 3).Range.Text = bonusController.Bonuses[i - 2].Employee.Position.Name;
		//		table.Cell(i, 4).Range.Text = bonusController.Bonuses[i - 2].Detection.Description;
		//		table.Cell(i, 5).Range.Text = bonusController.Bonuses[i - 2].Count.ToString();
		//	}

		//	table.Rows[1].Range.Font.Style = Bold;
		//}

		private void Save()
		{
			Save(new List<Report>() { Report });
		}

	}
}