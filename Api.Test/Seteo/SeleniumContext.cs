using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Test.Seteo
{
    public class SeleniumContext
    {
        private IWebDriver _driver;
        public static ChromeOptions _chromeOptions;
        public static WebDriverWait _wait;

        public IWebDriver WebDriver { get; private set; }
        public WebDriverWait Wait { get; private set; }

        public SeleniumContext()
        {
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArguments(new List<string>() { "--incognito"}); // "headless", 
            _driver = new ChromeDriver(_chromeOptions);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            WebDriver = _driver;
            Wait = _wait;
        }
    }
}
