using Bonuses.BL.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Bonuses.BL.Controller
{
	public class KpiController : ControllerBase
	{
		private Dictionary<Status, string> _messages = new Dictionary<Status, string>();
		private Logger _logger = LogManager.GetCurrentClassLogger();

		private Table<Bonus> _table;

		private int _currentRow = 2;

		public KpiController()
		{
			_messages.Add(Status.Cancel, "Отмена.");
			_messages.Add(Status.Failed, "Не удалось открыть файл \"KPI\". Возможно, он сейчас используется.");
			_messages.Add(Status.Pause, "Остановлено.");
			_messages.Add(Status.Success, "Успешно.");	

			Kpi = GetPath();
		}

		public Kpi Kpi { get; }

		public event EventHandler OnNewEmployeeFinded;
		public event EventHandler ShutdownCalculate;

		public Kpi GetPath()
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
				if ((files.Name.ToString().ToUpper().Contains(keyFile) || files.Name.ToString().ToUpper().Contains(month.ToUpper()))
					&& !files.Name.ToString().Contains("$"))
				{
					Kpi.Path = sourceFolder + nextFolder + @"\" + files.Name;
					var fi = new FileInfo(Kpi.Path);
					Kpi.FileName = fi.Name;

					break;
				}
			}

			return Kpi.Path;
		}

		//public void Import();
		public string DragDrop(string key, Month[] months, string file, string fullPath)
		{
			var fi = new FileInfo(file);

			if (file.ToUpper().Contains(key))
			{					
				Kpi.Path = file;
				Kpi.FileName = fi.Name;
				fullPath = file;
			}
			else
			{
				for (int i = 0; i < months.Length; i++)
				{
					if (file.Contains(months[i].Name))
					{
						Kpi.Path = file;
						Kpi.FileName = fi.Name;
						fullPath = file;
						break;
					}
				}
			}

			Save();

			return fullPath;
		}

		public Table<Bonus> CalculateBonuses(List<Employee> employees, List<Detection> detections, bool cancel)
		{
			//string message = "";

			if (cancel == true)
			{
				//message = "cancel";

				_logger.Info(_messages[Status.Cancel]);
				ShutdownCalculate?.Invoke(_messages[Status.Cancel], null);
				return null;
			}

			Excel.Application app = new Excel.Application();
			Excel.Workbook book = null;
			try
			{
				book = app.Workbooks.Open(Kpi.Path);
			}
			catch
			{
				//message = "Не удалось открыть файл 'KPI'. Возможно, он сейчас используется.";
				_logger.Info(_messages[Status.Failed]);
				ShutdownCalculate?.Invoke(_messages[Status.Failed], null);
				return null;
			}
			Excel.Worksheet sheet = null;
			app.DisplayAlerts = false;
			sheet = (Excel.Worksheet)book.Sheets[1];

			if (_currentRow <= 2)
			{
				var headers = new string[]
				{
					"№ п/п",
					"Ф.И.О.",
					"Должность/структурное подразделение",
					"Наименование показателя (критерия)",
					"Количество/средняя оценка"
				};

				_table = new Table<Bonus>(headers);
			}

			var detectionColumnIndexes = GetDetectionColumnIndexes(sheet, detections);

			while (!Contains(sheet, _currentRow, 2, "ИТОГО") && ToString(sheet, _currentRow, 2) != "")
			{
				foreach (var detectionColumnIndex in detectionColumnIndexes)
				{
					int columnIndex = detectionColumnIndex.Key;
					if (ParseInt(ToString(sheet, _currentRow, columnIndex)) > 0)
					{
						string employeeName = ToString(sheet, _currentRow, 2);
						var employee = employees.FirstOrDefault(e => e.Name.Equals(employeeName, StringComparison.CurrentCultureIgnoreCase));
						if (employee == null)
						{
							_logger.Info(_messages[Status.Pause]);
							OnNewEmployeeFinded?.Invoke(employeeName, null);

							try
							{
								book.Close();
								app.Quit();
							}
							catch { }

							//message = "Pause";

							//TODO: Событие вызова сообщений ShowMessage(string message);

							return null;
						}

						var detection = detectionColumnIndexes[columnIndex];
						int count = ParseInt(ToString(sheet, _currentRow, columnIndex));
						var bonus = new Bonus(employee, detection, count);
						_table.Rows.Add(bonus);
					}
				}

				_currentRow++;
			}

			try
			{
				book.Close();
				app.Quit();
			}
			catch { }

			_currentRow = 2;

			//message = "Success";

			//TODO: Событие вызова сообщений ShowMessage(string message);
			_logger.Info(_messages[Status.Success]);
			return _table;
		}

		private int ParseInt(string cell)
		{
			if (int.TryParse(cell, out int result))
			{
				return result;
			}

			return default;
		}

		private Dictionary<int, Detection> GetDetectionColumnIndexes(Excel.Worksheet sheet, List<Detection> detections)
		{
			var detectionColumnIndexes = new Dictionary<int, Detection>();
			for (int j = 1; j < 20; j++)
			{
				if (ToString(sheet, 1, j) != "")
				{
					var detection = detections.FirstOrDefault(d => d.Name.ToUpper() == ToString(sheet, 1, j));
					if (detection != null)
					{
						detectionColumnIndexes.Add(j, detection);
					}
				}
			}

			return detectionColumnIndexes;
		}

		private bool Contains(Excel.Worksheet sheet, int i, int j, string key)
		{
			return ToString(sheet, i, j).Contains(key);
		}

		private string ToString(Excel.Worksheet sheet, int i, int j)
		{
			Excel.Range rng = (Excel.Range)sheet.Cells[i, j];
			return rng.Value?.ToString().ToUpper() ?? "";
		}

		private void Save()
		{
			Save(new List<Kpi>() { Kpi });
		}
	}
}
