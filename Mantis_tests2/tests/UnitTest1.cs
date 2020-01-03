using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {
        [Test]
        public void TestMethod1()
        {
            //ProjectData project = new ProjectData()
            //{
            //    Title = "Project title",
            //    Description = "Lorem ipsum dolor sit amet orci aliquam."
            //};
            
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };

            List<ProjectData> allProjects = new List<ProjectData>();
            allProjects = app.API.GetAllProjects(account);
            //app.Login.LoginAsUser(account);
            //app.Navigate.OpenProjectsPage();
            //app.Project.GetAllProjects();
        }
    }
}