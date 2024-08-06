using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class EmployeeListPage : BasePageLocal
    {
        private readonly By _AddBtnLocator = By.XPath("//div[@class='orangehrm-header-container']/button");

        private readonly By _EmployeeIDSearch = By.XPath("//div[@class='oxd-form-row']//input[starts-with(@class,'oxd-input')]");

        private readonly By _BtnSearchEmployeeData = By.CssSelector("button[type='submit']");
        private readonly By _FoundEmployee = By.CssSelector("div.oxd-table-card");

        public EmployeeListPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Clicks the Add button located on the Employee List page
        /// </summary>
        public void ClickAddButton()
        {
            Click(_AddBtnLocator);
        }

        /// <summary>
        /// Searches for the given Employee ID using the search fields on the Employee List page
        /// </summary>
        /// <param name="employeeID">The Employee ID that is being searched for</param>
        public void SearchForEmployeeByEmployeeID(string employeeID)
        {
            EditBoxSendKeysAndVerify(_EmployeeIDSearch, employeeID);
            Click(_BtnSearchEmployeeData);
            Click(_FoundEmployee);
            WaitAfterAction(3000);
        }
    }
}