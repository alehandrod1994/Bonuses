using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class SuccessfullyForm : Form
    {
        public SuccessfullyForm(string newPath)
        {
            InitializeComponent();
        }

        private void labelHelp_Click(object sender, EventArgs e)
        {
            string key = labelTitle.Text;
            // TODO: открытие инструкции.
            // TODO: поиск в инструкции key или по ссылке.
        }
    }
}
