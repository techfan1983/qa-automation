using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Threading;
using System.IO;

namespace HW_Selenium_Basic_pt1
{
    class Program
    {
        //private static IWebDriver driver;
        static void Main(string[] args)
        {
            IWebDriver driverCh = new ChromeDriver();
            HomeWorkTasks(driverCh);
            /*IWebDriver driverMF = new FirefoxDriver();
            HomeWorkTasks(driverMF);
            IWebDriver driverIE = new InternetExplorerDriver();
            HomeWorkTasks(driverIE);*/

        }
        public static void HomeWorkTasks(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://www.leafground.com/");
            
            driver.FindElement(By.CssSelector("[href*='pages/Edit.html']"))
                .Click();
            
            driver.FindElement(By.Id("email")).
                SendKeys("tester.petrov9078@gmail.com");
            
            driver.FindElements(By.Name("username")).First().
                Clear();

            IWebElement lastInput;
            lastInput = driver.FindElement(By.CssSelector("input[disabled='true']"));
            if (!lastInput.Enabled)
            {
                Console.WriteLine("Last input is disabled");
            }
            else throw new InvalidOperationException("Last input is not disabled");

            driver.Navigate().
                Back();
            
            driver.FindElement(By.LinkText("Button")).
                Click();
            
            string url = driver.Url;
            Console.WriteLine("Saved url: " + url);
            if (!url.Contains("http://www.leafground.com"))
            {
                throw new InvalidOperationException("Invalid page url");
            }

            driver.FindElement(By.Id("home")).
                Click();
            
            driver.Navigate().
                Back();
            
            string cssproperty = driver.FindElement(By.Id("color"))
                .GetCssValue("background-color");
            Console.WriteLine("Used css value is: " + cssproperty);

            driver.FindElement(By.CssSelector("[href*='home.html']"))
                .Click();
            driver.FindElement(By.LinkText("HyperLink")).
                Click();
            
            driver.FindElement(By.LinkText("Go to Home Page")).
                Click();
            
            driver.FindElement(By.CssSelector("[href*='pages/radio.html']"))
                .Click();
            
            driver.FindElement(By.Id("no")).
                Click();
            
            IWebElement radiobutton1;
            IWebElement radiobutton2;
            radiobutton1 = driver.FindElements(By.CssSelector("input[name='news']")).First();  //////////////
            radiobutton2 = driver.FindElements(By.CssSelector("input[name='news']")).Last();
            if (!radiobutton1.Selected)
            {
                Console.WriteLine("First radiobutton is unchecked");
            }
            else throw new InvalidOperationException("First radiobutton is checked");

            if (radiobutton2.Selected)
            {
                Console.WriteLine("Second radiobutton is checked");
            }
            else throw new InvalidOperationException("Second radiobutton is unchecked");

            driver.Navigate().
                Refresh();

            IWebElement radiobuttonNo;
            radiobuttonNo = driver.FindElement(By.Id("no"));
            if (!radiobuttonNo.Selected)
            {
                Console.WriteLine("'No' radiobutton is not selected");
            }
            else throw new InvalidOperationException("'No' radiobutton is selected");

            string textvalue = driver.FindElements(By.Name("age"))[1].Text;
           
            driver.FindElement(By.CssSelector("[href*='home.html']"))
                .Click();

            string editAttribute = driver.FindElement(By.CssSelector("[href*='pages/Edit.html']"))
                .GetAttribute("href");
            Console.WriteLine("Attribute of Edit section: " + editAttribute);

            driver.Quit();
        }
    }
}
