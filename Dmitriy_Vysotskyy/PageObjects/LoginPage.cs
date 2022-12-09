using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy.PageObjects
{
	public class LoginPage
	{
        private IWebDriver _driver;

        private string _urlLink = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        private WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "username")]
        [CacheLookup]
        private IWebElement _txtUsername;

        [FindsBy(How = How.Name, Using = "password")]
        [CacheLookup]
        private IWebElement _txtPassword;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'orangehrm-login-button')]")]
        [CacheLookup]
        private IWebElement _btnLogin;

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_urlLink);
            _driver.Manage().Window.Maximize();
        }

        public void Login(string username, string password)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.Name("username"))); //DRY is out of party
            _txtUsername.SendKeys(username);
            _txtPassword.SendKeys(password);
            _btnLogin.Click();
            //return new HomePage(_driver);
        }
    }
}

