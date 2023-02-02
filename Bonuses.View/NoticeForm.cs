using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class NoticeForm : Form
    {
        private readonly string _help;

        public NoticeForm(string noticeDescription, string help)
        {
            InitializeComponent();

            _help = help;
            labelNoticeTitle.Text = "Уведомление";
            labelNoticeDescription.Text = noticeDescription;            
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LabelHelp_Click(object sender, EventArgs e)
        {
            var manualController = new ManualController();

            if (manualController.OpenManual(_help) == Status.Failed)
            {
                var form = new WarningForm("Не удалось открыть инструкцию.", null);
                form.Show();
            }
        }
    }
}
