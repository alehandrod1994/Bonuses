using Bonuses.BL.Controller;
using Bonuses.BL.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bonuses.View
{
    public partial class AddNewEmployeeForm : Form
    {
        private readonly EmployeeController _employeeController;
        private readonly PositionController _positionController;
        private readonly string _help;

        public AddNewEmployeeForm(EmployeeController employeeController, PositionController positionController, string help)
        {
            InitializeComponent();
         
            _employeeController = employeeController;
            _positionController = positionController;
            labelEmployee.Text = employeeController.NewEmployee;
            _help = help;

            if (_positionController.Positions.Count > 0)
            {
                foreach (var position in _positionController.Positions)
                {
                    cbPositions.Items.Add(position.Name);
                }
                cbPositions.SelectedIndex = 0;
            }            
        }

        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbPositions.Text))
            {
                cbPositions.Text = Regex.Replace(cbPositions.Text, @"\s+", " ");
                RemoveWhiteSpace(0);
                RemoveWhiteSpace(cbPositions.Text.Length - 1);

                var position = new Position(cbPositions.Text);
                var employee = new Employee(_employeeController.NewEmployee, position);
                _positionController.Add(position);
                _employeeController.Add(employee);

                Close();
            }
        }

        private void RemoveWhiteSpace(int index)
        {
            if (cbPositions.Text[index].Equals(' '))
            {
                cbPositions.Text = cbPositions.Text.Remove(index, 1);
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
