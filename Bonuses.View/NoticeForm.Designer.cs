﻿
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
            this.labelNoticeTitle = new System.Windows.Forms.Label();
            this.labelNoticeDescription = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNoticeTitle
            // 
            this.labelNoticeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNoticeTitle.Location = new System.Drawing.Point(77, 9);
            this.labelNoticeTitle.Name = "labelNoticeTitle";
            this.labelNoticeTitle.Size = new System.Drawing.Size(320, 27);
            this.labelNoticeTitle.TabIndex = 20;
            this.labelNoticeTitle.Text = "Ошибка!";
            this.labelNoticeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelNoticeDescription
            // 
            this.labelNoticeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNoticeDescription.Location = new System.Drawing.Point(77, 36);
            this.labelNoticeDescription.Name = "labelNoticeDescription";
            this.labelNoticeDescription.Size = new System.Drawing.Size(320, 63);
            this.labelNoticeDescription.TabIndex = 21;
            this.labelNoticeDescription.Text = "Информация";
            this.labelNoticeDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(197, 123);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // NoticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 171);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelNoticeTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelNoticeDescription);
            this.Name = "NoticeForm";
            this.Text = "NoticeForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNoticeTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelNoticeDescription;
        private System.Windows.Forms.Button btnOK;
    }
}