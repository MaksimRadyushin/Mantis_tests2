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
    public class ProjectRemovalTests : TestBase
    {
        [SetUp]

        public void Login()
        {
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            app.Login.LoginAsUser(account);

        }

        [Test]
        public void TestProjectRemoval()
        {

            //preconditions
            List<ProjectData> oldList = app.Project.GetAllProjects();

            if (oldList.Count < 1)
            {
                ProjectData project = new ProjectData()
                {
                    Title = "Project title15",
                    Description = "Lorem ipsum dolor sit amet orci aliquam."
                };

                app.Project.Create(project);

            }

            oldList = app.Project.GetAllProjects();
            ProjectData projectToRemove = oldList[0];

            //actions

            app.Project.RemoveProject(projectToRemove);

            //verification

            List<ProjectData> newList = app.Project.GetAllProjects();
            oldList.Remove(projectToRemove);

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