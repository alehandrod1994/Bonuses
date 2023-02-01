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
    public class GroupControllerTests
    {
        [TestMethod()]
        public void ChangeTest()
        {
			// Arrange
			var name = Guid.NewGuid().ToString();
			var group = new Group(name);

			var groupController = new GroupController();

			// Act
			groupController.Change(group);

			// Assert
			Assert.AreEqual(name, groupController.Group.Name);

		}
	}
}