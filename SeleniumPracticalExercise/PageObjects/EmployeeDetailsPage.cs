using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class EmployeeDetailsPage : BasePageLocal
    {
        private readonly By _FoundEmployeeID = By.XPath("//label[text()='Employee Id']/parent::div/following-sibling::div/input");
        private readonly By _FoundEmployeeFirstName = By.CssSelector("input[name='firstName']");
        private readonly By _FoundEmployeeLastName = By.CssSelector("input[name='lastName']");

        public EmployeeDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Returns the employee's id that is located on the current employee details page
        /// </summary>
        /// <returns>The id of the employee</returns>
        public string GrabFoundEmployeeID()
        {
            return GetValue(_FoundEmployeeID);
        }

        /// <summary>
        /// Returns the employee's first name that is located on the current employee details page
        /// </summary>
        /// <returns>The first name of the employee</returns>
        public string GrabFoundEmployeeFirstName()
        {
            return GetValue(_FoundEmployeeFirstName);
        }

        /// <summary>
        /// Returns the employee's last name that is located on the current employee details page
        /// </summary>
        /// <returns>The last name of the employee</returns>
        public string GrabFoundEmployeeLastName()
        {

            return GetValue(_FoundEmployeeLastName);
        }
    }
}
