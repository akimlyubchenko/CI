using AirlinesTestingApp.BaseEntities;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp.Tests
{
    [TestClass]
    public class MaxAdultsAmountSelectionTest : BaseTest
    {
        private TicketsPage ticketsPage;

        [TestMethod]
        public void MaxAdultsAmountSelect()
        {
            _1_OpenTicketsOrderingPage();

            _2_SetAdultsAmountEqualToMaxAllowedAndClickIncrementButton();

            _3_AssertErrorMessage();
        }

        private void _1_OpenTicketsOrderingPage()
        {
            ticketsPage = new TicketsPage();
            ticketsPage.OpenTicketsPage();
        }

        private void _2_SetAdultsAmountEqualToMaxAllowedAndClickIncrementButton()
        {
            ticketsPage.ClickPassengersInput();
            ticketsPage.ClickAdultsIncreasingButton(9);
        }

        private void _3_AssertErrorMessage()
        {
            var errorMessageForm = ticketsPage.GetElement(ticketsPage.errorFormMessage);
            Assert.AreEqual(ticketsPage.errorPassengersTooManyText, errorMessageForm.Text);
        }
    }
}
