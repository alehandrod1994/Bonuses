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
		private Dictionary<Status, string> _messages;

		private Date _date;

		private Logger _logger;

		private EmployeeController _employeeController;
		private DetectionController _detectionController;
		private KpiController _kpiController;
		private ReportController _reportController;
		private GroupController _groupController;
		private PositionController _positionController;

		private Button _selectedButton;

		public MainForm()
		{
			InitializeComponent();

			_logger = LogManager.GetCurrentClassLogger();

			_messages = new Dictionary<Status, string>()
			{
				{ Status.Cancel, "Отмена."},
				{ Status.Failed, "Не удалось открыть файл "},
				{ Status.NewEmployeeFound, "Найден новый сотрудник."},
				{ Status.NotSave, "Не удалось сохранить."},
				{ Status.Start, "Начало подсчёта."},
				{ Status.Success, "Успешно."},
				{ Status.UnknownData, "Не удалось распознать файл \"KPI\". Операция отменена."}
			};

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
			_positionController = new PositionController(_employeeController.Employees);

			_groupController.OnNameChanged += Group_OnNameChanged;			
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
			//string currentDisk = Directory.Exists(@"Z:\PUBLIC_VS3\") ? @"Z:\PUBLIC_VS3\" : @"U:\PUBLIC_VS3\";

			labelKpiFileName.Text = _kpiController.AutoImportKpi("KPI", _date.TodayMonth.Name, _date.TodayMonth.Name);
			labelKpiFileName.ForeColor = Color.Black;
			if (labelKpiFileName.Text != "")
			{
				btnKpi.Image = Properties.Resources.ExcelLogo;
			}
			
			labelReportFileName.Text = _reportController.AutoImportReport("KPI", _date.TodayMonth.Name, "О ПОКАЗАТЕЛЯХ (ШАБЛОН)");
			labelReportFileName.ForeColor = Color.Black;
			if (labelReportFileName.Text != "")
			{
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
			string errorDescription = "";

			if (ParseInt(tbYear.Text) < 2000)
			{
				ShowNoticeForm("Ошибка!", 27, "Неверно задана дата");
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
				await CalculateAsync();
			}
		}

		private async Task CalculateAsync()
		{
			StartCalculate();

			_cancel = false;

			_date.TodayMonth = _date.Months[cbMonth.SelectedIndex];
			_date.Year = Convert.ToInt32(tbYear.Text);

			var progress = new Progress<int>(value => progressBar1.Value = value);
			Status status = await Task.Run(() => _kpiController.StartCalculateBonuses(_employeeController, _detectionController.Detections, _cancel, progress));
			if (status != Status.Success)
			{
				ShutdownCalculate(status, _kpiController.Kpi.Name);
				return;
			}

			progressBar1.Left = 534;
			progressBar1.Value = 0;

			status = await Task.Run(() => _reportController.StartBonusesReport(_kpiController.Bonuses, _groupController.Group, _date, _cancel, progress));
			if (status != Status.Success)
			{
				ShutdownCalculate(status, _reportController.Report.Name);
				return;
			}

			EndCalculate();
			ShowSuccessfullyForm(_reportController.NewFilePath);
		}

		private void StartCalculate()
		{
			btnCancel.Visible = true;
			btnCalculate.Visible = false;

			// TODO: Начало анимации.
			progressBar1.Left = 353;
			progressBar1.Value = 0;
			progressBar1.Visible = true;
		}

		private void EndCalculate()
		{		
			btnCalculate.Visible = true;
			btnCancel.Visible = false;
			progressBar1.Visible = false;
		}

		private bool CheckCalculateErrors(string result)
		{
			if (result != "Успешно.")
			{
				EndCalculate();
				ShowNoticeForm(result, 67, "");
				return false;
			}

			return true;
		}

		private void ShutdownCalculate(Status status, string name)
		{
			EndCalculate();

			switch(status)
			{
				case Status.NewEmployeeFound:
					ShowAddNewEmployeeForm(_employeeController, _positionController, _kpiController);
					break;

				case Status.Failed:
					ShowNoticeForm(_messages[status] + name, 67, "");
					break;

				case Status.Cancel:
					break;

				default:
					ShowNoticeForm(_messages[status], 67, "");
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

		private void ShowAddNewEmployeeForm(EmployeeController _employeeController, PositionController _positionController, KpiController _kpiController)
		{
			if (_employeeController.NewEmployee != "")
			{
				AddNewEmployeeForm addNewEmployeeForm = new AddNewEmployeeForm(_employeeController, _positionController, _kpiController);
				addNewEmployeeForm.ShowDialog();
			}
		}

		private void Group_OnNameChanged(object sender, EventArgs e)
		{
			if (sender is Group group)
			{
				labelGroup.Text = group.Name;
			}
		}

		//private void Kpi_OnNewEmployeeFinded(object sender, EventArgs e)
		//{
		//	if (sender is string employeeName)
		//	{
		//		AddNewEmployeeForm addNewEmployeeForm = new AddNewEmployeeForm(employeeName, _employeeController, _positionController, _kpiController);
		//		addNewEmployeeForm.ShowDialog();
		//	}
		//}

		private async void Employee_OnNewEmployeeAdded(object sender, EventArgs e)
		{
			await CalculateAsync();
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
				labelKpiFileName.Text = _kpiController.DragDrop(file);
				labelKpiFileName.ForeColor = Color.Black;
				if (labelKpiFileName.Text != "")
				{
					btnKpi.Image = Properties.Resources.ExcelLogo;
				}
			}
		}

		private void btnReport_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
			{
				e.Effect = DragDropEffects.All;
			}
		}

		private void btnReport_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

			foreach (string file in files)
			{
				labelReportFileName.Text = _reportController.DragDrop(file);
				labelReportFileName.ForeColor = Color.Black;
				if (labelReportFileName.Text != "")
				{
					btnReport.Image = Properties.Resources.WordLogo;
				}
			}
		}

		private void BtnKpi_Click(object sender, EventArgs e)
		{
			labelKpiFileName.Text = _kpiController.Import();
			labelKpiFileName.ForeColor = Color.Black;
			if (labelKpiFileName.Text != "")
			{
				btnKpi.Image = Properties.Resources.ExcelLogo;
			}
		}

		private void BtnReport_Click(object sender, EventArgs e)
		{
			labelReportFileName.Text = _reportController.Import();
			labelReportFileName.ForeColor = Color.Black;
			if (labelReportFileName.Text != "")
			{
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

			ShowNoticeForm("Ошибка!", 27, "Неверно задана дата");

		}
	}
}
