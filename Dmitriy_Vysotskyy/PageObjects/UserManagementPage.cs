using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy.PageObjects
{
	public class UserManagementPage
	{
        private IWebDriver _driver;

        private WebDriverWait _wait;

        public UserManagementPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[text()='Job ']")]
        [CacheLookup]
        private IWebElement _btnJob;

        [FindsBy(How = How.XPath, Using = "//a[text()='Job Titles']")]
        [CacheLookup]
        private IWebElement _btnJobTitles;

        public void OpenChoices()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[text()='Job ']"))); //DRY is out of party
            _btnJob.Click();
        }

        public JobTitlesPage GoToJobTitles()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[text()='Job Titles']"))); //DRY is out of party
            _btnJobTitles.Click();
            return new JobTitlesPage(_driver);
        }
    }
}

