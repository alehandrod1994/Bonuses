using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class WarningForm : Form
    {
        private readonly string _help;

        public WarningForm(string warningDescription, string help) : this("Ошибка!", warningDescription, help) { }

        public WarningForm(string warningTitle, string warningDescription, string help)
        {
            InitializeComponent();

            _help = help;
            labelWarningTitle.Text = warningTitle;
            labelWarningDescription.Text = warningDescription;
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
