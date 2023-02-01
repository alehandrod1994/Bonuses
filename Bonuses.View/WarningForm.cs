using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class WarningForm : Form
    {
        private string _help;

        public WarningForm(string noticeDescription, string help)
        {
            InitializeComponent();

            _help = help;
            labelWarningTitle.Text = "Ошибка!";
            labelWarningDescription.Text = noticeDescription;
        }

        public WarningForm(string noticeTitle, int noticeTitleHeight, string noticeDescription, string help)
        {
            InitializeComponent();

            _help = help;
            labelWarningTitle.Text = noticeTitle;
            labelWarningTitle.Height = noticeTitleHeight;
            labelWarningDescription.Text = noticeDescription;
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
