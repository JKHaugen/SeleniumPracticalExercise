using NUnit.Framework;
using SeleniumPracticalExercise.TestCases.Common;

namespace SeleniumPracticalExercise.TestCases
{
    class AddEmployee : BaseTestLocal
    {
        [Test]
        [Category("Add Employee")]
        public void AddEmployeeTest()
        {
            // Steps to automate:
            // 1. Navigate to https://opensource-demo.orangehrmlive.com/web/index.php/auth/login
            // 2. Log in using Username: Admin, Password: admin123
            // 3. Click "PIM" in the left nav
            // 4. Click "+Add"
            // 5. Randomly generate a first name (6 characters) and last name (8 characters) and enter them into the form
            // 6. Get the Employee Id for use later
            // 7. Click Save
            // 8. Click "PIM" in the left nav
            // 8. Search for the employee you just created by Employee Id
            // 9. In the employee search results, use NUnit asserts to validate that Id, First Name, and Last Name are correct
            //
            // NOTE:
            // - Use the provided WebDriver methods in BasePageLocal.cs
            // - Create page objects as needed
            // - Document all methods using XML documentation, https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/

        }
    }
}