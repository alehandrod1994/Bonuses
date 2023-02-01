﻿using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
		private Dictionary<Status, string> _messages;

		private Date _date;

		private EmployeeController _employeeController;
		private DetectionController _detectionController;
		private KpiController _kpiController;
		private ReportController _reportController;
		private GroupController _groupController;
		private PositionController _positionController;

		private Button _selectedButton;

		private readonly int _progressBarKpiPosition = 353;
		private readonly int _progressBarReportPosition = 534;

		public MainForm()
		{
			InitializeComponent();
				
			_messages = new Dictionary<Status, string>()
			{
				{ Status.Stop, "Подсчёт остановлен."},
				{ Status.Failed, "Не удалось открыть файл"},
				{ Status.NewEmployeeFound, "Найден новый сотрудник."},
				{ Status.NotSave, "Не удалось сохранить."},
				{ Status.Start, "Начало подсчёта."},
				{ Status.Success, "Успешно."},
				{ Status.UnknownData, "Не удалось распознать файл \"KPI\". Операция отменена."}
			};

			updateItem.Click += UpdateItem_Click;
			importKpiItem.Click += ImportKpiItem_Click;
			importReportItem.Click += ImportReportItem_Click;
			changeGroupItem.Click += ChangeGroupItem_Click;
			exitItem.Click += ExitItem_Click;
			manualItem.Click += ManualItem_Click;
			aboutItem.Click += AboutItem_Click;

			CreateSourceData();

			AutoImportDate();
			AutoImportDocuments();
		}

		private void AboutItem_Click(object sender, EventArgs e)
		{
			var aboutForm = new AboutForm();
			aboutForm.Show();
		}

		private void ManualItem_Click(object sender, EventArgs e)
		{
			string path = "manual\\Подсчёт премирования. Инструкция по эксплуатации.docx";

			try
			{				
				Process.Start(path);
			}
			catch
			{
				ShowWarningForm("Не удалось открыть инструкцию.", null);
			}
		}

		private void CreateSourceData()
		{
			_date = new Date();

			_employeeController = new EmployeeController();
			_detectionController = new DetectionController();
			_kpiController = new KpiController();
			_reportController = new ReportController();
			_groupController = new GroupController();
			_positionController = new PositionController(_employeeController.Employees);

			_groupController.OnNameChanged += Group_OnNameChanged;
			_employeeController.OnNewEmployeeAdded += Employee_OnNewEmployeeAdded;

			if (_groupController.Group.Name == null)
			{
				var form = new AddGroupForm(_groupController);
				form.ShowDialog();
			}
			else
			{
				labelGroup.Text = _groupController.Group.Name;
			}

			_selectedButton = btnMain;
			OpenTab(btnMain, panelMain);
			PutOnButtonSelect(btnMain);
		}

		private void UpdateItem_Click(object sender, EventArgs e)
		{
			CreateSourceData();

			labelKpiFileName.ForeColor = Color.DimGray;
			labelKpiFileName.Text = "Файл не загружен";
			btnKpi.Image = Properties.Resources.ExcelLogo_BW;

			labelReportFileName.ForeColor = Color.DimGray;
			labelReportFileName.Text = "Файл не загружен";
			btnReport.Image = Properties.Resources.WordLogo_BW;
		}

		private void ImportKpiItem_Click(object sender, EventArgs e)
		{
			ImportKpi();
		}

		private void ImportReportItem_Click(object sender, EventArgs e)
		{
			ImportReport();
		}

		private void ChangeGroupItem_Click(object sender, EventArgs e)
		{
			ChangeGroup();
		}

		private void ExitItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void AutoImportDate()
		{
			cbMonth.Text = _date.SelectedMonth.Name;
			tbYear.Text = _date.SelectedYear.ToString();
		}

		private void AutoImportDocuments()
		{
			//string currentDisk = Directory.Exists(@"Z:\PUBLIC_VS3\") ? @"Z:\PUBLIC_VS3\" : @"U:\PUBLIC_VS3\";

			string kpiFileName = _kpiController.AutoImportKpi("KPI", _date.SelectedMonth.Name, _date.SelectedMonth.Name);
			if (kpiFileName != "")
			{
				labelKpiFileName.Text = kpiFileName;
				labelKpiFileName.ForeColor = Color.Black;
				btnKpi.Image = Properties.Resources.ExcelLogo;
			}
			
			string reportFileName = _reportController.AutoImportReport("KPI", _date.SelectedMonth.Name, "О ПОКАЗАТЕЛЯХ (ШАБЛОН)");
			if (reportFileName != "")
			{
				labelReportFileName.Text = reportFileName;
				labelReportFileName.ForeColor = Color.Black;
				btnReport.Image = Properties.Resources.WordLogo;
			}		
		}

		//private string ImportFile(Document document)
		//{
		//	string name = document.Name;
		//	string type = document.Type;
		//	string extention = document.Extention;

		//	OpenFileDialog ofd = new OpenFileDialog();
		//	ofd.FileName = "";
		//	ofd.Filter = $"Документ {type} (*{extention}; *{extention}x) | *{extention}; *{extention}x";
		//	ofd.Title = $"Выберите файл {name}";

		//	if (ofd.ShowDialog() != DialogResult.Cancel)
		//	{
		//		try
		//		{
		//			document = new Document(ofd.FileName);

		//			//document.Path = ofd.FileName;
		//			//document.FileName = ofd.SafeFileName;
		//		}
		//		catch
		//		{
		//			ShowNoticeForm("Недопустимый формат файла", 27, "");
		//		}
		//	}

		//	return document.FileName;
		//}

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
			string warningDescription = "";

			if (ParseInt(tbYear.Text) < 2000)
			{
				ShowWarningForm("Неверно задана дата", "SetDate");
				//ShowNoticeForm("Ошибка!", 27, "Неверно задана дата");
				return false;
			}

			if (_kpiController.Kpi.Path == "") warningDescription += "KPI\n";
			if (_reportController.Report.Path == "") warningDescription += "О показателях\n";

			if (warningDescription != "")
			{
				ShowWarningForm("Не загружены файлы:\n" + warningDescription, "ImportFiles");
				return false;
			}

			return true;
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

		private async void BtnCalculate_Click(object sender, EventArgs e)
		{
			if (CheckErrors())
			{
				await CalculateAsync(Status.Start);
			}
		}

		private async Task CalculateAsync(Status status)
		{
			SetUiForStartCalculate();

			_date.SelectedMonth = _date.Months[cbMonth.SelectedIndex];
			_date.SelectedYear = Convert.ToInt32(tbYear.Text);

			var progress = new Progress<int>(value => progressBar1.Value = value);
			status = await Task.Run(() => 
			_kpiController.StartCalculateBonuses(_employeeController, _detectionController.Detections, status, progress));
			if (status != Status.Success)
			{
				ShutdownCalculate(status, _kpiController.Kpi.Name);
				return;
			}

			progressBar1.Left = _progressBarReportPosition;
			progressBar1.Value = 0;

			status = await Task.Run(() => 
			_reportController.StartBonusesReport(_kpiController.Bonuses, _groupController.Group, _date, progress));
			if (status != Status.Success)
			{
				ShutdownCalculate(status, _reportController.Report.Name);
				return;
			}

			SetUiForEndCalculate();
			ShowSuccessfullyForm(_reportController.NewFilePath);
		}

		private void SetUiForStartCalculate()
		{
			btnCancel.Visible = true;
			btnCalculate.Visible = false;
			progressBar1.Left = _progressBarKpiPosition;
			progressBar1.Value = 0;
			progressBar1.Visible = true;
		}

		private void SetUiForEndCalculate()
		{		
			btnCalculate.Visible = true;
			btnCancel.Visible = false;
			progressBar1.Visible = false;
		}

		private void ShutdownCalculate(Status status, string name)
		{
			SetUiForEndCalculate();

			switch(status)
			{
				case Status.NewEmployeeFound:
					ShowAddNewEmployeeForm(_employeeController, _positionController);
					break;

				case Status.Failed:
					ShowWarningForm($"{_messages[status]} \"{name}\"", "ConnectFile");
					//ShowNoticeForm($"{_messages[status]} \"{name}\"", 67, "");
					break;

				case Status.Stop:
					break;

				default:
					ShowWarningForm(_messages[status], "FailedCalculate");
					//ShowNoticeForm(_messages[status], 67, "");
					break;
			}

			//if (status == Status.NewEmployeeFound)
			//{
			//	ShowAddNewEmployeeForm(_employeeController, _positionController, _kpiController);
			//}
			//else if (status == Status.Failed)
			//{
			//	ShowNoticeForm(_messages[status] + name, 67, "");
			//}
			//else
			//{
			//	ShowNoticeForm(_messages[status], 67, "");
			//}
		}

		private void ShowNoticeForm(string noticeDescription)
		{
			var form = new NoticeForm(noticeDescription);
			form.Show();
		}

		private void ShowWarningForm(string warningDescription, string help)
		{
			var form = new WarningForm(warningDescription, help);
			form.Show();
		}

		private void ShowWarningForm(string warningTitle, int warningTitleHeight, string warningDescription, string help)
		{
			var form = new WarningForm(warningTitle, warningTitleHeight, warningDescription, help);
			form.Show();
		}

		private void ShowSuccessfullyForm(string newPath)
		{
			var form = new SuccessfullyForm(newPath);
			form.Show();
		}

		private void ShowAddNewEmployeeForm(EmployeeController _employeeController, PositionController _positionController)
		{
			if (_employeeController.NewEmployee != "")
			{
				var form = new AddNewEmployeeForm(_employeeController, _positionController);
				form.ShowDialog();
			}
		}

		private void Group_OnNameChanged(object sender, EventArgs e)
		{
			if (sender is Group group)
			{
				labelGroup.Text = group.Name;
			}
		}

		private async void Employee_OnNewEmployeeAdded(object sender, EventArgs e)
		{
			await CalculateAsync(Status.NewEmployeeFound);
		}

		private void BtnApplyGroup_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(tbGroup.Text))
			{
				_groupController.Change(new Group(tbGroup.Text));
				panelGroup.Visible = false;
				tbGroup.Visible = false;
				btnApplyGroup.Visible = false;
				btnCancelGroup.Visible = false;
			}
		}

		private void BtnCancelGroup_Click(object sender, EventArgs e)
		{
			panelGroup.Visible = false;
			tbGroup.Visible = false;
			btnApplyGroup.Visible = false;
			btnCancelGroup.Visible = false;
		}

		private bool FormatTable(DataGridView table)
		{
			for (int i = 0; i < table.RowCount - 1; i++)
			{
				string column1 = table.Rows[i].Cells[0].Value?.ToString();
				string column2 = table.Rows[i].Cells[1].Value?.ToString();

				if (string.IsNullOrWhiteSpace(column1) && string.IsNullOrWhiteSpace(column2))
				{
					table.Rows.RemoveAt(i);
					i--;
					continue;
				}
				else if (string.IsNullOrWhiteSpace(column1) || string.IsNullOrWhiteSpace(column2))
				{
					ShowWarningForm("Не удалось сохранить", 27, $"Одно из полей не заполнено:\n Строчка: {i + 1}", "SaveData");
					return false;
				}

				table.Rows[i].Cells[0].Value = Regex.Replace(column1, @"\s+", " ");
				table.Rows[i].Cells[1].Value = Regex.Replace(column2, @"\s+", " ");				
			}

			return true;
		}

		private void BtnSaveEmployees_Click(object sender, EventArgs e)
		{
			if (!FormatTable(tableEmployees))
			{
				return;
			}

			var employees = new List<Employee>();
			for (int i = 0; i < tableEmployees.RowCount - 1; i++)
			{
				var position = new Position(tableEmployees.Rows[i].Cells[1].Value.ToString());
				var employee = new Employee(tableEmployees.Rows[i].Cells[0].Value.ToString(), position);
				employees.Add(employee);

			}

			_employeeController.ReWrite(employees);
			_positionController.ReWrite(employees);				
			ShowNoticeForm("Данные успешно сохранены.");           
		}

		private void BtnCancelEmployees_Click(object sender, EventArgs e)
		{
			InsertEmployeesData();
		}

		private void BtnSaveDetections_Click(object sender, EventArgs e)
		{
			if (!FormatTable(tableDetections))
			{
				return;
			}

			var detections = new List<Detection>();
			for (int i = 0; i < tableDetections.RowCount - 1; i++)
			{
				var name = tableDetections.Rows[i].Cells[0].Value.ToString();
				var description = tableDetections.Rows[i].Cells[1].Value.ToString();
				detections.Add(new Detection(name, description));
			}

			_detectionController.ReWrite(detections);
			ShowNoticeForm("Данные успешно сохранены.");
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
			_kpiController.StopCalculate();
			_reportController.StopCalculate();
		}

		private void BtnKpi_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
			{
				e.Effect = DragDropEffects.All;
			}
		}

		private void BtnKpi_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

			foreach (string file in files)
			{				
				string kpiFileName = _kpiController.DragDrop(file);
				if (kpiFileName != "")
				{
					labelKpiFileName.Text = kpiFileName;
					labelKpiFileName.ForeColor = Color.Black;
					btnKpi.Image = Properties.Resources.ExcelLogo;
				}
			}
		}

		private void BtnReport_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
			{
				e.Effect = DragDropEffects.All;
			}
		}

		private void BtnReport_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

			foreach (string file in files)
			{
				string reportFileName = _reportController.DragDrop(file);
				if (reportFileName != "")
				{
					labelReportFileName.Text = reportFileName;
					labelReportFileName.ForeColor = Color.Black;
					btnReport.Image = Properties.Resources.WordLogo;
				}
			}
		}

		private void BtnKpi_Click(object sender, EventArgs e)
		{
			ImportKpi();
		}

		private void ImportKpi()
		{
			string kpiFileName = _kpiController.Import();
			if (kpiFileName != "")
			{
				labelKpiFileName.Text = kpiFileName;
				labelKpiFileName.ForeColor = Color.Black;
				btnKpi.Image = Properties.Resources.ExcelLogo;
			}
		}

		private void BtnReport_Click(object sender, EventArgs e)
		{
			ImportReport();
		}

		private void ImportReport()
		{
			string reportFileName = _reportController.Import();
			if (reportFileName != "")
			{
				labelReportFileName.Text = reportFileName;
				labelReportFileName.ForeColor = Color.Black;
				btnReport.Image = Properties.Resources.WordLogo;
			}
		}

		private void BtnSettings_Click(object sender, EventArgs e)
		{
			InsertSettingsData();
			OpenTab(btnSettings, panelSettings);
		}

		private void btnSaveSettings_Click(object sender, EventArgs e)
		{
			var kpi = new Kpi() { SourceDirectory = tbKpiSouceDirectory.Text };
			_kpiController.Save(kpi);
			_kpiController.Kpi.SourceDirectory = kpi.SourceDirectory;

			var report = new Report() { SourceDirectory = tbReportSourceDirectory.Text };
			_reportController.Save(report);
			_reportController.Report.SourceDirectory = report.SourceDirectory;

			ShowNoticeForm("Данные успешно сохранены.");
		}

		private void btnCancelSettings_Click(object sender, EventArgs e)
		{
			InsertSettingsData();
		}

		private void InsertSettingsData()
		{
			tbKpiSouceDirectory.Text = _kpiController.Kpi.SourceDirectory;
			tbReportSourceDirectory.Text = _reportController.Report.SourceDirectory;
		}

		private void panelKpi_MouseEnter(object sender, EventArgs e)
		{
			panelKpi.BackColor = Color.Gainsboro;
		}

		private void panelKpi_MouseLeave(object sender, EventArgs e)
		{
			panelKpi.BackColor = Color.White;
		}

		private void panelKpi_MouseDown(object sender, MouseEventArgs e)
		{
			panelKpi.BackColor = Color.LightGray;
		}

		private void panelKpi_MouseUp(object sender, MouseEventArgs e)
		{
			panelKpi.BackColor = Color.Gainsboro;
		}

		private void panelReport_MouseEnter(object sender, EventArgs e)
		{
			panelReport.BackColor = Color.Gainsboro;
		}

		private void panelReport_MouseLeave(object sender, EventArgs e)
		{
			panelReport.BackColor = Color.White;
		}

		private void panelReport_MouseDown(object sender, MouseEventArgs e)
		{
			panelReport.BackColor = Color.LightGray;
		}		

		private void panelReport_MouseUp(object sender, MouseEventArgs e)
		{
			panelReport.BackColor = Color.Gainsboro;
		}

		private void BtnChooseKpiDirectory_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				tbKpiSouceDirectory.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void BtnChooseReportDirectory_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				tbReportSourceDirectory.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void LabelGroup_DoubleClick(object sender, EventArgs e)
		{
			ChangeGroup();
		}

		private void ChangeGroup()
		{
			tbGroup.Text = "";
			tbGroup.Visible = true;
			btnApplyGroup.Visible = true;
			btnCancelGroup.Visible = true;
			panelGroup.Visible = true;
		}

		private void BtnTest_Click(object sender, EventArgs e)
		{
			//ShowSuccessfullyForm(@"C:\PUBLIC_VS3\KPI Ноябрь 2022\О показателях ГПУ ОТБ НОЯБРЬ 2022г.docx");

			//AddNewEmployeeForm addNewEmployeeForm = new AddNewEmployeeForm("Бериншвили Александр Константинович", _employeeController, _positionController, _kpiController);
			//addNewEmployeeForm.ShowDialog();

			//AddGroupForm addGroupForm = new AddGroupForm(_groupController);
			//addGroupForm.ShowDialog();

			//ShowNoticeForm("Ошибка!", 27, "Неверно задана дата");

			//AddGroupForm addGroupForm = new AddGroupForm(_groupController);
			//addGroupForm.ShowDialog();

		}
	}
}
