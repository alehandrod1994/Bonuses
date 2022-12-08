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
	/// <summary>
	/// Контроллер документа "О показателях".
	/// </summary>
	public class ReportController : DocumentController
	{
		private Word.Application _app;
		private Word.Document _doc;
		private Word.Range _location;

		private Status _status = Status.Start;
		//private Logger _logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Создаёт новый контроллер документа "О показателях".
		/// </summary>
		public ReportController()
		{
			Report = GetReport();
		}

		/// <summary>
		/// Документ "О показателях".
		/// </summary>
		public Report Report { get; private set; }

		/// <summary>
		/// Путь нового файла для сохранения.
		/// </summary>
		public string NewFilePath { get; private set; }

		/// <summary>
		/// Проверяет, не поступал ли запрос на отмену подсчёта.
		/// </summary>
		public event Func<bool> CheckCancel;

		/// <summary>
		/// Возвращает документ "О показателях".
		/// </summary>
		/// <returns> Документ "О показателях". </returns>
		private Report GetReport()
		{
			List<Report> reports = Load<Report>();
			return reports.Count > 0 ? reports.First() : new Report();
		}

		/// <summary>
		/// Автоматически импортирует файл "О показателях".
		/// </summary>
		/// <param name="keyFolder"> Ключевая фраза в названии папки для поиска. </param>
		/// <param name="month"> Месяц. </param>
		/// <param name="keyFile"> Ключевая фраза в названии файла для поиска. </param>
		/// <returns> Название файла. </returns>
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

		/// <summary>
		/// Импортирует файл "О показателях".
		/// </summary>
		/// <returns> Название файла. </returns>
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

		/// <summary>
		/// Проверяет расширение файла на соответствие документу Word, чтобы импортирует файл "О показателях" с помощью функции Drag&Drop.
		/// </summary>
		/// <param name="path"> Полный путь файла. </param>
		/// <returns> Название файла. </returns>
		public string DragDrop(string path)
		{
			var fi = new FileInfo(path);

			if (fi.Extension.Contains(".doc"))
			{
				Report.Path = path;
				Report.FileName = fi.Name;
			}

			return Report.FileName;
		}

		/// <summary>
		/// Открывает подключение к документу.
		/// </summary>
		/// <returns> True, если подключение прошло успешно; в противном случае - false. </returns>
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
				//ShutdownCalculate?.Invoke(_messages[_status], null);
				return false;
			}
		}

		/// <summary>
		/// Закрывает подключение к документу.
		/// </summary>
		/// <returns> True, если закрытие подключения прошло успешно; в противном случае - false. </returns>
		private bool CloseConnection()
		{
			try
			{
				object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
				object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
				object routeDocument = false;
				_doc.Close(ref saveOption, ref originalFormat, ref routeDocument);
				_app.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
				_app.Quit();
				_doc = null;
				_app = null;
				return true;
			}
			catch
			{
				//_logger.Info("Не удалось корректно закрыть файл \"О показателях (шаблон)\".");
				return false;
			}
		}

		/// <summary>
		/// Отменяет подсчёт.
		/// </summary>
		private void CancelCalculate()
		{
			_status = Status.Cancel;
			//ShutdownCalculate?.Invoke(_messages[_status], null);	
		}

		/// <summary>
		/// Начинает оформление отчёта по премированию.
		/// </summary>
		/// <param name="bonuses"> Список премий. </param>
		/// <param name="group"> Отдел. </param>
		/// <param name="date"> Дата. </param>
		/// <param name="progress"> Прогресс выполнения. </param>
		/// <returns> Статус выполнения. </returns>
		public Status StartBonusesReport(List<Bonus> bonuses, Group group, Date date, IProgress<int> progress)
		{
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

			if (!PasteBonuses(bonuses, progress))
			{
				CloseConnection();
				return _status;
			}

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
				CloseConnection();
				return _status;
			}
			
			CloseConnection();
			_status = Status.Success;
			return _status;
		}

		/// <summary>
		/// Прописывает все даты в документе.
		/// </summary>
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

		/// <summary>
		/// Заменяет текст в документе.
		/// </summary>
		/// <param name="findText"> Текст, который нужно найти. </param>
		/// <param name="replacementText"> Текст, на который нужно заменить. </param>
		/// <param name="replace"> Параметр, указывающий, сколько вхождений нужно заменить. </param>
		/// <returns> Расположение найденного текста в документе. </returns>
		private Word.Range SearchReplace(object findText, object replacementText, Word.WdReplace replace)
		{
			//Word.Range range = _app.ActiveDocument.Content;
			Word.Range range = _doc.Content;
			range.Find.ClearFormatting(); 
			range.Find.Execute(FindText: findText, ReplaceWith: replacementText, Replace: replace);

			return range;
		}

		/// <summary>
		/// Создаёт таблицу.
		/// </summary>
		/// <param name="headers"> Заголовки. </param>
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

		/// <summary>
		/// Форматирует ширину таблицы.
		/// </summary>
		/// <param name="headers"> Заголовки. </param>
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

		/// <summary>
		/// Вставляет премии в таблицу.
		/// </summary>
		/// <param name="bonuses"> Список премий. </param>
		/// <param name="progress"> Прогресс выполнения. </param>
		/// <returns> True, если процедура прошла успешно; в противном случае - false. </returns>
		private bool PasteBonuses(List<Bonus> bonuses, IProgress<int> progress)
		{
			Word.Table table = _doc.Tables[1];

			int linesCount = bonuses.Count;

			//// Вариант: 2.2.2
			//for (int i = 0; i < bonuses.Count; i++)
			//{
			//	if (CheckCancel.Invoke())
			//	{
			//		CancelCalculate();
			//		return false;
			//	}

			//	table.Rows.Add();

			//	table.Rows[i + 2].Cells[1].Range.Text = (i + 1).ToString();
			//	table.Rows[i + 2].Cells[2].Range.Text = bonuses[i].Employee.Name;
			//	table.Rows[i + 2].Cells[3].Range.Text = bonuses[i].Employee.Position.Name;
			//	table.Rows[i + 2].Cells[4].Range.Text = bonuses[i].Detection.Description;
			//	table.Rows[i + 2].Cells[5].Range.Text = bonuses[i].Count.ToString();

			//	progress.Report(CalculateProgress(i + 1, linesCount));
			//}

			//int lastRowIndex = table.Rows.Count;
			//table.Rows[lastRowIndex].Delete();



			// Вариант: 2.2.1
			for (int i = 0; i < bonuses.Count; i++)
			{
				if (CheckCancel.Invoke())
				{
					CancelCalculate();
					return false;
				}

				table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
				table.Cell(i + 2, 2).Range.Text = bonuses[i].Employee.Name;
				table.Cell(i + 2, 3).Range.Text = bonuses[i].Employee.Position.Name;
				table.Cell(i + 2, 4).Range.Text = bonuses[i].Detection.Description;
				table.Cell(i + 2, 5).Range.Text = bonuses[i].Count.ToString();

				table.Rows.Add();

				progress.Report(CalculateProgress(i + 1, linesCount));
			}

			int lastRowIndex = table.Rows.Count;
			table.Rows[lastRowIndex].Delete();



			//// Вариант: 2.1.1
			//for (int i = 0; i < bonuses.Count; i++)
			//{
			//    if (CheckCancel.Invoke())
			//    {
			//        CancelCalculate();
			//        return false;
			//    }

			//    table.Cell(i + 2, 1).Range.Text = (i + 1).ToString();
			//    table.Cell(i + 2, 2).Range.Text = bonuses[i].Employee.Name;
			//    table.Cell(i + 2, 3).Range.Text = bonuses[i].Employee.Position.Name;
			//    table.Cell(i + 2, 4).Range.Text = bonuses[i].Detection.Description;
			//    table.Cell(i + 2, 5).Range.Text = bonuses[i].Count.ToString();

			//    if (table.Rows.Count <= bonuses.Count)
			//    {
			//        table.Rows.Add();
			//    }

			//    progress.Report(CalculateProgress(i + 1, linesCount));
			//}


			//// Вариант: 2.1.2
			//for (int i = 0; i < bonuses.Count; i++)
			//{
			//    if (CheckCancel.Invoke())
			//    {
			//        CancelCalculate();
			//        return false;
			//    }

			//    table.Rows[i + 2].Cells[1].Range.Text = (i + 1).ToString();
			//    table.Rows[i + 2].Cells[2].Range.Text = bonuses[i].Employee.Name;
			//    table.Rows[i + 2].Cells[3].Range.Text = bonuses[i].Employee.Position.Name;
			//    table.Rows[i + 2].Cells[4].Range.Text = bonuses[i].Detection.Description;
			//    table.Rows[i + 2].Cells[5].Range.Text = bonuses[i].Count.ToString();

			//    if (table.Rows.Count <= bonuses.Count)
			//    {
			//        table.Rows.Add();
			//    }

			//    progress.Report(CalculateProgress(i + 1, linesCount));
			//}


			//// Вариант: 1.1.1
			//for (int i = 2; i <= table.Rows.Count; i++)
			//{
			//	if (CheckCancel.Invoke())
			//	{
			//		CancelCalculate();
			//		return false;
			//	}

			//	table.Cell(i, 1).Range.Text = (i - 1).ToString();
			//	table.Cell(i, 2).Range.Text = bonuses[i - 2].Employee.Name;
			//	table.Cell(i, 3).Range.Text = bonuses[i - 2].Employee.Position.Name;
			//	table.Cell(i, 4).Range.Text = bonuses[i - 2].Detection.Description;
			//	table.Cell(i, 5).Range.Text = bonuses[i - 2].Count.ToString();

			//	if (table.Rows.Count <= bonuses.Count)
			//	{
			//		table.Rows.Add();
			//	}

			//	progress.Report(CalculateProgress(i - 1, linesCount));
			//}


			//// Вариант: 1.1.2
			//for (int i = 2; i <= table.Rows.Count; i++)
			//{
			//	if (CheckCancel.Invoke())
			//	{
			//		CancelCalculate();
			//		return false;
			//	}

			//	table.Rows[i].Cells[1].Range.Text = (i - 1).ToString();
			//	table.Rows[i].Cells[2].Range.Text = bonuses[i - 2].Employee.Name;
			//	table.Rows[i].Cells[3].Range.Text = bonuses[i - 2].Employee.Position.Name;
			//	table.Rows[i].Cells[4].Range.Text = bonuses[i - 2].Detection.Description;
			//	table.Rows[i].Cells[5].Range.Text = bonuses[i - 2].Count.ToString();

			//	if (table.Rows.Count <= bonuses.Count)
			//	{
			//		table.Rows.Add();
			//	}

			//	progress.Report(CalculateProgress(i - 1, linesCount));
			//}


			return true;
		}

		/// <summary>
		/// Рассчитывает прогресс оформления отчёта. 
		/// </summary>
		/// <param name="currentIndex"> Текущее значение. </param>
		/// <param name="maxCount"> Максимальное значение. </param>
		/// <returns> Процент выполнения. </returns>
		private int CalculateProgress(int currentIndex, int maxCount)
		{
			return currentIndex * 100 / maxCount;
		}

		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		private void Save()
		{
			Save(new List<Report>() { Report });
		}

		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		/// <param name="report"> Файл "О показателях". </param>
		public void Save(Report report)
		{
			Save(new List<Report>() { report });
		}
	}
}
