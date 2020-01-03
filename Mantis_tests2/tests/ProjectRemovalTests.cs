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
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            List<ProjectData> oldList = app.API.GetAllProjects(account);

            if (oldList.Count < 1)
            {
                ProjectData project = new ProjectData()
                {
                    Title = "Project title15",
                    Description = "Lorem ipsum dolor sit amet orci aliquam."
                };

                app.API.CreateProject(account, project);

            }

            oldList = app.API.GetAllProjects(account);
            ProjectData projectToRemove = oldList[0];

            //actions

            app.Project.RemoveProject(projectToRemove);

            //verification

            List<ProjectData> newList = app.API.GetAllProjects(account);
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