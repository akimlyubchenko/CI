using AirlinesTestingApp.BaseEntities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AirlinesTestingApp.Pages
{
    public class SearchResultsPage
    {
        private IWebDriver driver;
        public const string Url = "https://www.aircaraibes.com/recherche/p/text/";
        private const string Results = " RÉSULTATS";

        By searchBoxResults = By.XPath("//*[@id='block-current-search-standard']/div/div/h3[1]");
        
        public SearchResultsPage()
        {
            this.driver = Driver.GetDriverInstance();
        }

        public void OpenSearchResultsPage()
        {
            GoToUrl(Url);
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void GoToSearchResultsForSpecifiedWord(string word)
        {
            GoToUrl($"{Url}{word}");
        }

        public string GetSearchResultsText()
        {
            var searchResultsBoxElement = driver.FindElement(searchBoxResults);
            var content = searchResultsBoxElement.Text;
            return (content.Substring(content.IndexOf(":")+2));
        }

        public IWebElement GetElement(By selector)
        {
            return driver.FindElement(selector);
        }
    }
}   