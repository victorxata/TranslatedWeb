using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infrastructure.CrossCutting.Localization.Unit.Tests
{
    [TestClass]
    public class CultureHelpersTests
    {
        [TestMethod]
        public void CanChangeCurrentCultureToEnglish()
        {
            // Act
            CultureHelpers.SetCulture("en");

            // Assert
            Assert.AreEqual(Thread.CurrentThread.CurrentUICulture.Name, "en-US");
        }

        [TestMethod]
        public void CanChangeCurrentCultureToSpanish()
        {
            // Act
            CultureHelpers.SetCulture("es");

            // Assert
            Assert.AreEqual(Thread.CurrentThread.CurrentUICulture.Name, "es-ES");
        }
    }
}
