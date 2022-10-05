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
			_bonusController.OnNewEmployeeFinded += Bonus_OnNewEmployeeFinded;
			_employeeController.OnNewEmployeeAdded += Bonus_OnNewEmployeeAdded;

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

		//private bool CheckErrors()
		//{

		//}

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
			//btnMain.BackColor = Color.White;
			//btnMain.ForeColor = Color.Navy;
			//btnEmployees.BackColor = Color.Navy;
			//btnEmployees.ForeColor = Color.White;
			//btnDetections.BackColor = Color.Navy;
			//btnDetections.ForeColor = Color.White;

			//panelMain.Visible = true;
			//panelEmployees.Visible = false;
			//panelDetections.Visible = false;

			OpenTab(btnMain, panelMain);
		}

		private void BtnMain_BackColorChanged(object sender, EventArgs e)
		{

		}

		private void BtnEmployees_Click(object sender, EventArgs e)
		{
			//btnMain.BackColor = Color.Navy;
			//btnMain.ForeColor = Color.White;
			//btnEmployees.BackColor = Color.White;
			//btnEmployees.ForeColor = Color.Navy;
			//btnDetections.BackColor = Color.Navy;
			//btnDetections.ForeColor = Color.White;

			//panelMain.Visible = false;
			//panelEmployees.Visible = true;
			//panelDetections.Visible = false;

			//InsertEmployeesData();
			OpenTab(btnEmployees, panelEmployees);
		}

		private void BtnDetections_Click(object sender, EventArgs e)
		{
			//btnMain.BackColor = Color.Navy;
			//btnMain.ForeColor = Color.White;
			//btnEmployees.BackColor = Color.Navy;
			//btnEmployees.ForeColor = Color.White;
			//btnDetections.BackColor = Color.White;
			//btnDetections.ForeColor = Color.Navy;

			//panelMain.Visible = false;
			//panelEmployees.Visible = false;
			//panelDetections.Visible = true;

			//InsertDetectionsData();
			OpenTab(btnDetections, panelDetections);
		}

		private void SelectTab()
		{

		}

		private void BtnCalculate_Click(object sender, EventArgs e)
		{
			//вставить async
			//if (CheckErrors()) return;

			//// TODO: Начало анимации прогресса.	

			//string result;
			//result = await _bonusController.Calculate(_kpiController.Kpi.Path, _employeeController.Employees, _detectionController.Detections);
			//if (result != "Успешно.")
			//{
			//	throw new Exception(result);
			//	return;
			//}

			//// TODO: Отработка ситуации, если появился новый сотрудник.

			//result = await _reportController.CalculateBonuses(_groupController.Group, bonusController);
			//if (result != "Успешно.")
			//{
			//	throw new Exception(result);
			//	return;
			//}

			//// TODO: Конец анимации прогресса.	
			//// TODO: Уведомление об успешном завершении подсчёта.	
		}

		private void Group_OnNameChanged(object sender, EventArgs e)
		{
			if (sender is Group group)
			{
				labelGroup.Text = group.Name;
			}
		}

		private void Bonus_OnNewEmployeeFinded(object sender, EventArgs e)
		{
			if (sender is string employeeName)
			{
				AddNewEmployeeForm addNewEmployeeForm = new AddNewEmployeeForm(employeeName, _employeeController, _positionController);
				addNewEmployeeForm.Show();
			}
		}

		private void Bonus_OnNewEmployeeAdded(object sender, EventArgs e)
		{
			BtnCalculate_Click(sender, e);
		}

		private void LabelGroup_DoubleClick(object sender, EventArgs e)
		{
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
	}
}
