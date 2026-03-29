using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitHomework
{
    public static class Framework
    {
        //Copy directory from fromPath to toPath
        public static void CopyDirectory(string fromPath, string toPath)
        {
            if (!System.IO.Directory.Exists(toPath))
            {
                System.IO.Directory.CreateDirectory(toPath);
            }
            if (System.IO.Directory.Exists(fromPath))
            {
                string[] files = System.IO.Directory.GetFiles(fromPath);
                foreach (string s in files)
                {
                    string fileName = Path.GetFileName(s);
                    string destFile = Path.Combine(toPath, fileName);
                    File.Copy(s, destFile, true);
                }
            }
        }

        //Click element by using JS
        public static void ClickWithJS(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        //Login with default email and password when main page is opened
        public static void LoginToAtata(this IWebDriver driver)
        {
            var signInButton = driver.FindElement(By.LinkText("Sign In"));
            signInButton.Click();
            var emailField = driver.FindElement(By.Id("email"));
            var passwordField = driver.FindElement(By.Id("password"));
            var submitButton = driver.FindElement(By.XPath("//input[@type='submit']"));
            emailField.SendKeys("admin@mail.com");
            passwordField.SendKeys("abc123");
            submitButton.Click();
        }
    }
}
