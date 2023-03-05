using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group = Bonuses.BL.Model.Group;

namespace Bonuses.View
{
	public partial class MainForm : Form
	{
		private readonly Dictionary<Status, string> _messages;

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
				{ Status.Failed, "Не удалось открыть файл"},
				{ Status.NewEmployeeFound, "Найден новый сотрудник."},
				{ Status.NotSave, "Не удалось сохранить файл."},
				{ Status.Start, "Начало подсчёта."},
				{ Status.Stop, "Подсчёт остановлен."},
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

			_employeeController.NewEmployeeAdded += EmployeeController_NewEmployeeAdded;

			if (_groupController.Group.Name == null)
			{
				ShowAddGroupForm("AddGroup");
			}
			else
			{
				labelGroup.Text = _groupController.Group.Name;
			}

			_selectedButton = btnMain;
			OpenTab(btnMain, panelMain);
			TurnOnSelectedButton(btnMain);
		}

		private void UpdateItem_Click(object sender, EventArgs e)
		{
			CreateSourceData();

			labelKpiFileName.ForeColor = Color.DimGray;
			labelKpiFileName.Text = "Файл не загружен";
			labelKpiFileName.Enabled = false;
			btnKpi.Image = Properties.Resources.ExcelLogo_BW;


			labelReportFileName.ForeColor = Color.DimGray;
			labelReportFileName.Text = "Файл не загружен";
			labelReportFileName.Enabled = false;
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
			string kpiFileName = _kpiController.AutoImportKpi("KPI", _date.SelectedMonth.Name, _date.SelectedMonth.Name);
			if (kpiFileName != "")
			{
				SetKpiData(kpiFileName);
			}

			string reportFileName = _reportController.AutoImportReport("KPI", _date.SelectedMonth.Name, "О ПОКАЗАТЕЛЯХ (ШАБЛОН)");
			if (reportFileName != "")
			{
				SetReportData(reportFileName);
			}
		}		

		private void SetKpiData(string kpiFileName)
		{
			labelKpiFileName.Text = kpiFileName;
			labelKpiFileName.ForeColor = Color.Black;
			labelKpiFileName.Enabled = true;
			btnKpi.Image = Properties.Resources.ExcelLogo;
		}

		private void SetReportData(string reportFileName)
		{
			labelReportFileName.Text = reportFileName;
			labelReportFileName.ForeColor = Color.Black;
			labelReportFileName.Enabled = true;
			btnReport.Image = Properties.Resources.WordLogo;
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
			string warningDescription = "";

			if (ParseInt(tbYear.Text) < 2000)
			{
				ShowWarningForm("Неверно задана дата", "SetDate");
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
				 
			TurnOffSelectedButton(_selectedButton);
			TurnOnSelectedButton(button);
		}

		private void TurnOnSelectedButton(Button button)
		{
			button.BackColor = Color.White;
			button.ForeColor = Color.Navy;
			_selectedButton = button;
		}

		private void TurnOffSelectedButton(Button button)
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
			_reportController.StartBonusesReport(_kpiController, _groupController.Group, _date, progress));
			if (status != Status.Success)
			{
				ShutdownCalculate(status, _reportController.Report.Name);
				return;
			}

