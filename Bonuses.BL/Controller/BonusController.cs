using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace Bonuses.BL.Controller
{
	public class BonusController
	{
		private int _currentRow = 1;

		public BonusController()
		{
			Headers = new string[]
			{
				"№ п/п",
				"Ф.И.О.",
				"Должность/структурное подразделение",
				"Наименование показателя (критерия)",
				"Количество/средняя оценка"
			};

			Bonuses = new List<Bonus>();
		}

		public string[] Headers { get; }
		public List<Bonus> Bonuses { get; }

		public event EventHandler OnNewEmployeeFinded;

		//public string Calculate(string path, List<Employee> employees, List<Detection> detections, bool cancel)
		//{
		//	if (cancel == true) return "cancel";

		//	Excel.Application app = new Excel.Application();
		//	Excel.Workbook book = null;

		//	try
		//	{
		//		book = app.Workbooks.Open(path);
		//	}
		//	catch
		//	{
		//		return "Не удалось открыть файл 'KPI'. Возможно, он сейчас используется.";
		//	}

		//	Excel.Worksheet sheet = null;
		//	app.DisplayAlerts = false;
		//	sheet = (Excel.Worksheet)book.Sheets[1];

		//	if (_currentRow == 1)
		//	{
		//		Bonuses.Clear();
		//	}

		//	var detectionColumnIndexes = GetDetectionColumnIndexes();

		//	for (int i = 1; i < ИТОГО; i++)
		//	{
		//		foreach (var detectionColumnIndex in detectionColumnIndexes)
		//		{
		//			int columnIndex = detectionColumnIndex.Key;
		//			if (cell[i, columnIndex] > 0)
		//			{
		//				string employeeName = cell[i, 1];
		//				if (!string.IsNullOrWhiteSpace(employeeName))
		//				{
		//					var employee = employees.SingleOrDefault(e => e.Name == employeeName);
		//					if (employee == null)
		//					{
		//						OnNewEmployeeFinded?.Invoke(employeeName, null);

		//						try
		//						{
		//							book.Close();
		//							app.Quit();
		//						}
		//						catch { }

		//						return "Остановлено.";
		//					}

		//					var detection = detectionColumnIndexes[columnIndex];
		//					int count = cell[i, columnIndex];
		//					var bonus = new Bonus(employee, detection, count);
		//					Bonuses.Add(bonus);
		//				}
		//			}
		//		}
		//	}

		//	try
		//	{
		//		book.Close();
		//		app.Quit();
		//	}
		//	catch { }

		//	_currentRow = 1;
		//	return "Успешно.";
		//}

		//private Dictionary<int, Detection> GetDetectionColumnIndexes()
		//{
		//	var detectionColumnIndexes = new Dictionary<int, Detection>();
		//	for (int j = 1; j < 20; j++)
		//	{
		//		if (cell[1, j] != "")
		//		{
		//			var detection = detections.SingleOrDefault(d => d.Name == cell[1, j]);
		//			if (detection != null)
		//			{
		//				detectionColumnIndexes.Add(j, detection);
		//			}
		//		}
		//	}

		//	return detectionColumnIndexes;
		//}
	}
}
