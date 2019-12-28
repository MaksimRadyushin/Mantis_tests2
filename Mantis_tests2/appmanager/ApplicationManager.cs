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

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected RegistrationHelper registrationHelper;
        protected FtpHelper ftpHelper;
        protected JamesHelper jamesHelper;
        protected MailHelper mailHelper;
        protected LoginHelper loginHelper;
        protected ProjectHelper projectHelper;
        protected NavigationHelper navigationHelper;

        public RegistrationHelper Registration { get { return registrationHelper; } set { registrationHelper = value; } }
        public FtpHelper Ftp { get { return ftpHelper; } set { ftpHelper = value; } }
        public JamesHelper James { get { return jamesHelper; } set { jamesHelper = value; } }
        public MailHelper Mail { get { return mailHelper; } set { mailHelper = value; } }
        public LoginHelper Login { get { return loginHelper; } set { loginHelper = value; } }
        public ProjectHelper Project { get { return projectHelper; } set { projectHelper = value; } }
        public NavigationHelper Navigate { get { return navigationHelper; } set { navigationHelper = value; } }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();


        private ApplicationManager()//конструктор
        {

            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            baseURL = "http://localhost:8080/mantisbt-2.19.0";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            James = new JamesHelper(this);
            Mail = new MailHelper(this);
            Login = new LoginHelper(this);
            Project = new ProjectHelper(this);
            Navigate = new NavigationHelper(this, baseURL);


        }

        ~ApplicationManager()//деструктор, используется вместо  Stop для остановки потока; вызывается автоматически, поэтому не нужно писать модификатор видимости  к нему
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";

                app.Value = newInstance;


            }

            return app.Value;
        }


        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
    }
}