			SetUiForEndCalculate();
			ShowSuccessfullyForm(_reportController.NewFilePath, "Successfully");
		}

		private void SetUiForStartCalculate()
		{
			btnEmployees.Enabled = false;
			btnDetections.Enabled = false;
			btnSettings.Enabled = false;
			btnCancel.Visible = true;
			btnCalculate.Visible = false;
			progressBar1.Left = _progressBarKpiPosition;
			progressBar1.Value = 0;
			progressBar1.Visible = true;
		}

		private void SetUiForEndCalculate()
		{
			btnEmployees.Enabled = true;
			btnDetections.Enabled = true;
			btnSettings.Enabled = true;
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
					ShowAddNewEmployeeForm(_employeeController, _positionController, "AddNewEmployee");
					break;

				case Status.Failed:
					ShowWarningForm($"{_messages[status]} \"{name}\". Закройте его, если он открыт.", "ConnectFile");
					break;

				case Status.NotSave:
					ShowWarningForm(_messages[status], "SaveFile");
					break;

				case Status.UnknownData:
					ShowWarningForm(_messages[status], "UnknownData");
					break;

				default:
					break;
			}
		}

		private void ShowAddGroupForm(string help)
		{
			var form = new AddGroupForm(help);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_groupController.Change(form.Group);
			}
			else
			{
				Environment.Exit(0);
			}
		}

		private void ShowNoticeForm(string noticeDescription, string help)
		{
			var form = new NoticeForm(noticeDescription, help);
			form.Show();
		}

		private void ShowWarningForm(string warningDescription, string help)
		{
			var form = new WarningForm(warningDescription, help);
			form.Show();
		}

		private void ShowWarningForm(string warningTitle, string warningDescription, string help)
		{
			var form = new WarningForm(warningTitle, warningDescription, help);
			form.Show();
		}

		private void ShowSuccessfullyForm(string newPath, string help)
		{
			var form = new SuccessfullyForm(newPath, help);
			form.Show();
		}

		private void ShowAddNewEmployeeForm(EmployeeController _employeeController, PositionController _positionController, string help)
		{
			if (_employeeController.NewEmployee != "")
			{
				var form = new AddNewEmployeeForm(_employeeController, _positionController, help);
				form.ShowDialog();
			}
		}		

		private async void EmployeeController_NewEmployeeAdded(object sender, Employee e)
		{
			await CalculateAsync(Status.NewEmployeeFound);
		}

		private void BtnApplyGroup_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(tbGroup.Text))
			{
				_groupController.Change(new Group(tbGroup.Text));
				labelGroup.Text = _groupController.Group.Name;
				tbGroup.Visible = false;
				btnApplyGroup.Visible = false;
				btnCancelGroup.Visible = false;
			}
		}

		private void BtnCancelGroup_Click(object sender, EventArgs e)
		{
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
					ShowWarningForm("Не удалось сохранить", $"Одно из полей не заполнено:\n Строка: {i + 1}", "SaveData");
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
			ShowNoticeForm("Данные успешно сохранены.", "SaveData");           
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
			ShowNoticeForm("Данные успешно сохранены.", "SaveData");
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
					SetKpiData(kpiFileName);
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
					SetReportData(reportFileName);
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
				SetKpiData(kpiFileName);
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
				SetReportData(reportFileName);
			}
		}

		private void BtnSettings_Click(object sender, EventArgs e)
		{
			InsertSettingsData();
			OpenTab(btnSettings, panelSettings);
		}

		private void BtnSaveSettings_Click(object sender, EventArgs e)
		{
			var kpi = new Kpi() { SourceDirectory = tbKpiSouceDirectory.Text };
			_kpiController.Save(kpi);
			_kpiController.Kpi.SourceDirectory = kpi.SourceDirectory;

			var report = new Report() { SourceDirectory = tbReportSourceDirectory.Text };
			_reportController.Save(report);
			_reportController.Report.SourceDirectory = report.SourceDirectory;

			ShowNoticeForm("Данные успешно сохранены.", "SaveData");
		}

		private void BtnCancelSettings_Click(object sender, EventArgs e)
		{
			InsertSettingsData();
		}

		private void InsertSettingsData()
		{
			tbKpiSouceDirectory.Text = _kpiController.Kpi.SourceDirectory;
			tbReportSourceDirectory.Text = _reportController.Report.SourceDirectory;
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
			tbGroup.Select();
			btnApplyGroup.Visible = true;
			btnCancelGroup.Visible = true;
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

		private void BtnOpenDirectoryKpi_Click(object sender, EventArgs e)
		{
			Process.Start(tbKpiSouceDirectory.Text);
		}

		private void BtnOpenDirectoryReport_Click(object sender, EventArgs e)
		{
			Process.Start(tbReportSourceDirectory.Text);
		}

		private void LabelKpiFileName_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (_kpiController.Kpi.Path != "")
			{
				Process.Start(_kpiController.Kpi.Path);
			}
		}

		private void LabelReportFileName_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (_reportController.Report.Path != "")
			{
				Process.Start(_reportController.Report.Path);
			}
		}
	}
}
