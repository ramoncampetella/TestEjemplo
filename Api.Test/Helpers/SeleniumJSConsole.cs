using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test.Helpers
{
    public class SeleniumJSConsole
    {
        private IWebDriver _driver;
        public static ChromeOptions _chromeOptions;
        public static WebDriverWait _wait;
        public static readonly int CantidadClick = 5;

        public void CaptureBrowserLogs()
        {
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArguments(new List<string>() { "--incognito" }); // "headless",
            _chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);

            _driver = new ChromeDriver(_chromeOptions);
           // _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
           

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://www.lanacion.com.ar");

            var logs = _driver.Manage().Logs;
            var logsEntries = logs.GetLog(LogType.Browser);

            _driver.Close();
            _driver.Quit();
        }



    }
}
