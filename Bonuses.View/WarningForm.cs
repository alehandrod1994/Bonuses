using System;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class WarningForm : Form
    {
        public WarningForm(string noticeDescription)
        {
            InitializeComponent();

            labelWarningTitle.Text = "Ошибка!";
            labelWarningDescription.Text = noticeDescription;
        }

        public WarningForm(string noticeTitle, int noticeTitleHeight, string noticeDescription)
        {
            InitializeComponent();

            labelWarningTitle.Text = noticeTitle;
            labelWarningTitle.Height = noticeTitleHeight;
            labelWarningDescription.Text = noticeDescription;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelHelp_Click(object sender, EventArgs e)
        {
            string key = labelWarningTitle.Text;
            // TODO: открытие инструкции.
            // TODO: поиск в инструкции key или по ссылке.
        }
    }
}
