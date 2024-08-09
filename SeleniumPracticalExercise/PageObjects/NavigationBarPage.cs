using OpenQA.Selenium;
using SeleniumPracticalExercise.PageObjects.Common;

namespace SeleniumPracticalExercise.PageObjects
{
    public class NavigationBarPage : BasePageLocal
    {
        private readonly By _PIMLocator = By.LinkText("PIM");


        public NavigationBarPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Selects the PIM link from the Navigation Bar on any page while logged in
        /// </summary>
        public void ClickPIMLink()
        {
            Click(_PIMLocator);
        }
    }
}