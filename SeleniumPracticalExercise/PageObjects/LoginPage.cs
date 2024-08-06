using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    internal class LoginPage : BasePageLocal
    {
        private readonly By _usernameLocator = By.Name("username");
        private readonly By _passwordLocator = By.Name("password");
        private readonly By _loginButtonLocator = By.CssSelector("button");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Inputs the given username and password on the login page then clicks the login button
        /// </summary>
        /// <param name="username">Username to be used to login</param>
        /// <param name="password">Password to be used to login</param>
        public void SubmitLoginInfo(string username, string password)
        {
            SendKeys(_usernameLocator, username);
            SendKeys(_passwordLocator, password);
            Click(_loginButtonLocator);
        }

    }
}
