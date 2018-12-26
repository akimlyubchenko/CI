using AirlinesTestingApp.BaseEntities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AirlinesTestingApp.Pages
{
    public class TicketsPage
    {
        private IWebDriver driver;
        private const string Url = "https://www.aircaraibes.com/mon-compte?destination=reserver-un-vol/billet-prime";
        private By passengersInput = By.Id("edit-count-passengers");
        private By adultsAmountInput = By.Id("edit-passengers-adults");
        private By adultsButtonIncrement = By.XPath("//*[@id='edit-passengers']/div[1]/div[1]/div[2]/ul/li[1]/button");
        By adultsButtonDecrement = By.XPath("//*[@id='edit-passengers']/div[1]/div[1]/div[2]/ul/li[2]/button");
        By childrenButtonIncrement = By.XPath("//*[@id='edit-passengers']/div/div[6]/div[2]/ul/li[1]/button");
        By errorFormContainer = By.XPath("//*[@id='edit-passengers']/div[2]");

        public By errorFormMessage = By.XPath("//*[@id='edit-passengers']/div[2]/ul/li");

        public string errorPassengersTooManyText = "Pas plus de 9 passagers...";
        public string errorChildrenWithoutAdultsText = "Au moins un adulte ou un senior par bébé...";

        By advertisementCross = By.ClassName("optanon-alert-box-close");
        By notificationCross = By.ClassName("acc--closeLink");


        public void ClickPassengersInput()
        {
            driver.FindElement(passengersInput).Click();
        }

        public IWebElement GetAdultsInput()
        {
            return driver.FindElement(adultsAmountInput);
        }

        public void ClickAdultsIncreasingButton()
        {
            driver.FindElement(adultsButtonIncrement).Click();
        }

        public void ClickAdultsIncreasingButton(int times)
        {
            for (int i = 0; i < times; i++)
            {
                driver.FindElement(adultsButtonIncrement).Click();
            }
        }

        public void ClickAdultsDecreasingButton()
        {
            driver.FindElement(adultsButtonDecrement).Click();
        }

        public void ClickAdultsDecreasingButton(int times)
        {
            for (int i = 0; i < times; i++)
            {
                driver.FindElement(adultsButtonDecrement).Click();
            }
        }

        public void ClickChildrenIncreasingButton()
        {
            driver.FindElement(childrenButtonIncrement).Click();
        }

        public void ClickChildrenIncreasingButton(int times)
        {
            for (int i = 0; i < times; i++)
            {
                driver.FindElement(childrenButtonIncrement).Click();
            }
        }

        public void InputInFieldData(int num, IWebElement element)
        {
            element.SendKeys(num.ToString());
        }

        public TicketsPage()
        {
            this.driver = Driver.GetDriverInstance();
        }

        public void OpenTicketsPage()
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

        public IWebElement GetErorrsContainer()
        {
            return driver.FindElement(errorFormContainer);
        }

        public IWebElement GetElement(By selector)
        {
            return driver.FindElement(selector);
        }

        public bool Exists(By selector)
        {
            return (driver.FindElements(selector).Count != 0);
        }
    }
}   