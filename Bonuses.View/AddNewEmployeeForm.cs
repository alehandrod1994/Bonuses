using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class AddNewEmployeeForm : Form
    {
        private EmployeeController _employeeController;
        private PositionController _positionController;
        private KpiController _kpiController;

        public AddNewEmployeeForm(string employeeName, EmployeeController employeeController, PositionController positionController, KpiController kpiController)
        {
            InitializeComponent();
         
            _employeeController = employeeController;
            _positionController = positionController;
            _kpiController = kpiController;

            labelEmployee.Text = employeeName;

            foreach (var position in _positionController.Positions)
            {
                cbPositions.Items.Add(position.Name);
            }          
        }

        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            // TODO: Проверка, чтобы в начале и в конце должности не было лишних пробелов.

            if (!string.IsNullOrWhiteSpace(cbPositions.Text))
            {
                Close();

                var position = new Position(cbPositions.Text);
                var employee = new Employee(labelEmployee.Text, position);
                _positionController.Add(position);
                _employeeController.Add(employee);
            }               
        }

        private void AddNewEmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _kpiController.CancelCalculate();
        }

        private void labelHelp_Click(object sender, EventArgs e)
        {
            string key = "Добавление нового сотрудника";
            // TODO: открытие инструкции.
            // TODO: поиск в инструкции key или по ссылке.
        }
    }
}
