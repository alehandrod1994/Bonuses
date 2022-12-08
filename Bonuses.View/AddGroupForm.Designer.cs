
namespace Bonuses.View
{
    partial class AddGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGroupForm));
            this.btnSaveGroup = new System.Windows.Forms.Button();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSaveGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGroup.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveGroup.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSaveGroup.Location = new System.Drawing.Point(216, 255);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(160, 55);
            this.btnSaveGroup.TabIndex = 0;
            this.btnSaveGroup.Text = "Сохранить";
            this.btnSaveGroup.UseVisualStyleBackColor = false;
            this.btnSaveGroup.Click += new System.EventHandler(this.BtnSaveGroup_Click);
            // 
            // tbGroup
            // 
            this.tbGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbGroup.Location = new System.Drawing.Point(84, 146);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(427, 26);
            this.tbGroup.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(80, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите название отдела:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.labelHelp.TabIndex = 26;
            this.labelHelp.Text = "Нужна помощь?";
            this.labelHelp.Click += new System.EventHandler(this.labelHelp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bonuses.View.Properties.Resources.NewGroup3;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(80, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(431, 27);
            this.labelTitle.TabIndex = 31;
            this.labelTitle.Text = "Добавление отдела";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGroup);
            this.Controls.Add(this.btnSaveGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление отдела";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddGroupForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveGroup;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTitle;
    }
}