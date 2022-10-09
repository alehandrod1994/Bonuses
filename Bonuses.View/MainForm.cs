using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonuses.View
{
	public partial class MainForm : Form
	{
		private bool _cancel = false;

		private Date _date;

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

			_date = new Date();

			_employeeController = new EmployeeController();
			_detectionController = new DetectionController();
			_kpiController = new KpiController();
			_reportController = new ReportController();
			_groupController = new GroupController();
			_bonusController = new BonusController();
			_positionController = new PositionController(_employeeController.Employees);

			_groupController.OnNameChanged += Group_OnNameChanged;
			_bonusController.OnNewEmployeeFinded += Kpi_OnNewEmployeeFinded;
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

		private int ParseInt(string text)
		{
			if (int.TryParse(text, out int result))
			{
				return result;
			}

			return default;
		}

		private bool CheckErrors()
		{
			string errorDescription = "";

			if (ParseInt(tbYear.Text) > 2000)
			{
				ShowErrorForm("Неверно задана дата", 27, "");
				return false;
			}

			if (_kpiController.Kpi.Path == "") errorDescription += "KPI\n";
			if (_reportController.Report.Path == "") errorDescription += "О показателях\n";

			if (errorDescription != "")
			{
				ShowErrorForm("Не загружены файлы:", 27, errorDescription);
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

		private void BtnMain_BackColorChanged(object sender, EventArgs e)
		{

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

		private void SelectTab()
		{

		}

		private void BtnCalculate_Click(object sender, EventArgs e)
		{
			//вставить async
			//if (CheckErrors()) return;

			//CalculateStart();

			//Cancel = false;

			//_date.TodayMonth = cbMonth.Text;
			//_date.Year = tbYear.Text;

			//// TODO: Начало анимации прогресса.	

			//// TODO: Прогресс KPI.
			//Table<Bonus> table = await Task.Run(() => _kpiController.CalculateBonuses(_employeeController.Employees, _detectionController.Detections));
			//// TODO: Отработка ситуации, если появился новый сотрудник.	
			//if (!CheckCalculateErrors()) return;

			//// TODO: Прогресс Report.
			//string newPath = await Task.Run(() => _reportController.StartBonusesReport(_groupController.Group));
			//if (!CheckCalculateErrors()) return;




			//// TODO: Конец анимации прогресса.	
			//CalculateStop();

			//// TODO: Уведомление об успешном завершении подсчёта.	
			//ShowSuccessfullyForm(newPath);
		}

		private void CalculateStart()
		{
			//progressBar.Start();
			progressBar.Visible = true;

			btnCancel.Visible = true;
			btnCalculate.Visible = false;
		}

		private void CalculateStop()
		{
			//progressBar.Stop();
			progressBar.Visible = false;

			btnCalculate.Visible = true;
			btnCancel.Visible = false;
		}

		private bool CheckCalculateErrors(string result)
		{
			if (result != "Успешно.")
			{
				CalculateStop();
				ShowErrorForm(result, 67, "");
				return false;
			}

			return true;
		}

		private void ShowErrorForm(string errorTitle, int errorTitleHeight, string errorDescription)
		{
			ErrorForm errorForm = new ErrorForm(errorTitle, errorTitleHeight, errorDescription);
			errorForm.Show();
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
				AddNewEmployeeForm addNewEmployeeForm = new AddNewEmployeeForm(employeeName, _employeeController, _positionController);
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
			tbGroup.Visible = true;
			btnApplyGroup.Visible = true;
		}

		private void BtnApplyGroup_Click(object sender, EventArgs e)
		{
			_groupController.Change(new Group(tbGroup.Text));
			tbGroup.Visible = false;
			btnApplyGroup.Visible = false;
		}

		private void BtnSaveEmployees_Click(object sender, EventArgs e)
		{
			var employees = new List<Employee>();
			for (int i = 0; i < tableEmployees.RowCount; i++)
			{
				var position = new Position(tableEmployees.Rows[i].Cells[1].Value.ToString());
				var employee = new Employee(tableEmployees.Rows[i].Cells[0].Value.ToString(), position);
				employees.Add(employee);

			}

			_employeeController.Save(employees);
			_positionController.Save(employees);
		}

		private void btnCancelEmployees_Click(object sender, EventArgs e)
		{
			InsertEmployeesData();
		}

		private void btnSaveDetections_Click(object sender, EventArgs e)
		{
			var detections = new List<Detection>();
			for (int i = 0; i < tableDetections.RowCount; i++)
			{
				var name = tableDetections.Rows[i].Cells[0].Value.ToString();
				var description = tableDetections.Rows[i].Cells[1].Value.ToString();
				detections.Add(new Detection(name, description));
			}

			_detectionController.Save(detections);
		}

		private void btnCancelDetections_Click(object sender, EventArgs e)
		{
			InsertDetectionsData();
		}

		private void InsertEmployeesData()
		{
			tableEmployees.Rows.Clear();
			for (int i = 0; i < _employeeController.Employees.Count; i++)
			{
				tableEmployees.Rows[i].Cells[0].Value = _employeeController.Employees[i].Name;
				tableEmployees.Rows[i].Cells[1].Value = _employeeController.Employees[i].Position.Name;
			}
		}

		private void InsertDetectionsData()
		{
			tableDetections.Rows.Clear();
			for (int i = 0; i < _detectionController.Detections.Count; i++)
			{
				tableDetections.Rows[i].Cells[0].Value = _detectionController.Detections[i].Name;
				tableDetections.Rows[i].Cells[1].Value = _detectionController.Detections[i].Description;
			}
		}

		private void propertyGrid1_Click(object sender, EventArgs e)
		{

		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			_cancel = true;
		}

		
	}
}
