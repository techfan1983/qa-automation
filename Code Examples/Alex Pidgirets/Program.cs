using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HomeWork_AlexPidgirets
{
    public static class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = null;
            //HomeWork1(driver);
            HomeWork2(driver);
        }

        public static void HomeWork2(IWebDriver driver)
        {
            driver = new ChromeDriver();
            /*   Get elements from https://atata-framework.github.io/atata-sample-app/#!/products
             *   under column Amount that have number 5 in their text using XPath 
             *   and CSS selectors   */

            driver.Navigate().GoToUrl("https://atata-framework.github.io/atata-sample-app/#!/products");

            List<IWebElement> Text5ListCSS = driver.FindElements(By.CssSelector("tbody td:nth-of-type(3)")).ToList();
            int Text5Count = Text5ListCSS.Count;

            for (int i = 0; i <= Text5Count - 1; i++)
            {
                string Text5Value = Text5ListCSS[i].Text;
                if (Text5Value.Contains('5'))
                Console.Out.WriteLine($"{Text5Value}, selected with CSS");

            }

            List<IWebElement> Text5ListXpath = driver.FindElements(By.XPath("//table//td[3][contains(text(),'5')]")).ToList();

            foreach (IWebElement element in Text5ListXpath)
            {
                Console.Out.WriteLine($"{element.Text}, selected with XPath");
            }

            /*   Get from https://atata-framework.github.io/atata-sample-app/#!/plans
             *   numbers of projects from payment plans using XPath and CSS selectors    */

            driver.Navigate().GoToUrl("https://atata-framework.github.io/atata-sample-app/#!/plans");

            //selecting with Xpath
            List<IWebElement> CssListPrice = driver.FindElements(By.CssSelector(".price")).ToList();
            List<IWebElement> CSSListNumOfPr = driver.FindElements(By.CssSelector(".price + p b")).ToList();

            for (int i=0; i<CssListPrice.Count; i++)
            {
                Double Payment; 
                    Double.TryParse(CssListPrice[i].Text.TrimStart('$'), out Payment);
                if (Payment > 0)
                    Console.Out.WriteLine($"There is Plan that costs {Payment} dollars and consists of {CSSListNumOfPr[i].Text} projects. " +
                        $"It's selected with CSS Selector");
            }
            //selecting with CSS
            List<IWebElement> XpathListPrice = driver.FindElements(By.XPath("//b[@class='price']/following-sibling::p/b")).ToList();

            for (int x=1; x<=3; x++)
            {
                string PaymWithXpath = driver.FindElement(By.XPath($"(//b[@class='price'])[{x}]")).Text;
                if (PaymWithXpath != "$0")
                    Console.Out.WriteLine($"There is paid plan for {PaymWithXpath} with " + 
                        driver.FindElement(By.XPath($"(//b[@class='price']/parent::div)[{x}]//b[@class='projects-num']")).Text + " projects. It's selected with XPath");
            }


            /*   get timer element from http://www.seleniumframework.com/Practiceform/ 
             *   when there is 35 seconds remaining Explicitly 
             *   and when there is 30 seconds remaining Implicitly   */

            driver.Navigate().GoToUrl("http://www.seleniumframework.com/Practiceform/");

            //explicit

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //IWebElement Timer35 = wait.Until(d => driver.FindElement(By.XPath("//span[@id='clock'][contains(text(),'35')]")));
            //Console.Out.WriteLine(Timer35.Text);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[@id='clock'][contains(text(),'35')]")));
            Console.Out.WriteLine("Timer 35 catched with explicit wait");

            //implicit
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            if (driver.FindElement(By.XPath("//span[@id='clock'][contains(text(),'30')]")).Displayed)
                Console.Out.WriteLine("Timer 30 catched with implicit wait");

            /*   From https://tern.gp.gov.ua/ua/search.html
             *   select "Za zmenshennyam" from search dropdown and 
             *   select "Sortuvaty po: Dati" RadioButton    */
            driver.Navigate().GoToUrl("https://tern.gp.gov.ua/ua/search.html");
            driver.FindElement(By.XPath("//select[@name='order']/option[@value='desc']")).Click();
            driver.FindElement(By.XPath("//input[@value='date']")).Click();

            /*  From http://www.seleniumframework.com/Practiceform/
             *  fill in and submit "Subscribe" form     */
            driver.Navigate().GoToUrl("http://www.seleniumframework.com/Practiceform/");
            driver.FindElement(By.XPath("//div[@class='textwidget']//input[@name='email']")).SendKeys("mail@mail.com");
            driver.FindElement(By.XPath("//input[@type='submit']")).Submit();

            Console.ReadKey();


        }

            public static void HomeWork1(IWebDriver driver)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.leafground.com/");

            driver.FindElement(By.LinkText("Edit")).Click();

            driver.FindElement(By.Id("email")).SendKeys("email@alex.com");

            driver.FindElements(By.Name("username")).First().Clear();

            IWebElement LastInput = driver.FindElements(By.TagName("input")).Last();
            if (LastInput.GetAttribute("disabled") == "true")
                Console.Out.WriteLine("Last input is disabled");

            driver.Navigate().Back();

            driver.FindElement(By.LinkText("Button")).Click();

            Console.Out.WriteLine("The url is " + driver.Url);

            IWebElement GoHomeButton = driver.FindElement(By.Id("home"));
            GoHomeButton.Click();

            driver.Navigate().Back();

            Console.Out.WriteLine("The color of third button is " + driver.FindElement(By.Id("color")).GetAttribute("style").Substring(driver.FindElement(By.Id("color")).GetAttribute("style").IndexOf(":")));
            //sorry, was just experimenting

            driver.Navigate().Back();

            driver.FindElement(By.LinkText("HyperLink")).Click();

            driver.FindElements(By.LinkText("Go to Home Page")).First().Click();

            driver.FindElement(By.LinkText("Radio Button")).Click();

            driver.FindElement(By.Id("no")).Click();

            if (!driver.FindElements(By.Name("news")).First().Selected)
                Console.Out.WriteLine("Unchecked radiobutton is unchecked");

            if (driver.FindElements(By.Name("news"))[1].Selected)
                Console.Out.WriteLine("Checked radiobutton is checked");

            driver.SwitchTo().DefaultContent();
            driver.Navigate().Refresh();

            if (driver.FindElement(By.Id("no")).Selected)
                Console.Out.WriteLine("'No' checkbox is unchecked");

            for (var i = 0; i < driver.FindElements(By.Name("age")).Count(); i++)
            {
                if (driver.FindElements(By.Name("age"))[i].Selected)
                    Console.Out.WriteLine("The text near checked age radiobutton is" + driver.FindElements(By.Name("age"))[i].Text);
            }
            //doesn't see text(

            driver.Navigate().Back();

            Console.Out.WriteLine("Class attribute of Edit Sections is " + driver.FindElement(By.LinkText("Edit")).GetAttribute("class"));

            Console.ReadKey();
            

        }

    }
}
