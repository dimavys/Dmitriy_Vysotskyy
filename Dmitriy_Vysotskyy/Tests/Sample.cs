using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Dmitriy_Vysotskyy.PageObjects;

namespace Dmitriy_Vysotskyy
{
    public class Sample
    {
        private IWebDriver _driver = new ChromeDriver();

        private string _jobTitleListUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/admin/viewJobTitleList";

        [OneTimeSetUp]
        public void Initialize()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.Navigate();
            loginPage.Login("Admin", "admin123");
        }

        [Test, Order(1)]
        public void GoToJobList_ValidEndUrl_ShouldGetDestSuccessfully()
        {
            var homePage = new HomePage(_driver);
            UserManagementPage userManagementPage = homePage.GoToAdminModule();
            userManagementPage.OpenChoices();
            JobTitlesPage jobTitlesPage = userManagementPage.GoToJobTitles();

            Assert.AreEqual(_driver.Url, _jobTitleListUrl);
        }

        [Test, Order(2)]
        public void InsertJob_ValidJobTitleAndJobDesc_ShouldCreateSuccessfully()
        {
            var jobTitlesPage = new JobTitlesPage(_driver);
            AddJobTitlePage addJobTitlePage = jobTitlesPage.GoToAddTitle();
            jobTitlesPage = addJobTitlePage.InsertTheJob("Driver", "This is desc of driver", "This is a note of driver");

            Assert.IsTrue(jobTitlesPage.CheckJobExistance("Driver"));
        }

        [Test, Order(3)]
        public void DeleteJob_FoundJob_ShouldDeletedSuccessfully()
        {
            var jobTitlesPage = new JobTitlesPage(_driver);
            jobTitlesPage = jobTitlesPage.DeleteJob("Driver");

            Assert.IsFalse(jobTitlesPage.CheckJobExistance("Driver"));
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            _driver.Quit();
        }
    }
}
