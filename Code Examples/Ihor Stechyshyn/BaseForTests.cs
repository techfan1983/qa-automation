using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3
{
    public class BaseForTests
    {
        public IWebDriver driver=null;

        [SetUp]
        public void SetUp()
        {
            Log.Information("SetUp in BaseForTest class");

            driver.Navigate().GoToUrl("https://atata-framework.github.io/atata-sample-app/#!/");

            IWebElement signInButton = driver.FindElement(By.LinkText("Sign In"));
            signInButton.Click();

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("admin@mail.com");

            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("abc123");

            IWebElement sigIn = driver.FindElement(By.XPath("//input[@value='Sign In']"));
            sigIn.Click();
        }
    }
}
