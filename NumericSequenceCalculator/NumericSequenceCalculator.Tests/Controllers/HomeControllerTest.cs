using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using NumericSequenceCalculator.Controllers;
using NumericSequenceCalculator.Models;
using NumericSequenceCalculator.Service;
using System.Web;
using Rhino.Mocks;

namespace NumericSequenceCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
      
        [TestMethod]
        public void TestResetFields()
        {
            // Arrange
            var controller = new HomeController();
            // Act
            var result = (RedirectToRouteResult)controller.ResetFields();
            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
    
}
