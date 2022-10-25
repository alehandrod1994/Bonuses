using Bonuses.BL.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Bonuses.BL.Controller
{
	public class KpiController : ControllerBase
	{
		private Excel.Application _app;
		private Excel.Workbook _book;
		private Excel.Worksheet _sheet;

		private Status _status = Status.Start;
		private Dictionary<Status, string> _messages = new Dictionary<Status, string>();
		private Logger _logger = LogManager.GetCurrentClassLogger();

		private List<Bonus> _bonuses;

		private int _currentRow = 2;
		private int _employeeIndex;
		private Dictionary<int, Detection> _detectionColumnIndexes;

		public KpiController()
		{
			_messages.Add(Status.Cancel, "Отмена.");
			_messages.Add(Status.Failed, "Не удалось открыть файл \"KPI\". Возможно, он сейчас используется.");
			_messages.Add(Status.Pause, "Остановлено.");
			_messages.Add(Status.Start, "Начало подсчёта.");
			_messages.Add(Status.Success, "Успешно.");	

			Kpi = GetKpi();
		}

		public Kpi Kpi { get; }

		public event EventHandler OnNewEmployeeFinded;
		public event EventHandler ShutdownCalculate;

		public Kpi GetKpi()
		{
			List<Kpi> kpis = Load<Kpi>();
			return kpis.Count > 0 ? kpis.First() : new Kpi();
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
				if ((files.Name.ToUpper().Contains(keyFile) || files.Name.ToUpper().Contains(month.ToUpper()))
					&& !files.Name.ToString().Contains("$"))
				{
					Kpi.Path = sourceFolder + nextFolder + @"\" + files.Name;
					var fi = new FileInfo(Kpi.Path);
					Kpi.FileName = fi.Name;
					break;
				}
			}

			return Kpi.FileName;
		}

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

		public string DragDrop(string file)
		{
			var fi = new FileInfo(file);

			if (fi.Extension.Contains(".xls"))
			{
				Kpi.Path = file;
				Kpi.FileName = fi.Name;
				Save();
			}

			return Kpi.FileName;
		}

		private bool OpenConnection()
		{
			_app = new Excel.Application();
			_book = null;
			try
			{
				_book = _app.Workbooks.Open(Kpi.Path);
			}
			catch
			{
				_status = Status.Failed;
				_logger.Info(_messages[_status]);
				ShutdownCalculate?.Invoke(_messages[_status], null);
				return false;
			}
			_sheet = null;
			_app.DisplayAlerts = false;
			_sheet = (Excel.Worksheet)_book.Sheets[1];
			return true;
		}

		private bool CloseConnection()
		{
			try
			{
				_book.Close();
				_app.Quit();
				return true;
			}
			catch
			{
				_logger.Info("Не удалось корректно закрыть файл \"KPI\".");
				return false;
			}
		}

		public List<Bonus> CalculateBonuses(List<Employee> employees, List<Detection> detections, bool cancel)
		{
			if (cancel == true)
			{
				CancelCalculate();
				return null;
			}

			if (!OpenConnection()) return null;

			if (_status != Status.Pause)
			{
				SetBonusesSourceData(detections);
			}

			while (!Contains(_currentRow, _employeeIndex, "ИТОГО") && ToString(_currentRow, _employeeIndex) != "")
			{
				foreach (var detectionColumnIndex in _detectionColumnIndexes)
				{
					int columnIndex = detectionColumnIndex.Key;
					if (ParseInt(ToString(_currentRow, columnIndex)) > 0)
					{
						//string employeeName = Regex.Replace(ToString(sheet, _currentRow, _employeeIndex), @"\s+", " ");
						string employeeName = ToString(_currentRow, _employeeIndex);
						var employee = employees.FirstOrDefault(e => e.Name.Equals(employeeName, StringComparison.CurrentCultureIgnoreCase));
						if (employee == null)
						{
							CloseConnection();

							_status = Status.Pause;
							_logger.Info(_messages[_status]);
							OnNewEmployeeFinded?.Invoke(employeeName, null);
							
							return null;
						}

						var detection = _detectionColumnIndexes[columnIndex];
						int count = ParseInt(ToString(_currentRow, columnIndex));
						var bonus = new Bonus(employee, detection, count);
						_bonuses.Add(bonus);
					}
				}

				_currentRow++;
			}

			CloseConnection();

			_status = Status.Success;
			_logger.Info(_messages[_status]);
			return _bonuses;
		}

		public void CancelCalculate()
		{
			_status = Status.Cancel;
			_logger.Info(_messages[_status]);
			ShutdownCalculate?.Invoke(_messages[_status], null);
		}

		private void SetBonusesSourceData(List<Detection> detections)
		{			
			_bonuses = new List<Bonus>();

			_employeeIndex = GetEmployeeColumnIndex();
			_detectionColumnIndexes = GetDetectionColumnIndexes(detections);
			_currentRow = 2;

			_status = Status.Start;
		}

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

		private int ParseInt(string value)
		{
			if (int.TryParse(value, out int result))
			{
				return result;
			}

			return default;
		}

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

		private bool Equals(int i, int j, string value)
		{
			return ToString(i, j).Equals(value, StringComparison.CurrentCultureIgnoreCase);
		}

		private bool Contains(int i, int j, string value)
		{
			return ToString(i, j).ToUpper().Contains(value);
		}

		private string ToString(int i, int j)
		{
			Excel.Range rng = (Excel.Range)_sheet.Cells[i, j];
			return rng.Value?.ToString() ?? "";
		}

		private void Save()
		{
			Save(new List<Kpi>() { Kpi });
		}
	}
}
