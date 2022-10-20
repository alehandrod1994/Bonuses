using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class AddGroupForm : Form
    {
        private GroupController _groupController;

        public AddGroupForm(GroupController groupController)
        {
            InitializeComponent();

            _groupController = groupController;
        }

        private void BtnSaveGroup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbGroup.Text))
            {
                _groupController.Change(new Group(tbGroup.Text));
                Close();
            }
        }

        private void AddGroupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void labelHelp_Click(object sender, EventArgs e)
        {
            string key = "Добавление отдела";
            // TODO: открытие инструкции.
            // TODO: поиск в инструкции key или по ссылке.
        }
    }
}
