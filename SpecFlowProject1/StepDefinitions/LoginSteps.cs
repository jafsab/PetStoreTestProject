using SpecFlowProject1.POM;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [When(@"I enter username '(.*)' and password '(.*)'")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            _loginPage.Login(username, password);
            Thread.Sleep(1000);
        }

        [Then(@"an error message should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed()
        {
            _loginPage.AssertErrorMessageDisplayed();
        }

        [Then(@"open inventory page")]
        public void ThenOpenInventoryPage()
        {
            _loginPage.AssertOpenInventoryPage();
        }
    }
}
