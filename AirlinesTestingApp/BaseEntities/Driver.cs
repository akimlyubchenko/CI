using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp.BaseEntities
{
    public class Driver
    {
        private static IWebDriver driver;

        private Driver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public static IWebDriver GetDriverInstance()
        {
            if(driver == null)
            {
                new Driver();
            }
            return driver;
        }

        public static void QuitDriver()
        {
            driver.Quit();
        }
    }
}