using System.Threading;
using System.Web.Mvc;
using Infrastructure.CrossCutting.Localization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatedWeb.Controllers;

namespace TranslatedWeb.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            CultureHelpers.SetCulture("en");
            // Arrange
            controller = new HomeController();
        }

        [TestMethod]
        public void Index()
        {

            // Acts
            controller.ChangeLanguage(0);
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanIChangeTheLanguageToSpanish()
        {
            // Act
            controller.ChangeLanguage(1);
            ViewResult result = controller.Contact() as ViewResult; // just to execute filter

            // Assert
            Assert.AreEqual(Thread.CurrentThread.CurrentUICulture.DisplayName, "Spanish (Spain)");
        }

        [TestMethod]
        public void CanIChangeTheLanguageToEnglish()
        {
            // Act
            controller.ChangeLanguage(0);

            // Assert
            Assert.AreEqual(Thread.CurrentThread.CurrentUICulture.DisplayName, "English (United States)");
        }

        [TestMethod]
        public void IsTheTitleOfTheViewTranslatedToSpanish()
        {
            // Acts
            controller.ChangeLanguage(1);
            ViewResult checkThis = controller.TestLanguage();

            // Asserts
            Assert.IsNotNull(checkThis, "There is no View result to redirect to");

            Assert.AreEqual(checkThis.ViewBag.Title, "Titulo en Espanol", "The Title is not Translated to Spanish");
        }

        [TestMethod]
        public void IsTheTitleOfTheViewTranslatedToEnglish()
        {
            // Acts
            controller.ChangeLanguage(0);
            ViewResult checkThis = controller.TestLanguage();

            // Asserts
            Assert.IsNotNull(checkThis, "There is no View result to redirect to");

            Assert.AreEqual(checkThis.ViewBag.Title, "Title in English", "The Title is not Translated to English");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            controller.Dispose();
        }
    }
}
