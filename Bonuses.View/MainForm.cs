using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group = Bonuses.BL.Model.Group;

namespace Bonuses.View
{
	public partial class MainForm : Form
	{
		private bool _cancel = false;

		private Date _date;

		private Logger _logger;

		private EmployeeController _employeeController;
		private DetectionController _detectionController;
		private KpiController _kpiController;
		private ReportController _reportController;
		private GroupController _groupController;
		private BonusController _bonusController;
		private PositionController _positionController;

		private Button _selectedButton;

		public MainForm()
		{
			InitializeComponent();

			_logger = LogManager.GetCurrentClassLogger();

			tableEmployees.Columns.Add("Name", "Имя");
			tableEmployees.Columns.Add("Position", "Должность");
			tableDetections.Columns.Add("Name", "Название");
			tableDetections.Columns.Add("Description", "Описание");

			_date = new Date();

			_employeeController = new EmployeeController();
			_detectionController = new DetectionController();
			_kpiController = new KpiController();
			_reportController = new ReportController();
			_groupController = new GroupController();
			_bonusController = new BonusController();
			_positionController = new PositionController(_employeeController.Employees);

			_groupController.OnNameChanged += Group_OnNameChanged;
			_kpiController.OnNewEmployeeFinded += Kpi_OnNewEmployeeFinded;
			_kpiController.ShutdownCalculate += ShutdownCalculate;
			_reportController.ShutdownCalculate += ShutdownCalculate;
			_employeeController.OnNewEmployeeAdded += Employee_OnNewEmployeeAdded;

			if (_groupController.Group.Name == null)
			{
				AddGroupForm addGroupForm = new AddGroupForm(_groupController);
				addGroupForm.ShowDialog();
			}
			else
			{
				labelGroup.Text = _groupController.Group.Name;
			}

			PutOnButtonSelect(btnMain);

			AutoImportDate();
			AutoImportDocuments();

		}

		private void AutoImportDate()
		{
			cbMonth.Text = _date.TodayMonth.Name;
			tbYear.Text = _date.Year.ToString();
		}

		private void AutoImportDocuments()
		{
			string currentDisk = Directory.Exists(@"Z:\PUBLIC_VS3\") ? @"Z:\PUBLIC_VS3\" : @"U:\PUBLIC_VS3\";

			try
			{
				listBoxFiles.Items[1] = _kpiController.AutoImport(currentDisk, "KPI", _date.TodayMonth.Name, "KPI");
			}
			catch { }

			try
			{
				listBoxFiles.Items[4] = _reportController.AutoImport(currentDisk, "KPI", _date.TodayMonth.Name, "ПОКАЗ");
			}
			catch { }
		}

		private int ParseInt(string value)
		{
			if (int.TryParse(value, out int result))
			{
				return result;
			}

			return default;
		}

		private bool CheckErrors()
		{
			string errorDescription = "";

			if (ParseInt(tbYear.Text) < 2000)
			{
				ShowNoticeForm("Неверно задана дата", 27, "");
				return false;
			}

			if (_kpiController.Kpi.Path == "") errorDescription += "KPI\n";
			if (_reportController.Report.Path == "") errorDescription += "О показателях\n";

			if (errorDescription != "")
			{
				ShowNoticeForm("Не загружены файлы:", 27, errorDescription);
				return false;
			}

			return true;
		}

		private void ListBoxFiles_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
				e.Effect = DragDropEffects.All;
		}

		private void ListBoxFiles_DragDrop(object sender, DragEventArgs e)
		{
			var date = new Date();

			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			foreach (string file in files)
			{
				listBoxFiles.Items[1] = _kpiController.DragDrop("KPI", date.Months, file, listBoxFiles.Items[1].ToString());
				listBoxFiles.Items[4] = _reportController.DragDrop("ПОКАЗ", file, listBoxFiles.Items[4].ToString());
			}
		}

		private void OpenTab(Button button, Panel tab)
		{
			tab.BringToFront();
			tab.Show();
				 
			PutOffButtonSelect(_selectedButton);
			PutOnButtonSelect(button);
		}

