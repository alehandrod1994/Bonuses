using System;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class NoticeForm : Form
    {
        public NoticeForm(string noticeTitle, int noticeTitleHeight, string noticeDescription)
        {
            InitializeComponent();

            labelNoticeTitle.Text = noticeTitle;
            labelNoticeTitle.Height = noticeTitleHeight;
            labelNoticeDescription.Text = noticeDescription;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelHelp_Click(object sender, EventArgs e)
        {
            string key = labelNoticeTitle.Text;
            // TODO: открытие инструкции.
            // TODO: поиск в инструкции key или по ссылке.
        }
    }
}
