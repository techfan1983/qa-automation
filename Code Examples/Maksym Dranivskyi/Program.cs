using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace HomeWork_Selenium_1_Maksym_Dranivskyi
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.leafground.com/");

            driver.FindElement(By.LinkText("Edit")).Click();

            driver.FindElement(By.Id("email")).SendKeys("test@gmail.com");

            driver.FindElement(By.Name("username")).Clear();

            var checkInput = driver.FindElements(By.TagName("input"));
            if (!checkInput.Last().Enabled)
                Console.WriteLine("Last input element is disabled");

            driver.Navigate().Back();

            driver.FindElement(By.LinkText("Button")).Click();

            var pageUrl = driver.Url;
            Console.WriteLine(pageUrl);

            driver.FindElement(By.Id("home")).Click();

            driver.Navigate().Back();

            var cssValue = driver.FindElement(By.Id("color")).GetCssValue("background-color");
            Console.WriteLine(cssValue);

            driver.Navigate().Back();

            driver.FindElement(By.LinkText("HyperLink")).Click();

            driver.FindElement(By.LinkText("Go to Home Page")).Click();

            driver.FindElement(By.LinkText("Radio Button")).Click();

            driver.FindElement(By.Id("no")).Click();

            var radioNews = driver.FindElements(By.Name("news"));
            var uncheckedSelected = radioNews.First().Selected ? "selected" : "not selected";
            Console.WriteLine("Radio Unchecked is " + uncheckedSelected);
            var checkedSelected = radioNews.Last().Selected ? "selected" : "not selected";
            Console.WriteLine("Radio Checked is " + checkedSelected);

            driver.Navigate().Refresh();

            var radioNoSelected = driver.FindElement(By.Id("no")).Selected ? "selected" : "not selected";
            Console.WriteLine("Radio No is " + radioNoSelected);

            driver.Navigate().Back();

            var attributeEdit = driver.FindElement(By.LinkText("Edit")).GetAttribute("href");
            Console.WriteLine(attributeEdit);

            driver.Quit();
            Console.ReadLine();
        }
    }
}
