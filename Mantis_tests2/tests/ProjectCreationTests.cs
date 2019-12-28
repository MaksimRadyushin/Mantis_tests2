using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [SetUp]

        public void Login()
        {
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            app.Login.LoginAsUser(account);

        }

        [Test]
        public void TestProjectCreation()
        {
            List<ProjectData> oldList = app.Project.GetAllProjects();

            ProjectData project = new ProjectData()
            {
                Title = "Project title15",
                Description = "Lorem ipsum dolor sit amet orci aliquam."
            };

            ProjectData projectWithSameTitle = oldList.Find(x => x.Title == project.Title);
            if (projectWithSameTitle != null)
            {
                app.Project.RemoveProject(projectWithSameTitle);
            }

            oldList = app.Project.GetAllProjects();
            app.Project.Create(project);

            List<ProjectData> newList = app.Project.GetAllProjects();
            oldList.Add(project);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

        }

        [TearDown]
        public void Logout()
        {
            app.Navigate.OpenLogoutPage();
        }
    }
}