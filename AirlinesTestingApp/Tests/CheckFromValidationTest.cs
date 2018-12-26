using System.Collections.Generic;
using AirlinesTestingApp.BaseEntities;
using AirlinesTestingApp.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp.Tests
{
    [TestClass]
    public class CheckFromValidationTest : BaseTest
    {
        private HomePage homePage;
        private readonly List<string> errorsMessageList = new List<string>
        {
            "Veuillez sélectionner une date de départ",
            "Veuillez sélectionner une date retour",
            "Veuillez sélectionner un départ",
            "Veuillez sélectionner une arrivée"
        };

        [TestMethod]
        public void CheckFormValidation()
        {
            _1_OpenHomePage();

            _2_SubmitBookingForm();

            _3_AssertErrorsVisible();
        }

        private void _1_OpenHomePage()
        {
            homePage = new HomePage();
            homePage.OpenHomePage();
            homePage.CloseAds();
        }

        private void _2_SubmitBookingForm()
        {
            homePage.SubmitBookingForm();
        }

        private void _3_AssertErrorsVisible()
        {
            var errorsListElements = homePage.GetErrorsElements();
            int i = 0;
            foreach (var errorsListElement in errorsListElements)
            {
                Assert.AreEqual(errorsMessageList[i], errorsListElement.Text);
                i++;
            }
        }
    }
}