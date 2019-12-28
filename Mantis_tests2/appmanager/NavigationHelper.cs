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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, String baseURL) : base(manager) { this.baseURL = baseURL; }

        public void OpenLoginPage()
        {

            if (driver.Url == baseURL + "/login_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/login_page.php");


        }

        public void OpenProjectsPage()
        {

            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_page.php");

        }

        public void OpenUsersPage()
        {

            if (driver.Url == baseURL + "/manage_user_page.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_user_page.php");

        }
        public void OpenLogoutPage()
        {

            driver.Navigate().GoToUrl(baseURL + "/logout_page.php");
        }

        public void OpenProjectEditPage(ProjectData project)
        {
            if (driver.Url == baseURL + "/manage_proj_edit_page.php?project_id=" + project.Id)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/manage_proj_edit_page.php?project_id=" + project.Id);
        }
    }
}