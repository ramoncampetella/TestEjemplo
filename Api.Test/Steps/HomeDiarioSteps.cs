using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Api.Test.Steps
{
    [Binding]
    public class HomeDiarioSteps
    {
        private IWebDriver _driver;
        public static ChromeOptions _chromeOptions;
        public static WebDriverWait _wait;
        public static readonly int CantidadClick = 5;

        [Given(@"Ingreso la direccion del sitio del diario")]
        public void GivenIngresoLaDireccionDelSitioDelDiario()
        {
            _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArguments(new List<string>() {"--incognito" } ); // "headless", 
            _driver = new ChromeDriver(_chromeOptions);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //_driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://www.lanacion.com.ar");
        }
        
        [When(@"Sin cargar ningun dato")]
        public void WhenSinCargarNingunDato()
        {
            //No ejecuto ninguna accion
        }
        
        [Then(@"Visualizo la portada y veo el logo del diario\.")]
        public void ThenVisualizoLaPortadaYVeoElLogoDelDiario_()
        {
            //bool existLogo = _wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".banner-header-logo")));
            bool existLogo =_driver.FindElement(By.CssSelector(".banner-header-logo")).Displayed;
            Assert.IsTrue(existLogo);
            _driver.Close();
            _driver.Quit();
        }
    }
}
