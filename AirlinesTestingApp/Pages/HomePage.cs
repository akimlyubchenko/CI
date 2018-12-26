using AirlinesTestingApp.BaseEntities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AirlinesTestingApp.Pages
{
    public class HomePage
    {
        private IWebDriver driver;
        private const string Url = "https://www.aircaraibes.com/";
        By advertisementCross = By.ClassName("optanon-alert-box-close");
        By oneWayTicketCheckbox = By.Id("departure-only");
        By leavingTicketDate = By.Id("edit-b-date-1-booking-0");
        By returnTicketDate = By.Id("edit-b-date-2-booking-0");
        By returnTicketProximity = By.Id("uniform-edit-date-range-value-2");
        By departure = By.Id("edit-b-location-1");
        By arrival = By.Id("edit-b-location-2");
        By bookingFormSubmitButton = By.Id("edit-submit-booking-home");
        By dateClosingCross = By.ClassName("ui-datepicker__close");
        By notificationCross = By.ClassName("acc--closeLink");
        By errorsMessages = By.ClassName("messages");
        List<By> errorsXPaths = new List<By>()
        {
            By.XPath("//*[@id='ac-com-booking-amadeus-booking-homepage']/div[2]/ul/li[1]"),
            By.XPath("//*[@id='ac-com-booking-amadeus-booking-homepage']/div[2]/ul/li[2]"),
            By.XPath("//*[@id='ac-com-booking-amadeus-booking-homepage']/div[2]/ul/li[3]"),
            By.XPath("//*[@id='ac-com-booking-amadeus-booking-homepage']/div[2]/ul/li[4]")
        };

        private void SelectDeparture()
        {
            var placeToLeave = new SelectElement(driver.FindElement(departure));
            placeToLeave.SelectByIndex(1);//Because "zero" value is default
        }

        private void ChooseValueOfSelectTag(By selector, int index)
        {
            var selectElement = new SelectElement(driver.FindElement(selector));
            selectElement.SelectByIndex(index);//Because "zero" value is default
        }

        private void CloseDatePicker()
        {
            driver.FindElement(dateClosingCross).Click();
        }

        public HomePage()
        {
            this.driver = Driver.GetDriverInstance();
        }   

        public void OpenHomePage()
        {
            GoToUrl(Url);
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void CloseAds()
        {
            driver.FindElement(advertisementCross).Click();
            Thread.Sleep(1000);
            driver.FindElement(notificationCross).Click();
        }

        public void SelectOneWayTicket()
        {
            driver.FindElement(oneWayTicketCheckbox).Click();
        }

        public IWebElement GetReturnTicketDate()
        {
            return driver.FindElement(returnTicketDate);
        }

        public IWebElement GetLeavingTicketDate()
        {
            return driver.FindElement(leavingTicketDate);
        }

        public IWebElement GetReturnTicketProximity()
        {
            return driver.FindElement(returnTicketProximity);
        }

        public void FillInBookingForm()
        {
            ChooseValueOfSelectTag(departure, 1);
            ChooseValueOfSelectTag(arrival, 12);

            SetDateTime(driver.FindElement(leavingTicketDate), DateTime.Now.ToString("dd'/'MM'/'yyyy"));
            SetDateTime(GetReturnTicketDate(), DateTime.Now.ToString("dd'/'MM'/'yyyy"));
        }

        public IWebElement SetDepartureAndReturnElement()
        {
            var selectElement = new SelectElement(driver.FindElement(departure));
            selectElement.SelectByIndex(1);//Because "zero" value is default
            return selectElement.SelectedOption;
        }

        public SelectElement GetArrivalAirportOptions()
        {
            return new SelectElement(driver.FindElement(arrival));
        }

        public void SetDateTime(IWebElement el, string value)
        {
            el.SendKeys(value);
            CloseDatePicker();
        }

        public IWebElement GetElement(By selector)
        {
            return driver.FindElement(selector);
        }

        public void SubmitBookingForm()
        {
            driver.FindElement(bookingFormSubmitButton).Click();
        }

        public IWebElement GetErrorMessages()
        {
            return driver.FindElement(errorsMessages);
        }

        public List<IWebElement> GetErrorsElements()
        {
            List<IWebElement> resultElements = new List<IWebElement>();
            foreach (var errorsXPath in errorsXPaths)
            {
                resultElements.Add(driver.FindElement(errorsXPath));
            }
            return resultElements;
        }
    }
}   