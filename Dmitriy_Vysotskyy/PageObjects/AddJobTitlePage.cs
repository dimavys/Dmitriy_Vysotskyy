using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy.PageObjects
{
	public class AddJobTitlePage
	{
        private IWebDriver _driver;

        private WebDriverWait _wait;

        public AddJobTitlePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//input)[2]")] // have no idea how to search it in other way
        [CacheLookup]
        private IWebElement _txtJobTitle;

        [FindsBy(How = How.XPath, Using = "//textarea[@placeholder='Type description here']")]
        [CacheLookup]
        private IWebElement _txtJobDesc;

        [FindsBy(How = How.XPath, Using = "//textarea[@placeholder='Add note']")]
        [CacheLookup]
        private IWebElement _txtJobNotes;


        [FindsBy(How = How.XPath, Using = "//button[text()=' Save ']")]
        [CacheLookup]
        private IWebElement _btnAdd;


        public JobTitlesPage InsertTheJob(string jobName, string jobDesc, string jobNotes)
        {
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("(//input)[2]"))); //DRY is out of party
            _txtJobTitle.SendKeys(jobName);
            _txtJobDesc.SendKeys(jobDesc);
            _txtJobNotes.SendKeys(jobNotes);
            _btnAdd.Click();
            return new JobTitlesPage(_driver);
        }
    }
}

