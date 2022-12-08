
namespace Bonuses.View
{
    partial class NoticeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoticeForm));
            this.labelNoticeTitle = new System.Windows.Forms.Label();
            this.labelNoticeDescription = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.labelHelp = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNoticeTitle
            // 
            this.labelNoticeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNoticeTitle.Location = new System.Drawing.Point(80, 10);
            this.labelNoticeTitle.Name = "labelNoticeTitle";
            this.labelNoticeTitle.Size = new System.Drawing.Size(431, 27);
            this.labelNoticeTitle.TabIndex = 20;
            this.labelNoticeTitle.Text = "Ошибка!";
            this.labelNoticeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelNoticeDescription
            // 
            this.labelNoticeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNoticeDescription.Location = new System.Drawing.Point(80, 85);
            this.labelNoticeDescription.Name = "labelNoticeDescription";
            this.labelNoticeDescription.Size = new System.Drawing.Size(430, 123);
            this.labelNoticeDescription.TabIndex = 21;
            this.labelNoticeDescription.Text = "Информация";
            this.labelNoticeDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOK.Location = new System.Drawing.Point(216, 255);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(160, 55);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.labelHelp.TabIndex = 25;
            this.labelHelp.Text = "Нужна помощь?";
            this.labelHelp.Click += new System.EventHandler(this.labelHelp_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bonuses.View.Properties.Resources.notice2;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // NoticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelNoticeTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelNoticeDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoticeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Уведомление";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNoticeTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelNoticeDescription;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labelHelp;
    }
}