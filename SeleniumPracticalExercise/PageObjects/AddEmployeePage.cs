using OpenQA.Selenium;
using SeleniumPracticalExercise.Common;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class AddEmployeePage : BasePageLocal
    {
        private readonly By _FirstNameField = By.Name("firstName");
        private readonly By _LastNameField = By.Name("lastName");

        private readonly By _SaveBtnEmployeeData = By.CssSelector("button[type='submit']");
        private readonly By _SaveEmployeeError = By.XPath("//span[text()='Employee Id already exists']");

        private readonly By _EmployeeIDData = By.XPath("//label[text() = 'Employee Id']/parent::div/following-sibling::div/input");

        public AddEmployeePage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Generates and returns a randomly created string of the desired length to represent the first name of an employee
        /// </summary>
        /// <param name="nameLength">The number of characters the name will have</param>
        /// <returns>The name inputted as the first name of the employee</returns>
        public string InputAndReturnFirstName(int nameLength)
        {
            return InputAndReturnName(_FirstNameField, Utils.GenerateRandomString(nameLength));
        }

        /// <summary>
        /// Generates and returns a randomly created string of the desired length to represent the last name of an employee
        /// </summary>
        /// <param name="nameLength">The number of characters the name will have</param>
        /// <returns>The name inputted as the last name of the employee</returns>
        public string InputAndReturnLastName(int nameLength)
        {
            return InputAndReturnName(_LastNameField, Utils.GenerateRandomString(nameLength));
        }

        /// <summary>
        /// Inputs the name into the given locator and then returns the name back
        /// </summary>
        /// <param name="locator">Location the string will be inputted</param>
        /// <param name="name">The name that will be inputted and returned</param>
        /// <returns>The name inputted into the field</returns>
        private string InputAndReturnName(By locator, string name)
        {
            EditBoxSendKeysAndVerify(locator, name);
            return name;
        }

        /// <summary>
        /// Generates a randomly created unique string of digits for the employee id
        /// </summary>
        /// <param name="idLength">The number of random digits for the employee id</param>
        /// <returns>The unique id inputted into the field</returns>
        public string InputAndReturnEmployeeID(int idLength)
        {
            string employeeID;
            do
            {
                DeleteValue(_EmployeeIDData);
                employeeID = Utils.GenerateRandomIntAsString(idLength);
                EditBoxSendKeysAndVerify(_EmployeeIDData, employeeID);
                WaitAfterAction(2000);
            }
            while (Exists(_SaveEmployeeError));

            return employeeID;
        }

        /// <summary>
        /// Clicks the save button for the currently inputted employee information and waits for the page to process the data
        /// </summary>
        public void ClickSaveButton()
        {
            Click(_SaveBtnEmployeeData);
            WaitAfterAction(2000);
        }
    }
}
