using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using NumericSequenceCalculator.Controllers;
using NumericSequenceCalculator.Models;
using NumericSequenceCalculator.Service;
using System.Web;
using Rhino.Mocks;
using System.Collections.Specialized;
using System.Web.Routing;

namespace NumericSequenceCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var request = MockRepository.GenerateMock<HttpRequestBase>();//create mocks for HttpRequest base
            var context = MockRepository.GenerateMock<HttpContextBase>();//create mocks for HttpRequest base

            var collection = new NameValueCollection();
            collection.Add("Id", "1");
            collection.Add("UserName", "");

            context.Expect(c => c.Request).Return(request).Repeat.Any();
            request.Expect(r => r.Params).Return(collection).Repeat.Any();
            var controller = new HomeController();
            controller.ControllerContext = new ControllerContext(context, new RouteData(), controller);

            var result = controller.Index();

            context.VerifyAllExpectations();
            request.VerifyAllExpectations();
        }

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
