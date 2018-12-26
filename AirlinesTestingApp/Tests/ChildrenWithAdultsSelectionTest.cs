using AirlinesTestingApp.BaseEntities;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp.Tests
{
    [TestClass]
    public class ChildrenWithAdultsSelectionTest : BaseTest
    {
        private TicketsPage ticketsPage;
        private readonly int specifiedAdultsNumber = 3;

        [TestMethod]
        public void SetChildrenWithAdults()
        {
            _1_OpenTicketsOrderingPage();

            _2_SetSpecifiedAdultsAmountNotEqualToZeroAndChildrenToOne();

            _3_AssertErrorMessage();
        }

        private void _1_OpenTicketsOrderingPage()
        {
            ticketsPage = new TicketsPage();
            ticketsPage.OpenTicketsPage();
        }

        private void _2_SetSpecifiedAdultsAmountNotEqualToZeroAndChildrenToOne()
        {
            ticketsPage.ClickPassengersInput();
            ticketsPage.ClickAdultsIncreasingButton(specifiedAdultsNumber - 1);
            ticketsPage.ClickChildrenIncreasingButton();
        }

        private void _3_AssertErrorMessage()
        {
            Assert.IsFalse(ticketsPage.Exists(ticketsPage.errorFormMessage));
        }
    }
}
