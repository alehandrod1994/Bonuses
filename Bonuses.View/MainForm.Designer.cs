
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxFiles = new System.Windows.Forms.ListBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelGroup = new System.Windows.Forms.Panel();
            this.btnCancelGroup = new System.Windows.Forms.Button();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.btnApplyGroup = new System.Windows.Forms.Button();
            this.btnChangeGroup = new System.Windows.Forms.Button();
            this.labelGroup = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDetections = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelReportFileName = new System.Windows.Forms.Label();
            this.labelKpiFileName = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnKpi = new System.Windows.Forms.Button();
            this.labelReport = new System.Windows.Forms.Label();
            this.labelKpi = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDetections = new System.Windows.Forms.Panel();
            this.btnCancelDetections = new System.Windows.Forms.Button();
            this.btnSaveDetections = new System.Windows.Forms.Button();
            this.tableDetections = new System.Windows.Forms.DataGridView();
            this.labelDetections = new System.Windows.Forms.Label();
            this.panelEmployees = new System.Windows.Forms.Panel();
            this.btnCancelEmployees = new System.Windows.Forms.Button();
            this.btnSaveEmployees = new System.Windows.Forms.Button();
            this.tableEmployees = new System.Windows.Forms.DataGridView();
            this.labelEmployees = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelGroup.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelDetections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDetections)).BeginInit();
            this.panelEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxFiles
            // 
            this.listBoxFiles.AllowDrop = true;
            this.listBoxFiles.FormattingEnabled = true;
            this.listBoxFiles.HorizontalScrollbar = true;
            this.listBoxFiles.Items.AddRange(new object[] {
            "KPI:",
            "C://",
            "",
            "О показателях (шаблон):",
            "С://"});
            this.listBoxFiles.Location = new System.Drawing.Point(580, 550);
            this.listBoxFiles.Name = "listBoxFiles";
            this.listBoxFiles.Size = new System.Drawing.Size(455, 95);
            this.listBoxFiles.TabIndex = 0;
            this.listBoxFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxFiles_DragDrop);
            this.listBoxFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBoxFiles_DragEnter);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(367, 430);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(148, 64);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Подсчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Navy;
            this.panelMenu.Controls.Add(this.panelGroup);
            this.panelMenu.Controls.Add(this.labelGroup);
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.btnDetections);
            this.panelMenu.Controls.Add(this.btnEmployees);
            this.panelMenu.Controls.Add(this.btnMain);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 669);
            this.panelMenu.TabIndex = 2;
            // 
            // panelGroup
            // 
            this.panelGroup.Controls.Add(this.btnCancelGroup);
            this.panelGroup.Controls.Add(this.tbGroup);
            this.panelGroup.Controls.Add(this.btnApplyGroup);
            this.panelGroup.Controls.Add(this.btnChangeGroup);
            this.panelGroup.Location = new System.Drawing.Point(5, 195);
            this.panelGroup.Name = "panelGroup";
            this.panelGroup.Size = new System.Drawing.Size(175, 100);
            this.panelGroup.TabIndex = 7;
            // 
            // btnCancelGroup
            // 
            this.btnCancelGroup.Location = new System.Drawing.Point(100, 60);
            this.btnCancelGroup.Name = "btnCancelGroup";
            this.btnCancelGroup.Size = new System.Drawing.Size(63, 23);
            this.btnCancelGroup.TabIndex = 7;
            this.btnCancelGroup.Text = "Отмена";
            this.btnCancelGroup.UseVisualStyleBackColor = true;
            this.btnCancelGroup.Click += new System.EventHandler(this.BtnCancelGroup_Click);
            // 
            // tbGroup
            // 
            this.tbGroup.Location = new System.Drawing.Point(3, 5);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(100, 20);
            this.tbGroup.TabIndex = 6;
            // 
            // btnApplyGroup
            // 
            this.btnApplyGroup.Location = new System.Drawing.Point(9, 60);
            this.btnApplyGroup.Name = "btnApplyGroup";
            this.btnApplyGroup.Size = new System.Drawing.Size(85, 23);
            this.btnApplyGroup.TabIndex = 5;
            this.btnApplyGroup.Text = "ОК";
            this.btnApplyGroup.UseVisualStyleBackColor = true;
            this.btnApplyGroup.Click += new System.EventHandler(this.BtnApplyGroup_Click);
            // 
            // btnChangeGroup
            // 
            this.btnChangeGroup.Location = new System.Drawing.Point(38, 31);
            this.btnChangeGroup.Name = "btnChangeGroup";
            this.btnChangeGroup.Size = new System.Drawing.Size(125, 23);
            this.btnChangeGroup.TabIndex = 3;
            this.btnChangeGroup.Text = "Изменить отдел";
            this.btnChangeGroup.UseVisualStyleBackColor = true;
            this.btnChangeGroup.Click += new System.EventHandler(this.BtnChangeGroup_Click);
            // 
            // labelGroup
            // 
            this.labelGroup.AutoEllipsis = true;
            this.labelGroup.BackColor = System.Drawing.Color.DarkOrchid;
            this.labelGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGroup.ForeColor = System.Drawing.SystemColors.Window;
            this.labelGroup.Location = new System.Drawing.Point(0, 0);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(180, 38);
            this.labelGroup.TabIndex = 4;
            this.labelGroup.Text = "Отдел";
            this.labelGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGroup.DoubleClick += new System.EventHandler(this.LabelGroup_DoubleClick);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(3, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Нарушения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btnDetections
            // 
            this.btnDetections.FlatAppearance.BorderSize = 0;
            this.btnDetections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetections.Font = new System.Drawing.Font("Bahnschrift Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDetections.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDetections.Location = new System.Drawing.Point(0, 122);
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
            this.btnEmployees.Font = new System.Drawing.Font("Bahnschrift Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmployees.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEmployees.Location = new System.Drawing.Point(0, 80);
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
            this.btnMain.Font = new System.Drawing.Font("Bahnschrift Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMain.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMain.Location = new System.Drawing.Point(0, 38);
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
            this.panelMain.Controls.Add(this.labelReportFileName);
            this.panelMain.Controls.Add(this.labelKpiFileName);
            this.panelMain.Controls.Add(this.btnReport);
            this.panelMain.Controls.Add(this.btnKpi);
            this.panelMain.Controls.Add(this.labelReport);
            this.panelMain.Controls.Add(this.labelKpi);
            this.panelMain.Controls.Add(this.btnCancel);
            this.panelMain.Controls.Add(this.progressBar1);
            this.panelMain.Controls.Add(this.tbYear);
            this.panelMain.Controls.Add(this.cbMonth);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.listBoxFiles);
            this.panelMain.Controls.Add(this.btnCalculate);
            this.panelMain.Location = new System.Drawing.Point(200, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1046, 669);
            this.panelMain.TabIndex = 3;
            // 
            // labelReportFileName
            // 
            this.labelReportFileName.AutoSize = true;
            this.labelReportFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReportFileName.Location = new System.Drawing.Point(531, 327);
            this.labelReportFileName.Name = "labelReportFileName";
            this.labelReportFileName.Size = new System.Drawing.Size(83, 13);
            this.labelReportFileName.TabIndex = 12;
            this.labelReportFileName.Text = "ReportFileName";
            // 
            // labelKpiFileName
            // 
            this.labelKpiFileName.AutoSize = true;
            this.labelKpiFileName.BackColor = System.Drawing.SystemColors.Window;
            this.labelKpiFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKpiFileName.Location = new System.Drawing.Point(350, 329);
            this.labelKpiFileName.Name = "labelKpiFileName";
            this.labelKpiFileName.Size = new System.Drawing.Size(66, 13);
            this.labelKpiFileName.TabIndex = 11;
            this.labelKpiFileName.Text = "KpiFileName";
            // 
            // btnReport
            // 
            this.btnReport.AllowDrop = true;
            this.btnReport.Image = global::Bonuses.View.Properties.Resources.WordLogo;
            this.btnReport.Location = new System.Drawing.Point(534, 170);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(148, 174);
            this.btnReport.TabIndex = 10;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            this.btnReport.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnReport_DragDrop);
            this.btnReport.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnReport_DragEnter);
            // 
            // btnKpi
            // 
            this.btnKpi.AllowDrop = true;
            this.btnKpi.Image = global::Bonuses.View.Properties.Resources.ExcelLogo;
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
            this.labelReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReport.Location = new System.Drawing.Point(543, 138);
            this.labelReport.Name = "labelReport";
            this.labelReport.Size = new System.Drawing.Size(116, 18);
            this.labelReport.TabIndex = 8;
            this.labelReport.Text = "О показателях:";
            // 
            // labelKpi
            // 
            this.labelKpi.AutoSize = true;
            this.labelKpi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKpi.Location = new System.Drawing.Point(408, 138);
            this.labelKpi.Name = "labelKpi";
            this.labelKpi.Size = new System.Drawing.Size(35, 18);
            this.labelKpi.TabIndex = 7;
            this.labelKpi.Text = "KPI:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(546, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 64);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(353, 379);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(148, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // tbYear
            // 
            this.tbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbYear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbYear.Location = new System.Drawing.Point(231, 109);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(40, 22);
            this.tbYear.TabIndex = 4;
            this.tbYear.Text = "2020";
            // 
            // cbMonth
            // 
            this.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.cbMonth.Location = new System.Drawing.Point(125, 109);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(100, 24);
            this.cbMonth.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(517, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Главная";
            // 
            // panelDetections
            // 
            this.panelDetections.Controls.Add(this.btnCancelDetections);
            this.panelDetections.Controls.Add(this.btnSaveDetections);
            this.panelDetections.Controls.Add(this.tableDetections);
            this.panelDetections.Controls.Add(this.labelDetections);
            this.panelDetections.Location = new System.Drawing.Point(200, 0);
            this.panelDetections.Name = "panelDetections";
            this.panelDetections.Size = new System.Drawing.Size(1046, 669);
            this.panelDetections.TabIndex = 5;
            this.panelDetections.Visible = false;
            // 
            // btnCancelDetections
            // 
            this.btnCancelDetections.Location = new System.Drawing.Point(309, 327);
            this.btnCancelDetections.Name = "btnCancelDetections";
            this.btnCancelDetections.Size = new System.Drawing.Size(75, 23);
            this.btnCancelDetections.TabIndex = 3;
            this.btnCancelDetections.Text = "Отмена";
            this.btnCancelDetections.UseVisualStyleBackColor = true;
            this.btnCancelDetections.Click += new System.EventHandler(this.BtnCancelDetections_Click);
            // 
            // btnSaveDetections
            // 
            this.btnSaveDetections.Location = new System.Drawing.Point(150, 327);
            this.btnSaveDetections.Name = "btnSaveDetections";
            this.btnSaveDetections.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDetections.TabIndex = 2;
            this.btnSaveDetections.Text = "Сохранить";
            this.btnSaveDetections.UseVisualStyleBackColor = true;
            this.btnSaveDetections.Click += new System.EventHandler(this.BtnSaveDetections_Click);
            // 
            // tableDetections
            // 
            this.tableDetections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableDetections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDetections.Location = new System.Drawing.Point(40, 55);
            this.tableDetections.Name = "tableDetections";
            this.tableDetections.Size = new System.Drawing.Size(488, 240);
            this.tableDetections.TabIndex = 1;
            // 
            // labelDetections
            // 
            this.labelDetections.AutoSize = true;
            this.labelDetections.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDetections.Location = new System.Drawing.Point(485, 0);
            this.labelDetections.Name = "labelDetections";
            this.labelDetections.Size = new System.Drawing.Size(126, 25);
            this.labelDetections.TabIndex = 0;
            this.labelDetections.Text = "Нарушения";
            // 
            // panelEmployees
            // 
            this.panelEmployees.Controls.Add(this.btnCancelEmployees);
            this.panelEmployees.Controls.Add(this.btnSaveEmployees);
            this.panelEmployees.Controls.Add(this.tableEmployees);
            this.panelEmployees.Controls.Add(this.labelEmployees);
            this.panelEmployees.Location = new System.Drawing.Point(200, 0);
            this.panelEmployees.Name = "panelEmployees";
            this.panelEmployees.Size = new System.Drawing.Size(1046, 669);
            this.panelEmployees.TabIndex = 7;
            this.panelEmployees.Visible = false;
            // 
            // btnCancelEmployees
            // 
            this.btnCancelEmployees.Location = new System.Drawing.Point(332, 350);
            this.btnCancelEmployees.Name = "btnCancelEmployees";
            this.btnCancelEmployees.Size = new System.Drawing.Size(75, 23);
            this.btnCancelEmployees.TabIndex = 6;
            this.btnCancelEmployees.Text = "Отмена";
            this.btnCancelEmployees.UseVisualStyleBackColor = true;
            this.btnCancelEmployees.Click += new System.EventHandler(this.BtnCancelEmployees_Click);
            // 
            // btnSaveEmployees
            // 
            this.btnSaveEmployees.Location = new System.Drawing.Point(173, 350);
            this.btnSaveEmployees.Name = "btnSaveEmployees";
            this.btnSaveEmployees.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEmployees.TabIndex = 5;
            this.btnSaveEmployees.Text = "Сохранить";
            this.btnSaveEmployees.UseVisualStyleBackColor = true;
            this.btnSaveEmployees.Click += new System.EventHandler(this.BtnSaveEmployees_Click);
            // 
            // tableEmployees
            // 
            this.tableEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableEmployees.Location = new System.Drawing.Point(63, 78);
            this.tableEmployees.Name = "tableEmployees";
            this.tableEmployees.Size = new System.Drawing.Size(488, 240);
            this.tableEmployees.TabIndex = 4;
            // 
            // labelEmployees
            // 
            this.labelEmployees.AutoSize = true;
            this.labelEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEmployees.Location = new System.Drawing.Point(480, 0);
            this.labelEmployees.Name = "labelEmployees";
            this.labelEmployees.Size = new System.Drawing.Size(131, 25);
            this.labelEmployees.TabIndex = 1;
            this.labelEmployees.Text = "Сотрудники";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bonuses.View.Properties.Resources.edit;
            this.pictureBox1.Location = new System.Drawing.Point(178, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1247, 669);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelEmployees);
            this.Controls.Add(this.panelDetections);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelGroup.ResumeLayout(false);
            this.panelGroup.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelDetections.ResumeLayout(false);
            this.panelDetections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDetections)).EndInit();
            this.panelEmployees.ResumeLayout(false);
            this.panelEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnDetections;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelDetections;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelDetections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelDetections;
        private System.Windows.Forms.Button btnSaveDetections;
        private System.Windows.Forms.DataGridView tableDetections;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Button btnChangeGroup;
        private System.Windows.Forms.Button btnApplyGroup;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelEmployees;
        private System.Windows.Forms.Button btnCancelEmployees;
        private System.Windows.Forms.Button btnSaveEmployees;
        private System.Windows.Forms.DataGridView tableEmployees;
        private System.Windows.Forms.Label labelEmployees;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelGroup;
        private System.Windows.Forms.Button btnCancelGroup;
        private System.Windows.Forms.Label labelReport;
        private System.Windows.Forms.Label labelKpi;
        private System.Windows.Forms.Button btnKpi;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label labelKpiFileName;
        private System.Windows.Forms.Label labelReportFileName;
    }
}

