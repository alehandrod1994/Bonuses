using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bonuses.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bonuses.BL.Model;

namespace Bonuses.BL.Controller.Tests
{
    [TestClass()]
    public class EmployeeControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var name = Guid.NewGuid().ToString();
            var position = new Position(Guid.NewGuid().ToString());
            var employee = new Employee(name, position);

            var employeeController = new EmployeeController();

            // Act
            employeeController.Add(employee);

            // Assert
            Assert.AreEqual(name, employeeController.Employees.Last().Name);
            Assert.AreEqual(position, employeeController.Employees.Last().Position);
        }

        [TestMethod()]
        public void TryGetEmployeeTest()
        {
            // Arrange
            var employees = new List<Employee>();
            var rnd = new Random();
            int number = rnd.Next(1, 10);

            for (int i = 0; i < number; i++)
            {
                var name = Guid.NewGuid().ToString();
                var position = new Position(Guid.NewGuid().ToString());
                employees.Add(new Employee(name, position));
            }

            var employeeController = new EmployeeController();
            employeeController.Employees = employees;

            number = rnd.Next(1, number);
            var employeeName = employees[number - 1].Name;
            var actualEmployee = new Employee("Иван", new Position("Рабочий"));

            // Act			
            if (employeeController.TryGetEmployee(employeeName, out Employee employee))
            {
                actualEmployee = employee;
            }

            // Assert
            Assert.AreEqual(employeeName, actualEmployee.Name);

        }

        [TestMethod()]
        public void ReWriteTest()
        {
            // Arrange
            var employees = new List<Employee>();
            var rnd = new Random();
            int number = rnd.Next(1, 10);

            for (int i = 0; i < number; i++)
            {
                var name = Guid.NewGuid().ToString();
                var position = new Position(Guid.NewGuid().ToString());
                employees.Add(new Employee(name, position));
            }

            var employeeController = new EmployeeController();

            // Act				
            employeeController.ReWrite(employees);

            // Assert
            Assert.AreEqual(employees.Count, employeeController.Employees.Count);
            for (int i = 0; i < employees.Count; i++)
            {
                Assert.AreEqual(employees[i], employeeController.Employees[i]);
            }
        }

    }
}