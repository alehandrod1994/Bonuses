
namespace Bonuses.View
{
    partial class AddNewEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewEmployeeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveEmployee = new System.Windows.Forms.Button();
            this.cbPositions = new System.Windows.Forms.ComboBox();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(80, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Добавление нового сотрудника";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveEmployee
            // 
            this.btnSaveEmployee.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSaveEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEmployee.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveEmployee.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSaveEmployee.Location = new System.Drawing.Point(216, 255);
            this.btnSaveEmployee.Name = "btnSaveEmployee";
            this.btnSaveEmployee.Size = new System.Drawing.Size(160, 55);
            this.btnSaveEmployee.TabIndex = 3;
            this.btnSaveEmployee.Text = "Сохранить";
            this.btnSaveEmployee.UseVisualStyleBackColor = false;
            this.btnSaveEmployee.Click += new System.EventHandler(this.BtnSaveEmployee_Click);
            // 
            // cbPositions
            // 
            this.cbPositions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPositions.FormattingEnabled = true;
            this.cbPositions.Location = new System.Drawing.Point(83, 163);
            this.cbPositions.Name = "cbPositions";
            this.cbPositions.Size = new System.Drawing.Size(427, 28);
            this.cbPositions.TabIndex = 6;
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoEllipsis = true;
            this.labelEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEmployee.Location = new System.Drawing.Point(79, 122);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(430, 26);
            this.labelEmployee.TabIndex = 7;
            this.labelEmployee.Text = "Имя сотрудника";
            this.labelEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelHelp.Location = new System.Drawing.Point(432, 276);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(110, 16);
            this.labelHelp.TabIndex = 27;
            this.labelHelp.Text = "Нужна помощь?";
            this.labelHelp.Click += new System.EventHandler(this.LabelHelp_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(80, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(431, 27);
            this.label2.TabIndex = 28;
            this.label2.Text = "Обнаружен новый сотрудник. Введите его должность:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bonuses.View.Properties.Resources.NewEmployee;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // AddNewEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.cbPositions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveEmployee);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewEmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление нового сотрудника";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveEmployee;
        private System.Windows.Forms.ComboBox cbPositions;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}