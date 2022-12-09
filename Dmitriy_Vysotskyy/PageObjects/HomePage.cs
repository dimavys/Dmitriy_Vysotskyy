using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy.PageObjects
{
	public class HomePage
	{
        private IWebDriver _driver;

        private WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Admin")]
        [CacheLookup]
        private IWebElement _btnAdmin;

        public UserManagementPage GoToAdminModule()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.LinkText("Admin"))); //DRY is out of party
            _btnAdmin.Click();
            return new UserManagementPage(_driver);
        }
    }
}

