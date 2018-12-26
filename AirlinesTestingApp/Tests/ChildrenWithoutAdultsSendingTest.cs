using AirlinesTestingApp.BaseEntities;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp.Tests
{
    [TestClass]
    public class ChildrenWithoutAdultsSendingTest : BaseTest
    {
        private TicketsPage ticketsPage;

        [TestMethod]
        public void SetChildrenWithoutAdults()
        {
            _1_OpenTicketsOrderingPage();

            _2_SetAdultsAmountEqualToZeroAndChildrenToOne();

            _3_AssertErrorMessage();
        }

        private void _1_OpenTicketsOrderingPage()
        {
            ticketsPage = new TicketsPage();
            ticketsPage.OpenTicketsPage();
        }

        private void _2_SetAdultsAmountEqualToZeroAndChildrenToOne()
        {
            ticketsPage.ClickPassengersInput();
            ticketsPage.ClickAdultsDecreasingButton();
            ticketsPage.ClickChildrenIncreasingButton();
        }

        private void _3_AssertErrorMessage()
        {
            var errorMessageForm = ticketsPage.GetElement(ticketsPage.errorFormMessage);
            Assert.AreEqual(ticketsPage.errorChildrenWithoutAdultsText, errorMessageForm.Text);
        }
    }
}
