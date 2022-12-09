using System;
using System.Linq;
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

        private string _deleteButtonXpathPart1 = "/html/body/div/div[1]/div[2]/div[2]/div/div/div[3]/div/div/div[";

        private string _deleteButtonXpathPart2 = "]/div/div/div[1]/div[2]/div/div/button[1]";

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

        public JobTitlesPage DeleteJob(string jobName)
        {
            string jobXpath = "//*[text()='" + jobName + "']";
            var textXpath = _driver.FindElement(By.XPath(jobXpath)).GetAttribute("xpath"); //doesn't work
            string deleteButtonXpath = _deleteButtonXpathPart1 + GetElementPosition(textXpath).ToString() + _deleteButtonXpathPart2;

            IWebElement deleteButton = _driver.FindElement(By.XPath(deleteButtonXpath));
            deleteButton.Click();

            return new JobTitlesPage(_driver);
        }
    }
}

