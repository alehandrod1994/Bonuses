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
    public class ReportControllerTests
    {       
        [TestMethod()]
        public void StartBonusesReportTest()
        {
            // Arrange
            string keyFolder = "KPI";
            string month = DateTime.Today.Month.ToString();
            int loading = 0;

            var kpiController = new KpiController();
            var reportController = new ReportController();
            var employeeController = new EmployeeController();
            var detections = new DetectionController().Detections;
            var group = new Group();
            var date = new Date();
            date.SelectedMonth = date.Months[DateTime.Today.Month];
            date.SelectedYear = DateTime.Today.Year;

            var status = Status.Start;
            var progress = new Progress<int>(value => loading = value);

            kpiController.AutoImportKpi(keyFolder, month, month);
            reportController.AutoImportReport(keyFolder, month, "О ПОКАЗАТЕЛЯХ (ШАБЛОН)");

            // Act	
            status = kpiController.StartCalculateBonuses(employeeController, detections, status, progress);
            loading = 0;
            status = reportController.StartBonusesReport(kpiController.Bonuses, group, date,progress);

            // Assert
            Assert.AreEqual(Status.Success, status);
            Assert.IsNotNull(reportController.NewFilePath);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            string newSourceDirectory = Guid.NewGuid().ToString();
            var report = new Report() { SourceDirectory = newSourceDirectory };
            var reportController = new ReportController();

            // Act
            reportController.Save(report);
            report = new ReportController().Report;

            // Assert
            Assert.AreEqual(newSourceDirectory, report.SourceDirectory);
        }
    }
}