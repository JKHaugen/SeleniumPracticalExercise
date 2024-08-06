using NUnit.Framework;
using SeleniumPracticalExercise.PageObjects;
using SeleniumPracticalExercise.TestCases.Common;

namespace SeleniumPracticalExercise.TestCases
{
    class AddEmployee : BaseTestLocal
    {
        [OneTimeSetUp]
        public override void OneTimeSetup()
        {
            base.OneTimeSetup();
            // 1. Navigate to https://opensource-demo.orangehrmlive.com/web/index.php/auth/login
            Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        }

        [SetUp]
        public override void Setup()
        {
            base.Setup();
        }

        /// <summary>
        /// Confirms a user is able to login to an Admin account, add a new employee, and then verifies the employee has been added.
        /// </summary>
        /// <param name="username">Valid username is expected</param>
        /// <param name="password">Valid password for the given username is expected</param>
        /// <param name="IDLength">Number of digits the employee id will be set to</param>
        /// <param name="lengthFirstName">Number of characters the first name will be set to</param>
        /// <param name="lengthLastName">Number of characters the last name will be set to</param>
        [Test]
        [Category("Add Employee")]
        [TestCase("Admin", "admin123", 4, 6, 8)]
        public void AddEmployeeTest(string username, string password, int IDLength, int lengthFirstName, int lengthLastName)
        {
            if (Driver.Value == null)
                return;

            string employeeID, generatedFirstName, generatedLastName;
            // Steps to automate:

            // 2. Log in using Username: Admin, Password: admin123
            LoginPage loginPage = new LoginPage(Driver.Value);
            loginPage.SubmitLoginInfo(username, password);

            // 3. Click "PIM" in the left nav
            NavigationBarPage navigationBarPage = new NavigationBarPage(Driver.Value);
            navigationBarPage.ClickPIMLink();

            // 4. Click "+Add"
            EmployeeListPage employeeListPage = new EmployeeListPage(Driver.Value);
            employeeListPage.ClickAddButton();

            // 5. Randomly generate a first name (6 characters) and last name (8 characters) and enter them into the form
            AddEmployeePage addEmployeePage = new AddEmployeePage(Driver.Value);
            generatedFirstName = addEmployeePage.InputAndReturnFirstName(lengthFirstName);
            generatedLastName = addEmployeePage.InputAndReturnLastName(lengthLastName);

            // 6. Get the Employee Id for use later
            employeeID = addEmployeePage.InputAndReturnEmployeeID(IDLength);

            // 7. Click Save
            addEmployeePage.ClickSaveButton();

            // 8. Click "PIM" in the left nav
            navigationBarPage.ClickPIMLink();

            // 8. Search for the employee you just created by Employee Id
            employeeListPage.SearchForEmployeeByEmployeeID(employeeID);

            // 9. In the employee search results, use NUnit asserts to validate that Id, First Name, and Last Name are correct
            EmployeeDetailsPage employeeDetailsPage = new EmployeeDetailsPage(Driver.Value);
            Assert.That(employeeDetailsPage.GrabFoundEmployeeID(), Is.EqualTo(employeeID));
            Assert.That(employeeDetailsPage.GrabFoundEmployeeFirstName(), Is.EqualTo(generatedFirstName));
            Assert.That(employeeDetailsPage.GrabFoundEmployeeLastName(), Is.EqualTo(generatedLastName));


            // NOTE:
            // - Use the provided WebDriver methods in BasePageLocal.cs
            // - Create page objects as needed
            // - Document all methods using XML documentation, https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/
        }
    }
}