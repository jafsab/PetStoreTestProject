using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly IObjectContainer _container;
        private readonly string _url = "https://www.saucedemo.com/";

        public Hooks1(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {

        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Url = _url;
            _container.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            IWebDriver _driver = _container.Resolve<IWebDriver>();
            if (_driver != null) { _driver.Quit(); }

        }
    }
}