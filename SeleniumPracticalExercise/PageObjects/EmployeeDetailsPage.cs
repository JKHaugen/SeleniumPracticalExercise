using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class EmployeeDetailsPage : BasePageLocal
    {
        private readonly By _FoundEmployeeID = By.XPath("//label[text()='Employee Id']/parent::div/following-sibling::div/input");
        private readonly By _FoundEmployeeFirstName = By.CssSelector("input[name='firstName']");
        private readonly By _FoundEmployeeLastName = By.CssSelector("input[name='lastName']");
        private readonly By _EmployeeSaved = By.LinkText("Personal Details");

        public EmployeeDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Returns the employee's id that is located on the current employee details page
        /// </summary>
        /// <returns>The id of the employee</returns>
        public string GrabFoundEmployeeID()
        {
            return WaitForFilledString(_FoundEmployeeID, 2);
        }

        /// <summary>
        /// Returns the employee's first name that is located on the current employee details page
        /// </summary>
        /// <returns>The first name of the employee</returns>
        public string GrabFoundEmployeeFirstName()
        {
            return WaitForFilledString(_FoundEmployeeFirstName, 1);
        }

        /// <summary>
        /// Returns the employee's last name that is located on the current employee details page
        /// </summary>
        /// <returns>The last name of the employee</returns>
        public string GrabFoundEmployeeLastName()
        {

            return WaitForFilledString(_FoundEmployeeLastName, 1);
        }

        /// <summary>
        /// Confirms the page loaded by looking for a specfic field to ensure the data was saved
        /// </summary>
        public void ConfirmPagedLoaded()
        {
            int timeout = 5;
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementExists(_EmployeeSaved));
        }

        /// <summary>
        /// Will attempt to return a field value by the given locator that is not an empty string within the timeout period
        /// </summary>
        /// <param name="locator">Field that is expected to not be an empty string</param>
        /// <param name="timeout">Amount of time in seconds it will search for the non-empty string</param>
        /// <returns>The value from the element or an empty string if the timeout runs out and no value was found</returns>
        private string WaitForFilledString(By locator, int timeout)
        {
            string filledField = String.Empty;
            DateTime now = DateTime.Now;
            while (filledField.Equals(String.Empty) && DateTime.Now < now.AddSeconds(timeout))
            {
                filledField = GetValue(locator);
            }
            return filledField;
        }
    }
}
