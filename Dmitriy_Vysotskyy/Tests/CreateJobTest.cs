using System;
using System.Threading;
using Dmitriy_Vysotskyy.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dmitriy_Vysotskyy.Tests
{
	public class CreateJobTest
	{
        private IWebDriver _driver = new ChromeDriver();

        [SetUp]
        public void Initialize()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.Navigate();
            loginPage.Login("Admin", "admin123");

            var homePage = new HomePage(_driver);
            UserManagementPage userManagementPage = homePage.GoToAdminModule();
            userManagementPage.OpenChoices();
            JobTitlesPage jobTitlesPage = userManagementPage.GoToJobTitles();
        }

        [Test]
        public void InsertJob_ValidJobTitleAndJobDesc_ShouldCreateSuccessfully()
        {
            var jobTitlesPage = new JobTitlesPage(_driver);
            AddJobTitlePage addJobTitlePage = jobTitlesPage.GoToAddTitle();
            jobTitlesPage = addJobTitlePage.InsertTheJob("Driver", "This is desc of driver", "This is a note of driver");

            Assert.IsTrue(jobTitlesPage.CheckJobExistance("Driver"));
        }

        [TearDown]
        public void EndTest()
        {
            var jobTitlesPage = new JobTitlesPage(_driver);
            jobTitlesPage.DeleteJob("Driver");
            _driver.Quit();
        }

    }
}

