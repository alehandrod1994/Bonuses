using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class AddGroupForm : Form
    {
        private readonly string _help;

        public AddGroupForm(string help)
        {
            InitializeComponent();

            _help = help;
            tbGroup.Select();
        }

        public Group Group { get; private set; }

        private void BtnSaveGroup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbGroup.Text))
            {               
                Group = new Group(tbGroup.Text);
                DialogResult = DialogResult.OK;
            }
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
