
namespace Bonuses.View
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCalculate = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCancelGroup = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnApplyGroup = new System.Windows.Forms.Button();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.panelGroup = new System.Windows.Forms.Panel();
            this.labelGroup = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnDetections = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelDate = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.labelReportFileName = new System.Windows.Forms.Label();
            this.labelKpiFileName = new System.Windows.Forms.Label();
            this.panelReport = new System.Windows.Forms.Panel();
            this.panelKpi = new System.Windows.Forms.Panel();
            this.labelReportFileName2 = new System.Windows.Forms.Label();
            this.labelKpiFileName2 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnKpi = new System.Windows.Forms.Button();
            this.labelReport = new System.Windows.Forms.Label();
            this.labelKpi = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelDetections = new System.Windows.Forms.Panel();
            this.btnCancelDetections = new System.Windows.Forms.Button();
            this.btnSaveDetections = new System.Windows.Forms.Button();
            this.tableDetections = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEmployees = new System.Windows.Forms.Panel();
            this.btnCancelEmployees = new System.Windows.Forms.Button();
            this.btnSaveEmployees = new System.Windows.Forms.Button();
            this.tableEmployees = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnChooseDirectoryReport = new System.Windows.Forms.Button();
            this.btnChooseDirectoryKpi = new System.Windows.Forms.Button();
            this.btnCancelSettings = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.tbReportSourceDirectory = new System.Windows.Forms.TextBox();
            this.tbKpiSouceDirectory = new System.Windows.Forms.TextBox();
            this.labelReportSourceDirectory = new System.Windows.Forms.Label();
            this.labelKpiSouceDirectory = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importKpiItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importReportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeGroupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMenu.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelDetections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDetections)).BeginInit();
            this.panelEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEmployees)).BeginInit();
            this.panelSettings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Navy;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(445, 500);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(160, 64);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Подсчитать";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Navy;
            this.panelMenu.Controls.Add(this.btnCancelGroup);
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Controls.Add(this.btnApplyGroup);
            this.panelMenu.Controls.Add(this.tbGroup);
            this.panelMenu.Controls.Add(this.panelGroup);
            this.panelMenu.Controls.Add(this.labelGroup);
            this.panelMenu.Controls.Add(this.btnTest);
            this.panelMenu.Controls.Add(this.btnDetections);
            this.panelMenu.Controls.Add(this.btnEmployees);
            this.panelMenu.Controls.Add(this.btnMain);
            this.panelMenu.Location = new System.Drawing.Point(0, 23);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 669);
            this.panelMenu.TabIndex = 2;
            // 
            // btnCancelGroup
            // 
            this.btnCancelGroup.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnCancelGroup.FlatAppearance.BorderSize = 0;
            this.btnCancelGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancelGroup.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancelGroup.Location = new System.Drawing.Point(98, 40);
            this.btnCancelGroup.Name = "btnCancelGroup";
            this.btnCancelGroup.Size = new System.Drawing.Size(74, 23);
            this.btnCancelGroup.TabIndex = 7;
            this.btnCancelGroup.Text = "Отмена";
            this.btnCancelGroup.UseVisualStyleBackColor = false;
            this.btnCancelGroup.Visible = false;
            this.btnCancelGroup.Click += new System.EventHandler(this.BtnCancelGroup_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSettings.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSettings.Location = new System.Drawing.Point(0, 203);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(180, 45);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnApplyGroup
            // 
            this.btnApplyGroup.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnApplyGroup.FlatAppearance.BorderSize = 0;
            this.btnApplyGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApplyGroup.ForeColor = System.Drawing.SystemColors.Window;
            this.btnApplyGroup.Location = new System.Drawing.Point(7, 40);
            this.btnApplyGroup.Name = "btnApplyGroup";
            this.btnApplyGroup.Size = new System.Drawing.Size(85, 23);
            this.btnApplyGroup.TabIndex = 5;
            this.btnApplyGroup.Text = "ОК";
            this.btnApplyGroup.UseVisualStyleBackColor = false;
            this.btnApplyGroup.Visible = false;
            this.btnApplyGroup.Click += new System.EventHandler(this.BtnApplyGroup_Click);
            // 
            // tbGroup
            // 
            this.tbGroup.BackColor = System.Drawing.Color.DarkOrchid;
            this.tbGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbGroup.ForeColor = System.Drawing.SystemColors.Window;
            this.tbGroup.Location = new System.Drawing.Point(5, 3);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(167, 31);
            this.tbGroup.TabIndex = 6;
            this.tbGroup.Visible = false;
            // 
            // panelGroup
            // 
            this.panelGroup.BackColor = System.Drawing.Color.Navy;
            this.panelGroup.Location = new System.Drawing.Point(5, 302);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(175, 100);
            this.panelGroup.TabIndex = 7;
            this.panelGroup.Visible = false;
            // 
            // labelGroup
            // 
            this.labelGroup.AutoEllipsis = true;
            this.labelGroup.BackColor = System.Drawing.Color.DarkOrchid;
            this.labelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGroup.ForeColor = System.Drawing.SystemColors.Window;
            this.labelGroup.Location = new System.Drawing.Point(0, -1);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(180, 38);
            this.labelGroup.TabIndex = 4;
            this.labelGroup.Text = "Отдел";
            this.labelGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGroup.DoubleClick += new System.EventHandler(this.LabelGroup_DoubleClick);
            // 
            // btnTest
            // 
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTest.ForeColor = System.Drawing.SystemColors.Window;
            this.btnTest.Location = new System.Drawing.Point(3, 393);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(174, 45);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Тест";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // btnDetections
            // 
            this.btnDetections.FlatAppearance.BorderSize = 0;
            this.btnDetections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetections.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDetections.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDetections.Location = new System.Drawing.Point(0, 161);
            this.btnDetections.Name = "btnDetections";
            this.btnDetections.Size = new System.Drawing.Size(180, 45);
            this.btnDetections.TabIndex = 2;
            this.btnDetections.Text = "Нарушения";
            this.btnDetections.UseVisualStyleBackColor = true;
            this.btnDetections.Click += new System.EventHandler(this.BtnDetections_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmployees.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEmployees.Location = new System.Drawing.Point(0, 119);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(180, 45);
            this.btnEmployees.TabIndex = 1;
            this.btnEmployees.Text = "Сотрудники";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.BtnEmployees_Click);
            // 
            // btnMain
            // 
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMain.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMain.Location = new System.Drawing.Point(0, 77);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(180, 45);
            this.btnMain.TabIndex = 0;
            this.btnMain.Text = "Главная";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.BtnMain_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.SystemColors.Window;
            this.panelMain.Controls.Add(this.labelDate);
            this.panelMain.Controls.Add(this.cbMonth);
            this.panelMain.Controls.Add(this.tbYear);
            this.panelMain.Controls.Add(this.labelReportFileName);
            this.panelMain.Controls.Add(this.labelKpiFileName);
            this.panelMain.Controls.Add(this.panelReport);
            this.panelMain.Controls.Add(this.panelKpi);
            this.panelMain.Controls.Add(this.labelReportFileName2);
            this.panelMain.Controls.Add(this.labelKpiFileName2);
            this.panelMain.Controls.Add(this.btnReport);
            this.panelMain.Controls.Add(this.btnKpi);
            this.panelMain.Controls.Add(this.labelReport);
            this.panelMain.Controls.Add(this.labelKpi);
            this.panelMain.Controls.Add(this.btnCalculate);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.progressBar1);
            this.panelMain.Location = new System.Drawing.Point(200, 23);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1046, 669);
            this.panelMain.TabIndex = 3;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDate.Location = new System.Drawing.Point(190, 138);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(52, 20);
            this.labelDate.TabIndex = 17;
            this.labelDate.Text = "Дата:";
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbMonth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.cbMonth.Location = new System.Drawing.Point(138, 170);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(100, 26);
            this.cbMonth.TabIndex = 3;
            // 
            // tbYear
            // 
            this.tbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbYear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbYear.Location = new System.Drawing.Point(244, 170);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(41, 24);
            this.tbYear.TabIndex = 4;
            this.tbYear.Text = "2020";
            // 
            // labelReportFileName
            // 
            this.labelReportFileName.AutoEllipsis = true;
            this.labelReportFileName.BackColor = System.Drawing.SystemColors.Window;
            this.labelReportFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelReportFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReportFileName.ForeColor = System.Drawing.Color.DimGray;
            this.labelReportFileName.Location = new System.Drawing.Point(535, 347);
            this.labelReportFileName.Name = "labelReportFileName";
            this.labelReportFileName.Size = new System.Drawing.Size(147, 31);
            this.labelReportFileName.TabIndex = 16;
            this.labelReportFileName.Text = "Файл не загружен";
            this.labelReportFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelKpiFileName
            // 
            this.labelKpiFileName.AutoEllipsis = true;
            this.labelKpiFileName.BackColor = System.Drawing.SystemColors.Window;
            this.labelKpiFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelKpiFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKpiFileName.ForeColor = System.Drawing.Color.DimGray;
            this.labelKpiFileName.Location = new System.Drawing.Point(354, 347);
            this.labelKpiFileName.Name = "labelKpiFileName";
            this.labelKpiFileName.Size = new System.Drawing.Size(147, 31);
            this.labelKpiFileName.TabIndex = 15;
            this.labelKpiFileName.Text = "Файл не загружен";
            this.labelKpiFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelReport
            // 
            this.panelReport.BackColor = System.Drawing.Color.White;
            this.panelReport.BackgroundImage = global::Bonuses.View.Properties.Resources.WordLogo;
            this.panelReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReport.Location = new System.Drawing.Point(750, 170);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(148, 174);
            this.panelReport.TabIndex = 14;
            this.panelReport.Visible = false;
            this.panelReport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelReport_MouseDown);
            this.panelReport.MouseEnter += new System.EventHandler(this.panelReport_MouseEnter);
            this.panelReport.MouseLeave += new System.EventHandler(this.panelReport_MouseLeave);
            this.panelReport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelReport_MouseUp);
            // 
            // panelKpi
            // 
            this.panelKpi.BackColor = System.Drawing.Color.White;
            this.panelKpi.BackgroundImage = global::Bonuses.View.Properties.Resources.ExcelLogo;
            this.panelKpi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelKpi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpi.Location = new System.Drawing.Point(137, 189);
            this.panelKpi.Name = "panelKpi";
            this.panelKpi.Size = new System.Drawing.Size(148, 174);
            this.panelKpi.TabIndex = 13;
            this.panelKpi.Visible = false;
            this.panelKpi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelKpi_MouseDown);
            this.panelKpi.MouseEnter += new System.EventHandler(this.panelKpi_MouseEnter);
            this.panelKpi.MouseLeave += new System.EventHandler(this.panelKpi_MouseLeave);
            this.panelKpi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelKpi_MouseUp);
            // 
            // labelReportFileName2
            // 
            this.labelReportFileName2.AutoSize = true;
            this.labelReportFileName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReportFileName2.Location = new System.Drawing.Point(271, 425);
            this.labelReportFileName2.Name = "labelReportFileName2";
            this.labelReportFileName2.Size = new System.Drawing.Size(83, 13);
            this.labelReportFileName2.TabIndex = 12;
            this.labelReportFileName2.Text = "ReportFileName";
            this.labelReportFileName2.Visible = false;
            // 
            // labelKpiFileName2
            // 
            this.labelKpiFileName2.AutoSize = true;
            this.labelKpiFileName2.BackColor = System.Drawing.SystemColors.Window;
            this.labelKpiFileName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKpiFileName2.Location = new System.Drawing.Point(172, 425);
            this.labelKpiFileName2.Name = "labelKpiFileName2";
            this.labelKpiFileName2.Size = new System.Drawing.Size(66, 13);
            this.labelKpiFileName2.TabIndex = 11;
            this.labelKpiFileName2.Text = "KpiFileName";
            this.labelKpiFileName2.Visible = false;
            // 
            // btnReport
            // 
            this.btnReport.AllowDrop = true;
            this.btnReport.Image = global::Bonuses.View.Properties.Resources.WordLogo_BW;
            this.btnReport.Location = new System.Drawing.Point(534, 170);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(148, 174);
            this.btnReport.TabIndex = 10;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.BtnReport_Click);
            this.btnReport.DragDrop += new System.Windows.Forms.DragEventHandler(this.BtnReport_DragDrop);
            this.btnReport.DragEnter += new System.Windows.Forms.DragEventHandler(this.BtnReport_DragEnter);
            // 
            // btnKpi
            // 
            this.btnKpi.AllowDrop = true;
            this.btnKpi.Image = global::Bonuses.View.Properties.Resources.ExcelLogo_BW;
            this.btnKpi.Location = new System.Drawing.Point(353, 170);
            this.btnKpi.Name = "btnKpi";
            this.btnKpi.Size = new System.Drawing.Size(148, 174);
            this.btnKpi.TabIndex = 9;
            this.btnKpi.UseVisualStyleBackColor = true;
            this.btnKpi.Click += new System.EventHandler(this.BtnKpi_Click);
            this.btnKpi.DragDrop += new System.Windows.Forms.DragEventHandler(this.BtnKpi_DragDrop);
            this.btnKpi.DragEnter += new System.Windows.Forms.DragEventHandler(this.BtnKpi_DragEnter);
            // 
            // labelReport
            // 
            this.labelReport.AutoSize = true;
            this.labelReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReport.Location = new System.Drawing.Point(543, 138);
            this.labelReport.Name = "labelReport";
            this.labelReport.Size = new System.Drawing.Size(125, 20);
            this.labelReport.TabIndex = 8;
            this.labelReport.Text = "О показателях:";
            // 
            // labelKpi
            // 
            this.labelKpi.AutoSize = true;
            this.labelKpi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKpi.Location = new System.Drawing.Point(408, 138);
            this.labelKpi.Name = "labelKpi";
            this.labelKpi.Size = new System.Drawing.Size(38, 20);
            this.labelKpi.TabIndex = 7;
            this.labelKpi.Text = "KPI:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.Navy;
            this.btnCancel.Location = new System.Drawing.Point(445, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 64);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(353, 393);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(148, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // panelDetections
            // 
            this.panelDetections.Controls.Add(this.btnCancelDetections);
            this.panelDetections.Controls.Add(this.btnSaveDetections);
            this.panelDetections.Controls.Add(this.tableDetections);
            this.panelDetections.Location = new System.Drawing.Point(200, 23);
            this.panelDetections.Name = "panelDetections";
            this.panelDetections.Size = new System.Drawing.Size(1046, 669);
            this.panelDetections.TabIndex = 5;
            this.panelDetections.Visible = false;
            // 
            // btnCancelDetections
            // 
            this.btnCancelDetections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelDetections.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancelDetections.ForeColor = System.Drawing.Color.Navy;
            this.btnCancelDetections.Location = new System.Drawing.Point(505, 500);
            this.btnCancelDetections.Name = "btnCancelDetections";
            this.btnCancelDetections.Size = new System.Drawing.Size(148, 64);
            this.btnCancelDetections.TabIndex = 3;
            this.btnCancelDetections.Text = "Отмена";
            this.btnCancelDetections.UseVisualStyleBackColor = true;
            this.btnCancelDetections.Click += new System.EventHandler(this.BtnCancelDetections_Click);
            // 
            // btnSaveDetections
            // 
            this.btnSaveDetections.BackColor = System.Drawing.Color.Navy;
            this.btnSaveDetections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDetections.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveDetections.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSaveDetections.Location = new System.Drawing.Point(346, 500);
            this.btnSaveDetections.Name = "btnSaveDetections";
            this.btnSaveDetections.Size = new System.Drawing.Size(148, 64);
            this.btnSaveDetections.TabIndex = 2;
            this.btnSaveDetections.Text = "Сохранить";
            this.btnSaveDetections.UseVisualStyleBackColor = false;
            this.btnSaveDetections.Click += new System.EventHandler(this.BtnSaveDetections_Click);
            // 
            // tableDetections
            // 
            this.tableDetections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableDetections.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableDetections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableDetections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDetections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableDetections.DefaultCellStyle = dataGridViewCellStyle2;
            this.tableDetections.Location = new System.Drawing.Point(63, 78);
            this.tableDetections.Name = "tableDetections";
            this.tableDetections.RowTemplate.Height = 30;
            this.tableDetections.Size = new System.Drawing.Size(900, 388);
            this.tableDetections.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Название";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // panelEmployees
            // 
            this.panelEmployees.Controls.Add(this.btnCancelEmployees);
            this.panelEmployees.Controls.Add(this.btnSaveEmployees);
            this.panelEmployees.Controls.Add(this.tableEmployees);
            this.panelEmployees.Location = new System.Drawing.Point(200, 23);
            this.panelEmployees.Name = "panelEmployees";
            this.panelEmployees.Size = new System.Drawing.Size(1046, 669);
            this.panelEmployees.TabIndex = 7;
            this.panelEmployees.Visible = false;
            // 
            // btnCancelEmployees
            // 
            this.btnCancelEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEmployees.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancelEmployees.ForeColor = System.Drawing.Color.Navy;
            this.btnCancelEmployees.Location = new System.Drawing.Point(505, 500);
            this.btnCancelEmployees.Name = "btnCancelEmployees";
            this.btnCancelEmployees.Size = new System.Drawing.Size(148, 64);
            this.btnCancelEmployees.TabIndex = 6;
            this.btnCancelEmployees.Text = "Отмена";
            this.btnCancelEmployees.UseVisualStyleBackColor = true;
            this.btnCancelEmployees.Click += new System.EventHandler(this.BtnCancelEmployees_Click);
            // 
            // btnSaveEmployees
            // 
            this.btnSaveEmployees.BackColor = System.Drawing.Color.Navy;
            this.btnSaveEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEmployees.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveEmployees.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSaveEmployees.Location = new System.Drawing.Point(346, 500);
            this.btnSaveEmployees.Name = "btnSaveEmployees";
            this.btnSaveEmployees.Size = new System.Drawing.Size(148, 64);
            this.btnSaveEmployees.TabIndex = 5;
            this.btnSaveEmployees.Text = "Сохранить";
            this.btnSaveEmployees.UseVisualStyleBackColor = false;
            this.btnSaveEmployees.Click += new System.EventHandler(this.BtnSaveEmployees_Click);
            // 
            // tableEmployees
            // 
            this.tableEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableEmployees.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tableEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tableEmployees.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableEmployees.DefaultCellStyle = dataGridViewCellStyle4;
            this.tableEmployees.Location = new System.Drawing.Point(63, 78);
            this.tableEmployees.Name = "tableEmployees";
            this.tableEmployees.RowTemplate.Height = 30;
            this.tableEmployees.Size = new System.Drawing.Size(900, 388);
            this.tableEmployees.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Имя";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Должность";
            this.Column2.Name = "Column2";
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.btnChooseDirectoryReport);
            this.panelSettings.Controls.Add(this.btnChooseDirectoryKpi);
            this.panelSettings.Controls.Add(this.btnCancelSettings);
            this.panelSettings.Controls.Add(this.btnSaveSettings);
            this.panelSettings.Controls.Add(this.tbReportSourceDirectory);
            this.panelSettings.Controls.Add(this.tbKpiSouceDirectory);
            this.panelSettings.Controls.Add(this.labelReportSourceDirectory);
            this.panelSettings.Controls.Add(this.labelKpiSouceDirectory);
            this.panelSettings.Location = new System.Drawing.Point(200, 23);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(1046, 669);
            this.panelSettings.TabIndex = 8;
            // 
            // btnChooseDirectoryReport
            // 
            this.btnChooseDirectoryReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChooseDirectoryReport.Location = new System.Drawing.Point(734, 244);
            this.btnChooseDirectoryReport.Name = "btnChooseDirectoryReport";
            this.btnChooseDirectoryReport.Size = new System.Drawing.Size(75, 26);
            this.btnChooseDirectoryReport.TabIndex = 10;
            this.btnChooseDirectoryReport.Text = "...";
            this.btnChooseDirectoryReport.UseVisualStyleBackColor = true;
            this.btnChooseDirectoryReport.Click += new System.EventHandler(this.BtnChooseReportDirectory_Click);
            // 
            // btnChooseDirectoryKpi
            // 
            this.btnChooseDirectoryKpi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChooseDirectoryKpi.Location = new System.Drawing.Point(734, 122);
            this.btnChooseDirectoryKpi.Name = "btnChooseDirectoryKpi";
            this.btnChooseDirectoryKpi.Size = new System.Drawing.Size(75, 26);
            this.btnChooseDirectoryKpi.TabIndex = 9;
            this.btnChooseDirectoryKpi.Text = "...";
            this.btnChooseDirectoryKpi.UseVisualStyleBackColor = true;
            this.btnChooseDirectoryKpi.Click += new System.EventHandler(this.BtnChooseKpiDirectory_Click);
            // 
            // btnCancelSettings
            // 
            this.btnCancelSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelSettings.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancelSettings.ForeColor = System.Drawing.Color.Navy;
            this.btnCancelSettings.Location = new System.Drawing.Point(505, 500);
            this.btnCancelSettings.Name = "btnCancelSettings";
            this.btnCancelSettings.Size = new System.Drawing.Size(148, 64);
            this.btnCancelSettings.TabIndex = 8;
            this.btnCancelSettings.Text = "Отмена";
            this.btnCancelSettings.UseVisualStyleBackColor = true;
            this.btnCancelSettings.Click += new System.EventHandler(this.btnCancelSettings_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.Navy;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveSettings.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSaveSettings.Location = new System.Drawing.Point(346, 500);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(148, 64);
            this.btnSaveSettings.TabIndex = 7;
            this.btnSaveSettings.Text = "Сохранить";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // tbReportSourceDirectory
            // 
            this.tbReportSourceDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbReportSourceDirectory.Location = new System.Drawing.Point(175, 244);
            this.tbReportSourceDirectory.Name = "tbReportSourceDirectory";
            this.tbReportSourceDirectory.Size = new System.Drawing.Size(552, 26);
            this.tbReportSourceDirectory.TabIndex = 3;
            // 
            // tbKpiSouceDirectory
            // 
            this.tbKpiSouceDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKpiSouceDirectory.Location = new System.Drawing.Point(172, 122);
            this.tbKpiSouceDirectory.Name = "tbKpiSouceDirectory";
            this.tbKpiSouceDirectory.Size = new System.Drawing.Size(555, 26);
            this.tbKpiSouceDirectory.TabIndex = 2;
            // 
            // labelReportSourceDirectory
            // 
            this.labelReportSourceDirectory.AutoSize = true;
            this.labelReportSourceDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReportSourceDirectory.Location = new System.Drawing.Point(172, 212);
            this.labelReportSourceDirectory.Name = "labelReportSourceDirectory";
            this.labelReportSourceDirectory.Size = new System.Drawing.Size(421, 20);
            this.labelReportSourceDirectory.TabIndex = 1;
            this.labelReportSourceDirectory.Text = "Исходная папка для файла \"О показателях (шаблон)\"";
            // 
            // labelKpiSouceDirectory
            // 
            this.labelKpiSouceDirectory.AutoSize = true;
            this.labelKpiSouceDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKpiSouceDirectory.Location = new System.Drawing.Point(169, 90);
            this.labelKpiSouceDirectory.Name = "labelKpiSouceDirectory";
            this.labelKpiSouceDirectory.Size = new System.Drawing.Size(261, 20);
            this.labelKpiSouceDirectory.TabIndex = 0;
            this.labelKpiSouceDirectory.Text = "Исходная папка для файла \"KPI\"";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Выберите папку:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem,
            this.refItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1247, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItem
            // 
            this.menuItem.AutoSize = false;
            this.menuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateItem,
            this.importKpiItem,
            this.importReportItem,
            this.changeGroupItem,
            this.exitItem});
            this.menuItem.Name = "menuItem";
            this.menuItem.Size = new System.Drawing.Size(80, 20);
            this.menuItem.Text = "Меню";
            // 
            // updateItem
            // 
            this.updateItem.Name = "updateItem";
            this.updateItem.Size = new System.Drawing.Size(286, 22);
            this.updateItem.Text = "Обновить";
            // 
            // importKpiItem
            // 
            this.importKpiItem.Name = "importKpiItem";
            this.importKpiItem.Size = new System.Drawing.Size(286, 22);
            this.importKpiItem.Text = "Импортировать файл \"KPI\"";
            // 
            // importReportItem
            // 
            this.importReportItem.Name = "importReportItem";
            this.importReportItem.Size = new System.Drawing.Size(286, 22);
            this.importReportItem.Text = "Импортировать файл \"О показателях\"";
            // 
            // changeGroupItem
            // 
            this.changeGroupItem.Name = "changeGroupItem";
            this.changeGroupItem.Size = new System.Drawing.Size(286, 22);
            this.changeGroupItem.Text = "Переименовать отдел";
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(286, 22);
            this.exitItem.Text = "Выход";
            // 
            // refItem
            // 
            this.refItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualItem,
            this.aboutItem});
            this.refItem.Name = "refItem";
            this.refItem.Size = new System.Drawing.Size(65, 20);
            this.refItem.Text = "Справка";
            // 
            // manualItem
            // 
            this.manualItem.Name = "manualItem";
            this.manualItem.Size = new System.Drawing.Size(149, 22);
            this.manualItem.Text = "Инструкция";
            // 
            // aboutItem
            // 
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(149, 22);
            this.aboutItem.Text = "О программе";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1247, 669);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelEmployees);
            this.Controls.Add(this.panelDetections);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подсчёт точечного премирования";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelDetections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableDetections)).EndInit();
            this.panelEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableEmployees)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnDetections;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelDetections;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnCancelDetections;
        private System.Windows.Forms.Button btnSaveDetections;
        private System.Windows.Forms.DataGridView tableDetections;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Button btnApplyGroup;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Panel panelEmployees;
        private System.Windows.Forms.Button btnCancelEmployees;
        private System.Windows.Forms.Button btnSaveEmployees;
        private System.Windows.Forms.DataGridView tableEmployees;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelGroup;
        private System.Windows.Forms.Button btnCancelGroup;
        private System.Windows.Forms.Label labelReport;
        private System.Windows.Forms.Label labelKpi;
        private System.Windows.Forms.Button btnKpi;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label labelKpiFileName2;
        private System.Windows.Forms.Label labelReportFileName2;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Button btnCancelSettings;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox tbReportSourceDirectory;
        private System.Windows.Forms.TextBox tbKpiSouceDirectory;
        private System.Windows.Forms.Label labelReportSourceDirectory;
        private System.Windows.Forms.Label labelKpiSouceDirectory;
        private System.Windows.Forms.Panel panelKpi;
        private System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.Label labelKpiFileName;
        private System.Windows.Forms.Button btnChooseDirectoryReport;
        private System.Windows.Forms.Button btnChooseDirectoryKpi;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label labelReportFileName;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItem;
        private System.Windows.Forms.ToolStripMenuItem updateItem;
        private System.Windows.Forms.ToolStripMenuItem importKpiItem;
        private System.Windows.Forms.ToolStripMenuItem importReportItem;
        private System.Windows.Forms.ToolStripMenuItem changeGroupItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.ToolStripMenuItem refItem;
        private System.Windows.Forms.ToolStripMenuItem manualItem;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
    }
}

