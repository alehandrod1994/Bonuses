using Bonuses.BL.Controller;
using Bonuses.BL.Model;
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
            _groupController.Change(new Group(tbGroup.Text));
            this.Close();
        }

        private void AddGroupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
