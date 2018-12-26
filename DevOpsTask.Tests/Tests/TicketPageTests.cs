using System;
using System.Threading;
using DevOpsTask.Tests.Drivers;
using DevOpsTask.Tests.Site;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevOpsTask.Tests
{
    [TestClass]
    public class TicketPageTests
    {
        [TestMethod]
        public void OneCanFindTicketsFromMinskToMoscow()
        {
            var driver = MyChromeDriver.GetDriver();

            var page = new TicketPage(driver.Instance);
            page.Open();
            page.InitFrom("Minsk");
            page.InitTo("Moscow");
            Assert.IsTrue(page.ResultsFound());
        }

        [TestMethod]
        public void OneCantFindTicketsFromMinskToDenver()
        {

            var driver = MyChromeDriver.GetDriver();

            var page = new TicketPage(driver.Instance);
            page.Open();
            page.InitFrom("Minsk");
            page.InitTo("Denver");
            Assert.IsFalse(page.ResultsFound());
        }

        [TestMethod]
        public void OneCanSpecifyBackDateWhenOneWayNotSelected()
        {
            var driver = MyChromeDriver.GetDriver();

            var page = new TicketPage(driver.Instance);
            page.Open();
            page.ClickOneWay();
            Assert.IsTrue(page.IsReturnDateVisible());
        }

        [TestMethod]
        public void OneCantSpecifyBackDateWhenOneWaSelected()
        {
            var driver = MyChromeDriver.GetDriver();

            var page = new TicketPage(driver.Instance);
            page.Open();
            Assert.IsFalse(page.IsReturnDateVisible());
        }

        [TestMethod]
        public void OneCanLogin()
        {
           
            var driver = MyChromeDriver.GetDriver();

            var page = new TicketPage(driver.Instance);

            page.Open();

            try
            {
                page.ClickLogoutButton();
            }
            catch (Exception) { }

            page.ClickLoginButton();
            page.EnterLogin("akim_lyubchenko@mail.ru");
            page.EnterPassword("akim_lyubchenko");
            page.ClickLoginButton();
            Assert.AreEqual(expected: "AKIM", actual: page.UserName.ToUpper());
            Assert.IsTrue(page.Authorized);
        }

        [TestMethod]
        public void OneCanLogout()
        {
            var driver = MyChromeDriver.GetDriver();

            var page = new TicketPage(driver.Instance);
            page.Open();

            try
            {
                page.ClickLogoutButton();
            }
            catch (Exception) { }

            page.ClickLoginButton();
            page.EnterLogin("akim_lyubchenko@mail.ru");
            page.EnterPassword("akim_lyubchenko");
            page.ClickLoginButton();
            page.ClickLogoutButton();
            Assert.IsFalse(page.Authorized);
        }
    }
}
