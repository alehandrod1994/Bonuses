using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class SuccessfullyForm : Form
    {
        private readonly string _help;

        public SuccessfullyForm(string newPath, string help)
        {
            InitializeComponent();

            labelPath.Text = newPath;
            _help = help;
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
