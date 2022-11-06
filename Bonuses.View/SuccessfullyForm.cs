using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            labelPath.Text = newPath;
        }

        private void LabelHelp_Click(object sender, EventArgs e)
        {
            string key = labelTitle.Text;
            // TODO: открытие инструкции.
            // TODO: поиск в инструкции key или по ссылке.
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            string file = labelPath.Text;
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.FileName = "explorer";
            psi.Arguments = @"/n, /select, " + file;
            process.StartInfo = psi;
            process.Start();

            Close();
        }
    }
}
