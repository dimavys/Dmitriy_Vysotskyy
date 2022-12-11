using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Dmitriy_Vysotskyy.PageObjects
{
	public class JobTitlesPage
	{
        private IWebDriver _driver;

        private WebDriverWait _wait;

        public JobTitlesPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[text()=' Add ']")]
        [CacheLookup]
        private IWebElement _btnAdd;

        private char GetElementPosition(string textXpath)
        {
            int bracketCounter = 0;

            for (var i = textXpath.Length - 1; i >= 0; i--)
            {
                if (textXpath[i] == ']')
                {
                    if (bracketCounter == 3)
                        return textXpath[i];
                    bracketCounter++;
                }
            }

            return '0';
        }

        public AddJobTitlePage GoToAddTitle()
        {
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//button[text()=' Add ']"))); //DRY is out of party
            _btnAdd.Click();
            return new AddJobTitlePage(_driver);
        }

        public bool CheckJobExistance(string jobName)
        {
            string jobXpath = "//*[text()='" + jobName + "']";
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='orangehrm-bottom-container']")));

            if (_driver.FindElements(By.XPath(jobXpath)).Count() != 0)
                return true;
            return false;
        }

        public void DeleteJob(string jobName)
        {
            IWebElement btnDelete = _driver.FindElement(By.XPath("//div[text()='Driver']/parent::div/parent::div/parent::div//button[1]"));
            btnDelete.Click();
            _wait.Until(ExpectedConditions.ElementExists(By.XPath("//p[text()='Are you Sure?']")));

            IWebElement btnYesDelete = _driver.FindElement(By.XPath("//button[text()=' Yes, Delete ']"));
            btnYesDelete.Click();
            Thread.Sleep(10000);
        }
    }
}

