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
    public class KpiControllerTests
    {      
        [TestMethod()]
        public void StartCalculateBonusesTest()
        {
            // Arrange
            string keyFolder = "KPI";
            string month = DateTime.Today.Month.ToString();
            int loading = 0;

            var kpiController = new KpiController();
            var employeeController = new EmployeeController();
            var detections = new DetectionController().Detections;
            var status = Status.Start;
            var progress = new Progress<int>(value => loading = value);
            kpiController.AutoImportKpi(keyFolder, month, month);

            // Act	
            status = kpiController.StartCalculateBonuses(employeeController, detections, status, progress);

            // Assert
            Assert.AreEqual(Status.Success, status);
            Assert.IsNotNull(kpiController.Bonuses);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            string newSourceDirectory = Guid.NewGuid().ToString();
            var kpi = new Kpi() { SourceDirectory = newSourceDirectory };
            var kpiController = new KpiController();            

            // Act
            kpiController.Save(kpi);
            kpi = new KpiController().Kpi;

            // Assert
            Assert.AreEqual(newSourceDirectory, kpi.SourceDirectory);
        }
    }
}