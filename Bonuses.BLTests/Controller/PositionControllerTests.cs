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
    public class PositionControllerTests
    {
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
            var positionController = new PositionController(employeeController.Employees);

            // Act				
            positionController.ReWrite(employeeController.Employees);

            // Assert
            foreach (var employee in employeeController.Employees)
            {               
                int containsPositions = 0;
                foreach (var position in positionController.Positions)
                {
                    if (position.Name == employee.Position.Name)
                    {
                        containsPositions++;
                    }
                }

                Assert.AreEqual(1, containsPositions);
            }            
        }
    }
}