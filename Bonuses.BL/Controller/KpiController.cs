using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Bonuses.BL.Controller
{
	/// <summary>
	/// Контроллер документа "KPI".
	/// </summary>
	public class KpiController : DocumentController
	{
		private Excel.Application _app;
		private Excel.Workbook _book;
		private Excel.Worksheet _sheet;

		private Status _status = Status.Start;

		private int _currentRow = 2;
		private int _employeeIndex;
		private Dictionary<int, Detection> _detectionColumnIndexes;
		private bool _isWorking = false;

		/// <summary>
		/// Создаёт новый контроллер документа "KPI".
		/// </summary>
		public KpiController()
		{
			Kpi = GetKpi();
		}

		/// <summary>
		/// Документ "KPI".
		/// </summary>
		public Kpi Kpi { get; private set; }

		/// <summary>
		/// Список премий.
		/// </summary>
		public List<Bonus> Bonuses { get; private set; }

		/// <summary>
		/// Возвращает документ "KPI".
		/// </summary>
		/// <returns> Документ "KPI". </returns>
		private Kpi GetKpi()
		{
			List<Kpi> kpis = Load<Kpi>();
			return kpis.Count > 0 ? kpis.First() : new Kpi();
		}

		/// <summary>
		/// Автоматически импортирует файл "KPI".
		/// </summary>
		/// <param name="keyFolder"> Ключевая фраза в названии папки для поиска. </param>
		/// <param name="month"> Месяц. </param>
		/// <param name="keyFile"> Ключевая фраза в названии файла для поиска. </param>
		/// <returns> Название файла. </returns>
		public string AutoImportKpi(string keyFolder, string month, string keyFile)
		{
			try
			{
				string path = AutoImport(Kpi.SourceDirectory, keyFolder, month, keyFile, Kpi.Extention);
				Kpi = new Kpi(path, Kpi.SourceDirectory);
			}
			catch { }

			return Kpi.FileName;
		}

		/// <summary>
		/// Импортирует файл "KPI".
		/// </summary>
		/// <returns> Название файла. </returns>
		public string Import()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.FileName = "";
			ofd.Filter = "Документ Excel (*.xls; *xlsx) | *.xls; *.xlsx";
			ofd.Title = "Выберите файл \"KPI\"";

			if (ofd.ShowDialog() != DialogResult.Cancel)
			{
				try
				{
					Kpi.Path = ofd.FileName;
					Kpi.FileName = ofd.SafeFileName;
				}
				catch
				{
					MessageBox.Show("Недопустимый формат файла");
				}
			}

			return Kpi.FileName;
		}

		/// <summary>
		/// Проверяет расширение файла на соответствие документу Excel, чтобы импортировать файл "KPI" с помощью функции Drag&Drop.
		/// </summary>
		/// <param name="path"> Полный путь файла. </param>
		/// <returns> Название файла. </returns>
		public string DragDrop(string path)
		{
			var fi = new FileInfo(path);

			if (fi.Extension.Contains(".xls"))
			{
				Kpi.Path = path;
				Kpi.FileName = fi.Name;
			}

			return Kpi.FileName;
		}

		/// <summary>
		/// Открывает подключение к документу.
		/// </summary>
		/// <returns> True, если подключение прошло успешно; в противном случае - false. </returns>
		private bool OpenConnection()
		{
			_isWorking = true;

			_app = new Excel.Application();
			_book = null;
			try
			{
				_book = _app.Workbooks.Open(Kpi.Path);
			}
			catch
			{
				_status = Status.Failed;
				return false;
			}
			_sheet = null;
			_app.DisplayAlerts = false;
			_sheet = (Excel.Worksheet)_book.Sheets[1];
			return true;
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
				_book.Close();
				_app.Quit();
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Начинает подсчёт премирования.
		/// </summary>
		/// <param name="employeeController"> Контроллер сотрудника. </param>
		/// <param name="detections"> Список нарушений. </param>
		/// <param name="status"> Статус подсчёта. </param>
		/// <param name="progress"> Прогресс выполнения подсчёта. </param>
		/// <returns> Статус выполнения подсчёта. </returns>
		public Status StartCalculateBonuses(EmployeeController employeeController, List<Detection> detections, Status status, IProgress<int> progress)
		{
			_status = status;			

			if (!OpenConnection())
			{
				_isWorking = false;
				return _status;
			}

			if (_status != Status.NewEmployeeFound && !SetBonusesSourceData(detections))
			{				
				_status = Status.UnknownData;
				CloseConnection();
				return _status;
			}

			if (!CalculateBonuses(employeeController, progress))
			{				
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
		/// Подсчитывает премирования.
		/// </summary>
		/// <param name="employeeController"> Контроллер сотрудника. </param>
		/// <param name="progress"> Прогресс выполнения подсчёта. </param>
		/// <returns> True, если подсчёт прошёл успешно; в противном случае - false. </returns>
		private bool CalculateBonuses(EmployeeController employeeController, IProgress<int> progress)
		{
			int linesCount = 20;

			while (!Contains(_currentRow, _employeeIndex, "ИТОГО"))
			{
				if (!_isWorking)
				{
					_status = Status.Stop;
					return false;
				}

				foreach (var detectionColumnIndex in _detectionColumnIndexes)
				{
					int columnIndex = detectionColumnIndex.Key;
					if (ParseInt(ToString(_currentRow, columnIndex)) > 0)
					{
						string employeeName = ToString(_currentRow, _employeeIndex);
						if (string.IsNullOrWhiteSpace(employeeName))
						{
							continue;
						}

						if (employeeController.TryGetEmployee(employeeName, out Employee employee))
						{
							var detection = _detectionColumnIndexes[columnIndex];
							int count = ParseInt(ToString(_currentRow, columnIndex));
							var bonus = new Bonus(employee, detection, count);
							Bonuses.Add(bonus);						
						}
						else
						{
							employeeController.NewEmployee = employeeName;							
							_status = Status.NewEmployeeFound;
							return false;
						}						
					}
				}

				progress.Report(CalculateProgress(_currentRow, linesCount));
				_currentRow++;
			}

			return true;
		}

		/// <summary>
		/// Рассчитывает прогресс выполнения подсчёта. 
		/// </summary>
		/// <param name="currentIndex"> Текущее значение. </param>
		/// <param name="maxCount"> Максимальное значение. </param>
		/// <returns> Процент выполнения подсчёта. </returns>
		private int CalculateProgress(int currentIndex, int maxCount)
		{
			return currentIndex * 100 / maxCount;
		}

		/// <summary>
		/// Устанавливает начальные данные для подсчёта премирования.
		/// </summary>
		/// <param name="detections"> Список нарушений. </param>
		/// <returns> True, если процедура прошла успешно; в противном случае - false. </returns>
		private bool SetBonusesSourceData(List<Detection> detections)
		{			
			Bonuses = new List<Bonus>();

			_employeeIndex = GetEmployeeColumnIndex();
			_detectionColumnIndexes = GetDetectionColumnIndexes(detections);

			if (_employeeIndex < 1 || _detectionColumnIndexes.Count < 1)
			{
				return false;
			}

			_currentRow = 2;
			_status = Status.Start;
			return true;
		}

		/// <summary>
		/// Возвращает индекс столбца с фамилиями сотрудников.
		/// </summary>
		/// <returns> Индекс столбца. </returns>
		private int GetEmployeeColumnIndex()
		{
			for (int j = 1; j < 20; j++)
			{
				if (Contains(1, j, "ФИО") || Contains(1, j, "Ф.И.О"))
				{
					return j;
				}
			}

			return 2;
		}

		/// <summary>
		/// Преобразует текст в целое число.
		/// </summary>
		/// <param name="value"> Текст. </param>
		/// <returns> True, если преобразование прошло успешно; в противном случае - false. </returns>
		private int ParseInt(string value)
		{
			if (int.TryParse(value, out int result))
			{
				return result;
			}

			return default;
		}

		/// <summary>
		/// Возвращает индексы столбцов с нарушениями.
		/// </summary>
		/// <param name="detections"> Список нарушений. </param>
		/// <returns> Индексы столбцов с нарушениями. </returns>
		private Dictionary<int, Detection> GetDetectionColumnIndexes(List<Detection> detections)
		{
			var detectionColumnIndexes = new Dictionary<int, Detection>();
			for (int j = 1; j < 20; j++)
			{
				if (ToString(1, j) != "")
				{
					var detection = detections.FirstOrDefault(d => Equals(1, j, d.Name));
					if (detection != null)
					{
						detectionColumnIndexes.Add(j, detection);
					}
				}
			}

			return detectionColumnIndexes;
		}

		/// <summary>
		/// Проверяет, равны ли значение в ячейке Excel и введённое значение.
		/// </summary>
		/// <param name="i"> Номер строки. </param>
		/// <param name="j"> Номер столбца. </param>
		/// <param name="value"> Текст. </param>
		/// <returns> Возвращает true, если равны; в противном случае - false. </returns>
		private bool Equals(int i, int j, string value)
		{
			return ToString(i, j).Equals(value, StringComparison.CurrentCultureIgnoreCase);
		}

		/// <summary>
		/// Проверяет, содержит ли ячейка Excel введённую подстроку. 
		/// </summary>
		/// <param name="i"> Номер строки. </param>
		/// <param name="j"> Номер столбца. </param>
		/// <param name="value"> Текст. </param>
		/// <returns> Возвращает true, если содержит; в противном случае - false. </returns>
		private bool Contains(int i, int j, string value)
		{
			return ToString(i, j).ToUpper().Contains(value);
		}

		/// <summary>
		/// Приводит значение из ячейки Excel к строке.
		/// </summary>
		/// <param name="i"> Номер строки. </param>
		/// <param name="j"> Номер столбца. </param>
		/// <returns> Результат приведения. </returns>
		private string ToString(int i, int j)
		{
			Excel.Range rng = (Excel.Range)_sheet.Cells[i, j];
			return rng.Value?.ToString() ?? "";
		}

		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		private void Save()
		{
			Save(new List<Kpi>() { Kpi });
		}

		/// <summary>
		/// Сохраняет данные.
		/// </summary>
		/// <param name="kpi"> Файл "KPI". </param>
		public void Save(Kpi kpi)
		{
			Save(new List<Kpi>() { kpi });
		}
	}
}
