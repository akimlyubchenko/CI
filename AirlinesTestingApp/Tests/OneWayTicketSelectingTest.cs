using AirlinesTestingApp.BaseEntities;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp
{
    [TestClass]
    public class OneWayTicketSelectingTest : BaseTest
    {
            private HomePage homePage;

            [TestMethod]
            public void SelectOneWayTicketAndAssertReturningDateDisabled()
            {
                _1_OpenHomePageAndSelectOneWayTicket();

                _2_AssertDisabledFields();
            }

        private void _1_OpenHomePageAndSelectOneWayTicket()
        {
            var homePage = new HomePage();
            homePage.OpenHomePage();
            homePage.CloseAds();
            homePage.SelectOneWayTicket();
            this.homePage = homePage;
        }

        private void _2_AssertDisabledFields()
        {
            AssertDateFieldDisabled();
            AssertProximityFieldDisabled();
        }

        private void AssertDateFieldDisabled()
        {
            var dateField = homePage.GetReturnTicketDate();
            Assert.AreEqual(false, dateField.Enabled);
        }

        private void AssertProximityFieldDisabled()
        {
            var proximityField = homePage.GetReturnTicketProximity();
            var classNames = proximityField.GetAttribute("className");
            Assert.AreEqual(true, classNames.Contains("disabled"));
        }
    }
}
