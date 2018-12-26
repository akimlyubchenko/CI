using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DevOpsTask.Tests.Drivers
{
    public class MyChromeDriver
    {
        // simple singleton
        public IWebDriver Instance;

        private static readonly Lazy<MyChromeDriver> lazy =
            new Lazy<MyChromeDriver>(() => new MyChromeDriver());

        private MyChromeDriver()
        {
            var dir = Environment.CurrentDirectory;
            var chromeDriverService = ChromeDriverService.CreateDefaultService(dir);
            chromeDriverService.HideCommandPromptWindow = true;

            Instance = new ChromeDriver(chromeDriverService);
            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public static MyChromeDriver GetDriver() => lazy.Value;
    }
}