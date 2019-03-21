using BoDi;
using TechTalk.SpecFlow;

namespace Api.Test.Seteo
{
    [Binding]
    public class BeforeAllTests
    {
        private readonly IObjectContainer objectContainer;
        private static SeleniumContext seleniumContext;

        public BeforeAllTests(IObjectContainer container)
        {
            this.objectContainer = container;
        }

        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {
            seleniumContext = new SeleniumContext();
        }

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            objectContainer.RegisterInstanceAs<SeleniumContext>(seleniumContext);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            seleniumContext.WebDriver.Close();
            seleniumContext.WebDriver.Quit();
        }
    }
}
