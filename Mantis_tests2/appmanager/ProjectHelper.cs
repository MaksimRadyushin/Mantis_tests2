using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        public void Create(ProjectData project)
        {
            //manager.Login.LoginAsUser(account);
            manager.Navigate.OpenProjectsPage();
            InitiateProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            //manager.Navigate.OpenLogoutPage();
        }

        public List<ProjectData> GetAllProjects()
        {
            //manager.Login.LoginAsUser(account);
            manager.Navigate.OpenProjectsPage();
            List<ProjectData> projects = new List<ProjectData>();
            IWebElement table = driver.FindElement(By.CssSelector(".widget-box"));
            IList<IWebElement> rows = table.FindElements(By.CssSelector("table tbody tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string title = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;
                projects.Add(new ProjectData()
                {
                    Title = title,
                    Id = id
                });

            }

            //manager.Navigate.OpenLogoutPage();
            return projects;
        }

        public void RemoveProject(ProjectData project)
        {

            manager.Navigate.OpenProjectEditPage(project);
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//form[@id='manage-project-create-form']/div/div[3]/input")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Title);
            driver.FindElement(By.Id("project-description")).Click();
            driver.FindElement(By.Id("project-description")).Clear();
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        public void InitiateProjectCreation()
        {
            driver.FindElement(By.CssSelector(".form-inline.inline.single-button-form")).Click();
        }
    }
}