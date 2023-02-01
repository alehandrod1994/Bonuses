using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bonuses.BL.Controller;
using System;
using System.Collections.Generic;
using Bonuses.BL.Model;

namespace Bonuses.BL.Controller.Tests
{
    [TestClass()]
    public class DetectionControllerTests
    {
        [TestMethod()]
        public void ReWriteTest()
        {
            // Arrange
            var detections = new List<Detection>();
            var rnd = new Random();
            int number = rnd.Next(1, 10);

            for (int i = 0; i < number; i++)
            {
                var name = Guid.NewGuid().ToString();
                var description = Guid.NewGuid().ToString();
                detections.Add(new Detection(name, description));
            }

            var detectionController = new DetectionController();

            // Act				
            detectionController.ReWrite(detections);

            // Assert
            Assert.AreEqual(detections.Count, detectionController.Detections.Count);
            for (int i = 0; i < detections.Count; i++)
            {
                Assert.AreEqual(detections[i], detectionController.Detections[i]);
            }
        }

    }
}