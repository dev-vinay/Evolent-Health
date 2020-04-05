using System.Web.Mvc;
using EHI.WebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EHI.WebApp.Tests.Controllers {
    [TestClass()]
    public class PatientControllerTests {
        private PatientController _patientController;
        public PatientControllerTests() {
            _patientController = new PatientController();
        }

        [TestMethod()]
        public void IndexTest() {
            ViewResult result = null;// _patientController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DetailsTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1() {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1() {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest() {
            Assert.Fail();
        }
    }
}