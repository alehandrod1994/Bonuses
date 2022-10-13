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
    public partial class AddNewEmployeeForm : Form
    {
        private EmployeeController _employeeController;
        private PositionController _positionController;

        public AddNewEmployeeForm(string employeeName, EmployeeController employeeController, PositionController positionController)
        {
            InitializeComponent();

            labelEmployee.Text = employeeName;
            _employeeController = employeeController;
            _positionController = positionController;

            foreach (var position in _positionController.Positions)
            {
                cbPositions.Items.Add(position.Name);
            }          
        }

        private void btnSaveEmployee_Click(object sender, EventArgs e)
        {
            // TODO: Проверка, чтобы в начале и в конце должности не было лишних пробелов.

            var position = new Position(cbPositions.Text);
            var employee = new Employee(labelEmployee.Text, position);
            _positionController.Add(position);
            _employeeController.Add(employee);
            Close();
        }
    }
}
