
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
            this.btnSaveGroup = new System.Windows.Forms.Button();
            this.tbGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.Location = new System.Drawing.Point(55, 83);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSaveGroup.TabIndex = 0;
            this.btnSaveGroup.Text = "Сохранить";
            this.btnSaveGroup.UseVisualStyleBackColor = true;
            this.btnSaveGroup.Click += new System.EventHandler(this.BtnSaveGroup_Click);
            // 
            // tbGroup
            // 
            this.tbGroup.Location = new System.Drawing.Point(55, 44);
            this.tbGroup.Name = "tbGroup";
            this.tbGroup.Size = new System.Drawing.Size(100, 20);
            this.tbGroup.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите название отдела:";
            // 
            // AddGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 134);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGroup);
            this.Controls.Add(this.btnSaveGroup);
            this.Name = "AddGroupForm";
            this.Text = "AddGroupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveGroup;
        private System.Windows.Forms.TextBox tbGroup;
        private System.Windows.Forms.Label label1;
    }
}