		private void PutOnButtonSelect(Button button)
		{
			button.BackColor = Color.White;
			button.ForeColor = Color.Navy;
			_selectedButton = button;
		}

		private void PutOffButtonSelect(Button button)
		{
			button.BackColor = Color.Navy;
			button.ForeColor = Color.White;
		}

		private void BtnMain_Click(object sender, EventArgs e)
		{
			OpenTab(btnMain, panelMain);
		}

		private void BtnEmployees_Click(object sender, EventArgs e)
		{
			InsertEmployeesData();
			OpenTab(btnEmployees, panelEmployees);
		}

		private void BtnDetections_Click(object sender, EventArgs e)
		{
			InsertDetectionsData();
			OpenTab(btnDetections, panelDetections);
		}

		private void BtnCalculate_Click(object sender, EventArgs e)
		{
		//	//вставить async

			if (!CheckErrors()) return;

			CalculateStart();

			_cancel = false;

			_date.TodayMonth = _date.Months[cbMonth.SelectedIndex];
			_date.Year = Convert.ToInt32(tbYear.Text);

			//	// TODO: Начало анимации прогресса.	

			//	// TODO: Прогресс KPI.
			//Table<Bonus> table = await Task.Run(() => _kpiController.CalculateBonuses(_employeeController.Employees, _detectionController.Detections));
			Table<Bonus> table = _kpiController.CalculateBonuses(_employeeController.Employees, _detectionController.Detections, _cancel);
				// TODO: Отработка ситуации, если появился новый сотрудник.	
				if (table == null) return;

			//	// TODO: Прогресс Report.
			//	//progressBar1.Location.X = 400;
			//	string newPath = await Task.Run(() => _reportController.StartBonusesReport(_groupController.Group));
				string newPath = _reportController.StartBonusesReport(table, _groupController.Group, _date, _cancel);
				if (newPath == null) return;




			//	// TODO: Конец анимации прогресса.	
			//	CalculateStop();

			//	// TODO: Уведомление об успешном завершении подсчёта.	
			//	ShowSuccessfullyForm(newPath);
		}

		private void CalculateStart()
		{
			//progressBar.Start();
			progressBar1.Visible = true;

			btnCancel.Visible = true;
			btnCalculate.Visible = false;

			// TODO: Начало анимации.
			//progressBar1.Location.X = 200;
			progressBar1.Visible = true;
		}

		private void CalculateStop()
		{
			//progressBar.Stop();
			progressBar1.Visible = false;

			btnCalculate.Visible = true;
			btnCancel.Visible = false;

			// TODO: Конец анимации.
		}

		private bool CheckCalculateErrors(string result)
		{
			if (result != "Успешно.")
			{
				CalculateStop();
				ShowNoticeForm(result, 67, "");
				return false;
			}

			return true;
		}

		private void ShutdownCalculate(object sender, EventArgs e)
		{
			//if (sender is dictItem)
			//{
			//    CalculateStop();
			//    if (sender.Key == Status.Failed)
			//    {
			//        ShowNoticeForm(sender.Value, 67, "");
			//    }
			//}
		}

		private void ShowNoticeForm(string noticeTitle, int noticeTitleHeight, string noticeDescription)
		{
			NoticeForm noticeForm = new NoticeForm(noticeTitle, noticeTitleHeight, noticeDescription);
			noticeForm.Show();
		}

		private void ShowSuccessfullyForm(string newPath)
		{
			SuccessfullyForm successfullyForm = new SuccessfullyForm(newPath);
			successfullyForm.Show();
		}

		private void Group_OnNameChanged(object sender, EventArgs e)
		{
			if (sender is Group group)
			{
				labelGroup.Text = group.Name;
			}
		}

		private void Kpi_OnNewEmployeeFinded(object sender, EventArgs e)
		{
			if (sender is string employeeName)
			{
				AddNewEmployeeForm addNewEmployeeForm = new AddNewEmployeeForm(employeeName, _employeeController, _positionController, _kpiController);
				addNewEmployeeForm.Show();
			}
		}

		private void Employee_OnNewEmployeeAdded(object sender, EventArgs e)
		{
			BtnCalculate_Click(sender, e);
		}

