using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTest()
        {
            AccountData account = new AccountData() { Name = "administrator", Password = "root" };
            ProjectData project = new ProjectData() { Id = "3" };
            IssueData issue = new IssueData()
            {
                Summary = "short text",
                Description = "long text",
                Category = "General"
            };


            app.API.CreateNewIssue(account, project, issue);
        }
    }
}