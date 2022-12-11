using System;
using Dmitriy_Vysotskyy.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Dmitriy_Vysotskyy.Tests
{
	public class DeleteJobTest
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
            AddJobTitlePage addJobTitlePage = jobTitlesPage.GoToAddTitle();
            jobTitlesPage = addJobTitlePage.InsertTheJob("Driver", "This is desc of driver", "This is a note of driver");
        }

        [Test]
        public void DeleteJob_FoundJob_ShouldDeletedSuccessfully()
        {
            var jobTitlesPage = new JobTitlesPage(_driver);
            jobTitlesPage.DeleteJob("Driver");

            Assert.IsFalse(jobTitlesPage.CheckJobExistance("Driver"));
        }

        [TearDown]
        public void EndTest()
        {
            _driver.Quit();
        }
    }
}

