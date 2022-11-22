using Bonuses.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bonuses.BL.Controller
{
    public class EmployeeController : ControllerBase
    {
        public EmployeeController()
        {
            Employees = GetEmployees();
        }

        public List<Employee> Employees { get; set; }
        public string NewEmployee { get; set; } = "";


        public event EventHandler OnNewEmployeeAdded;

        public void Add(Employee employee)
        {
            Employees.Add(employee);
            NewEmployee = "";
            Save();          
            OnNewEmployeeAdded?.Invoke(employee, null);
        }

        public bool TryGetEmployee(string employeeName, out Employee employee)
        {
            employee = Employees.FirstOrDefault(e => e.Name == employeeName);
            if (employee == null)
            {
                return false;
            }

            return true;
        }

        public void ReWrite(List<Employee> employees)
        {
            Employees = employees;
            Save();
        }

        private List<Employee> GetEmployees()
        {
            //var employees = new List<Employee>();
            //using (var sr = new StreamReader("Employees.txt", Encoding.UTF8))
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        string item = sr.ReadLine();
            //        int index = item.IndexOf("=");
            //        string name = item.Substring(0, index);
            //        string position = item.Substring(index + 1);
            //        var employee = new Employee(name, position);
            //        employees.Add(employee);
            //    }

            //    return employees;
            //}

            return Load<Employee>() ?? new List<Employee>();
        }

        private void Save()
        {
            //using (var sw = new StreamWriter("Employees.txt", true, Encoding.UTF8))
            //{
            //    sw.WriteLine("Бизюр Ольга Викторовна=Диспетчер ГПУ ОТБ отдела ИТСБ СТАБ");
            //}

            Save(Employees);
        }

       
    }
}