		private void LabelGroup_DoubleClick(object sender, EventArgs e)
		{
			//вставить на форме btnChangeGroup_OnClick;
			BtnChangeGroup_Click(sender, e);
		}

		private void BtnChangeGroup_Click(object sender, EventArgs e)
		{
			tbGroup.Text = "";
			panelGroup.Visible = true;
		}

		private void BtnApplyGroup_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(tbGroup.Text))
			{
				_groupController.Change(new Group(tbGroup.Text));
				panelGroup.Visible = false;
			}
		}

		private void BtnCancelGroup_Click(object sender, EventArgs e)
		{
			panelGroup.Visible = false;
		}

		private void FormatTable(DataGridView table)
		{
			for (int i = 0; i < table.RowCount - 1; i++)
			{
				string column1 = table.Rows[i].Cells[0].Value.ToString();
				string column2 = table.Rows[i].Cells[1].Value.ToString();

				if (string.IsNullOrWhiteSpace(column1) && string.IsNullOrWhiteSpace(column2))
				{
					table.Rows.RemoveAt(i);
					i--;
					continue;
				}
				else if (string.IsNullOrWhiteSpace(column1) || string.IsNullOrWhiteSpace(column2))
				{
					ShowNoticeForm("Не удалось сохранить", 27, $"Одно из полей не заполнено:\n Строчка: {i + 1}");
					return;
				}

				table.Rows[i].Cells[0].Value = Regex.Replace(column1, @"\s+", " ");
				table.Rows[i].Cells[1].Value = Regex.Replace(column2, @"\s+", " ");
			}
		}

		private void BtnSaveEmployees_Click(object sender, EventArgs e)
		{
			FormatTable(tableEmployees);

			var employees = new List<Employee>();
			for (int i = 0; i < tableEmployees.RowCount - 1; i++)
			{
				var position = new Position(tableEmployees.Rows[i].Cells[1].Value.ToString());
				var employee = new Employee(tableEmployees.Rows[i].Cells[0].Value.ToString(), position);
				employees.Add(employee);

			}

			_employeeController.ReWrite(employees);
			_positionController.ReWrite(employees);

			//bool result = _employeeController.ReWrite(employees);
			//if (result == true)
			//{
			//	_positionController.ReWrite(employees);
			//	ShowNoticeForm("Сохранено!", 67, "");
			//}

		}

		private void BtnCancelEmployees_Click(object sender, EventArgs e)
		{
			InsertEmployeesData();
		}

		private void BtnSaveDetections_Click(object sender, EventArgs e)
		{
			FormatTable(tableDetections);

			var detections = new List<Detection>();
			for (int i = 0; i < tableDetections.RowCount - 1; i++)
			{
				var name = tableDetections.Rows[i].Cells[0].Value.ToString();
				var description = tableDetections.Rows[i].Cells[1].Value.ToString();
				detections.Add(new Detection(name, description));
			}

			_detectionController.ReWrite(detections);

			//bool result = _detectionController.ReWrite(detections);
			//if (result == true)
			//{
			//	ShowNoticeForm("Сохранено!", 67, "");
			//}
		}

		private void BtnCancelDetections_Click(object sender, EventArgs e)
		{
			InsertDetectionsData();
		}

		private void InsertEmployeesData()
		{
			tableEmployees.Rows.Clear();
			tableEmployees.RowCount = _employeeController.Employees.Count + 1;
			for (int i = 0; i < _employeeController.Employees.Count; i++)
			{
				tableEmployees.Rows[i].Cells[0].Value = _employeeController.Employees[i].Name;
				tableEmployees.Rows[i].Cells[1].Value = _employeeController.Employees[i].Position.Name;
			}
		}

		private void InsertDetectionsData()
		{
			tableDetections.Rows.Clear();
			tableDetections.RowCount = _detectionController.Detections.Count + 1;
			for (int i = 0; i < _detectionController.Detections.Count; i++)
			{
				tableDetections.Rows[i].Cells[0].Value = _detectionController.Detections[i].Name;
				tableDetections.Rows[i].Cells[1].Value = _detectionController.Detections[i].Description;
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			_cancel = true;
		}

		
	}
}
