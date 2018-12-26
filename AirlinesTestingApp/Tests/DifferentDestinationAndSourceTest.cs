using AirlinesTestingApp.BaseEntities;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp
{
    [TestClass]
    public class ArrivalDateValidationTest : BaseTest
    {
        private HomePage homePage;
        private const string ErrorMessage = "MESSAGE D'ERREUR\r\nVous devez choisir une date " +
            "/ heure de départ, comprise entre ^DATA(START_RANGE_NUM), à partir de maintenant" +
            ", et ^DATA(END_RANGE_NUM).";

        [TestMethod]
        public void CheckArrivalDateGreaterOrEqualLeavingDate()
        {
            _1_OpenHomePage();

            _2_FillInBookingFormSetIncorrectArrivalDateAndSubmit();

            _3_AssertErrorsVisible();
        }

        private void _1_OpenHomePage()
        {
            homePage = new HomePage();
            homePage.OpenHomePage();
            homePage.CloseAds();
        }

        private void _2_FillInBookingFormSetIncorrectArrivalDateAndSubmit()
        {
            homePage.FillInBookingForm();
            homePage.GetLeavingTicketDate().Clear();
            homePage.SetDateTime(homePage.GetLeavingTicketDate(), "11/11/2011");
            homePage.SubmitBookingForm();
        }

        private void _3_AssertErrorsVisible()
        {
            var messageText = homePage.GetErrorMessages().Text;
            Assert.AreEqual(ErrorMessage, messageText);
        }
    }
}