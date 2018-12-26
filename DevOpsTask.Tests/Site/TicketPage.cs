using System;
using System.Linq;
using OpenQA.Selenium;

namespace DevOpsTask.Tests.Site
{
    public class TicketPage
    {
        private const string BASE_URL = "https://sales.orenairport.ru/oxygen/";
        private readonly By viewBlock = By.ClassName("view-block");
        private readonly By selectCity = By.XPath("//ul[@class='city-list']");


        private readonly IWebDriver _driver;

        public TicketPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Open()
        {
            _driver.Navigate().GoToUrl(BASE_URL);
        }

        public void InitFrom(string from)
        {
            var inputFrom = _driver.FindElements(viewBlock).First();
            var cityBlockFrom = _driver.FindElements(selectCity).First();

            var input = _driver.FindElement(By.Id("originCityName_0"));
            inputFrom.Click();
            input.SendKeys(from);

            if (cityBlockFrom.Displayed)
                cityBlockFrom.FindElement(By.TagName("li")).Click();
        }

        public void InitTo(string to)
        {
            var inputTo = _driver.FindElements(viewBlock).Last();
            var cityBlockTo = _driver.FindElements(selectCity).Last();

            var input = _driver.FindElement(By.Id("destinationCityName_0"));
            inputTo.Click();
            input.SendKeys(to);

            if (cityBlockTo.Displayed)
                cityBlockTo.FindElement(By.TagName("li")).Click();
        }

        public void ClickOneWay()
        {
            var oneWayLabel = _driver.FindElement(By.XPath("//label[@for='isOneWay']"));
            oneWayLabel.Click();
        }

        public bool IsReturnDateVisible()
        {
            var backDateInput = _driver.FindElement(By.Id("backDate_0"));
            return backDateInput.Displayed;
        }

        public bool ResultsFound()
        {
            var searchButton = _driver.FindElement(By.Id("searchButton"));
            searchButton.Click();

            
            try
            {
                var foundBlock = _driver.FindElement(By.Id("search-filter-info"));
                return foundBlock.Displayed;
            }
            catch (Exception)
            {
                try
                {
                    var pageWarningBlock = _driver.FindElement(By.XPath("//div[@class='alert alert-warning page-warning']"));
                    return !pageWarningBlock.Displayed;
                }
                catch (Exception)
                {
                    var pageDangerBlock = _driver.FindElement(By.XPath("//div[@class='alert alert-danger page-error']"));
                    return !pageDangerBlock.Displayed;
                }
            }
        }

        public void ClickLoginButton()
        {
            try
            {
                var loginButton = _driver.FindElement(By.Id("showLoginBtn"));
                loginButton.Click();
            }
            catch (Exception)
            {
                var loginButton = _driver.FindElement(By.Id("loginBtn"));
                loginButton.Click();
            }
        }

        public void ClickLogoutButton()
        {
            var logoutButton = _driver.FindElement(By.Id("logoutBtn"));
            logoutButton.Click();
        }

        public void EnterLogin(string login)
        {
            var loginEntry = _driver.FindElement(By.Id("login"));
            loginEntry.Click();
            loginEntry.SendKeys(login);
        }

        public void EnterPassword(string password)
        {
            var passEntry = _driver.FindElement(By.Id("password"));
            passEntry.Click();
            passEntry.SendKeys(password);
        }

        public string UserName => _driver.FindElement(By.Id("userName")).Text;

        public bool Authorized => _driver.FindElement(By.Id("authorise")).Displayed;

    }
}