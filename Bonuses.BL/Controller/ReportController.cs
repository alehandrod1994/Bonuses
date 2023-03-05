using Bonuses.BL.Model;
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
		private Word.Range _position;

		private Status _status = Status.Start;

		private bool _isWorking = false;

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
		/// Проверяет расширение файла на соответствие документу Word, чтобы импортировать файл "О показателях" с помощью функции Drag&Drop.
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
			_isWorking = true;

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
				return false;
			}
		}

		/// <summary>
		/// Закрывает подключение к документу.
		/// </summary>
		/// <returns> True, если закрытие подключения прошло успешно; в противном случае - false. </returns>
		private bool CloseConnection()
		{
			_isWorking = false;

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
				return false;
			}
		}

		/// <summary>
		/// Начинает оформление отчёта по премированию.
		/// </summary>
		/// <param name="bonuses"> Список премий. </param>
		/// <param name="group"> Отдел. </param>
		/// <param name="date"> Дата. </param>
		/// <param name="progress"> Прогресс выполнения. </param>
		/// <returns> Статус выполнения. </returns>
		public Status StartBonusesReport(KpiController kpiController, Group group, Date date, IProgress<int> progress)
		{			
			if (!OpenConnection())
			{
				_isWorking = false;
				return _status;
			}

			SetDate(date);

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

			var bonuses = kpiController.Bonuses;
			var kpiPath = kpiController.Kpi.Path;

			if (!PasteBonuses(bonuses, progress))
			{
				CloseConnection();
				return _status;
			}

			string directory = Directory.GetParent(kpiPath).FullName;
			string newFileName = $"О показателях {group.Name} {date.SelectedMonth.Name.ToUpper()} {DateTime.Now.Year}г.docx";
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
		/// Останавливает подсчёт.
		/// </summary>
		public void StopCalculate()
		{
			_isWorking = false;
		}

		/// <summary>
		/// Прописывает все даты в документе.
		/// </summary>
		private void SetDate(Date date)
		{
			var todayMonth = date.GetTodayMonth();
			var todayYear = DateTime.Today.Year;

			object findText = "[!DocDate]";
			object replacementText = $"от  \"{DateTime.Now.Day}\" {todayMonth.OfName.ToLower()} {todayYear} года";
			_position = SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);

			findText = "[!DescriptionMonth]";
			replacementText = $"за {date.SelectedMonth.Name.ToLower()} месяц {date.SelectedYear} г";
			_position = SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);

			findText = "[!HeaderMonth]";
			replacementText = $"за  {date.SelectedMonth.Name} {date.SelectedYear} года";
			_position = SearchReplace(findText, replacementText, Word.WdReplace.wdReplaceOne);
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
			_position.InsertParagraphAfter();
			_position.InsertParagraphAfter();
			_position.SetRange(_position.End, _position.End);

			_doc.Tables.Add(_position, 2, headers.Length);
			Word.Table table = _doc.Tables[1];
			table.Borders.Enable = 1;			
			table.Range.Font.Size = 10.5f;

			for (int i = 1; i <= table.Columns.Count; i++)
			{
				table.Cell(1, i).Range.Text = headers[i - 1];
			}			
		}

		/// <summary>
		/// Форматирует таблицу.
		/// </summary>
		/// <param name="headers"> Заголовки. </param>
		private void FormatTable()
		{
			Word.Table table = _doc.Tables[1];

			int[] columnsWidth = new int[] { 27, 92, 106, 151, 117 };
			for (int i = 1; i <= table.Columns.Count; i++)
			{
				table.Columns[i].PreferredWidth = columnsWidth[i - 1];
			}			

			table.Rows.Height = 60;
			table.Rows[1].Height = 45;

			table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
			for (int i = 1; i <= table.Rows.Count; i++)
			{
				table.Rows[i].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;				
			}		

			table.Rows[1].Range.Bold = 1;		
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

			for (int i = 0; i < bonuses.Count; i++)
			{
				if (!_isWorking)
				{
					_status = Status.Stop;
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
			FormatTable();

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
