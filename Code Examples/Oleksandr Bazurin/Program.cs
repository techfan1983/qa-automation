using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumBasics2
{
    public static class Examples
    {
        public static void Main(string[] args)
        {
            // Wrapping driver instance in using operator
            using (IWebDriver driver = new FirefoxDriver())
            {
                //XPathExpessions(driver);

                //CssExpessions(driver);

                //ImplicitWaits(driver);

                //ExplicitWaits(driver);

                //SelectElements(driver);

                //Form(driver);

                //Checkbox(driver);

                Practise(driver);
            }
        }

        public static void XPathExpessions(IWebDriver driver)
        {
            // Navigate to test Url
            driver.Navigate().GoToUrl($"https://atata-framework.github.io/atata-sample-app/#!/plans");

            // Finding element Basic by absolute path
            IWebElement basic = driver.FindElement(By.XPath("html/body/div/div/div/div/h3"));

            // Finding element Basic by relative path
            IWebElement basic2 = driver.FindElement(By.XPath("//h3"));

            // Finding element Atata Sample App by direct hierarchy
            IWebElement name = driver.FindElement(By.XPath("//nav/div/div/a"));

            // Finding element Atata Sample App by any level hierarchy
            IWebElement name2 = driver.FindElement(By.XPath("//nav//a"));

            // Finding element Plus by text
            IWebElement plus = driver.FindElement(By.XPath("//*[text()='Plus']"));

            // Finding element navigation bar by id attribute value and tag
            IWebElement navigationBar = driver.FindElement(By.XPath("//div[@id='navbar']"));

            // Finding span elements with position higher than 3 by class attribute and tag
            List<IWebElement> spansWithClass = driver.FindElements(By.XPath("//span[@class and position() > 3] ")).ToList();

            // Finding Plan divs by class attribute value, tag and using parent
            List<IWebElement> planDivs = driver.FindElements(By.XPath("//b[@class='price']/..")).ToList();
        }

        public static void CssExpessions(IWebDriver driver)
        {
            // Navigate to test Url
            driver.Navigate().GoToUrl($"https://atata-framework.github.io/atata-sample-app/#!/plans");

            // Finding element Basic by absolute path
            IWebElement basic = driver.FindElement(By.CssSelector("html body div div div div h3"));

            // Finding element Basic by relative path 
            IWebElement basic2 = driver.FindElement(By.CssSelector("h3"));

            // Finding element Atata Sample App by direct hierarchy
            IWebElement name = driver.FindElement(By.CssSelector("nav > div > div > a"));

            // Finding element Atata Sample App by any level hierarchy
            IWebElement name2 = driver.FindElement(By.CssSelector("nav a"));

            // Finding element navigation bar by id
            IWebElement navigationBar = driver.FindElement(By.CssSelector("div#navbar"));

            // Finding element navigation bar header by class
            IWebElement navigationBarHeader = driver.FindElement(By.CssSelector("div.navbar-header"));

            // Finding Basic price element by class attribute value and tag
            IWebElement price = driver.FindElement(By.CssSelector("b[class='price']"));

            // Finding link elements by href attribute
            List<IWebElement> links = driver.FindElements(By.CssSelector("[href]")).ToList();

            // Finding features element by class attribute value start and tag
            IWebElement features = driver.FindElement(By.CssSelector("ul[class^='feature-']"));

            // Finding features element by class attribute value end and tag
            IWebElement features2 = driver.FindElement(By.CssSelector("ul[class$='re-list']"));

            // Finding features element by class attribute partial value and tag
            IWebElement features3 = driver.FindElement(By.CssSelector("ul[class*='ture-li']"));
        }

        public static void ImplicitWaits(IWebDriver driver)
        {
            // Set driver timeout for implicit wait to 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            // Navigate to test Url
            driver.Navigate().GoToUrl($"http://localhost:6061/Home/Index");

            // Find temporary unavailable button by name
            IWebElement element = driver.FindElement(By.Name("button"));

            // Set driver timeout for implicit wait to 0 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public static void ExplicitWaits(IWebDriver driver)
        {
            // Navigate to test Url
            driver.Navigate().GoToUrl($"http://localhost:6061/Home/Index");

            // Create WebDriverWait object with timeout of 20 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            // Find temporary unavailable button by name using WebDriverWait object
            IWebElement element = wait.Until(d => d.FindElement(By.Name("button")));

            element = wait.Until((d) =>
            {
                if (d.FindElement(By.Name("button")).Text == "35")
                    return d.FindElement(By.Name("button"));
                else
                    return null;
            });
        }

        public static void SelectElements(IWebDriver driver)
        {
            // Navigate to test Url
            driver.Navigate().GoToUrl($"http://www.leafground.com/pages/Dropdown.html");

            // Finding DropDown element by id
            IWebElement element = driver.FindElement(By.Id("dropdown1"));

            // Creating SelectElement object from found dropdown element
            SelectElement selectElement = new SelectElement(element);

            // Selecting "Selenium" option by text
            selectElement.SelectByText("Selenium");

            // Getting selected option text
            string selectedOption = selectElement.SelectedOption.Text;

            // Finding Multiple Select element by Xpath
            element = driver.FindElement(By.XPath("//*[@multiple]"));

            // Creating SelectElement object from found Multiple Select element
            selectElement = new SelectElement(element);

            // Selecting "Appium" option by text
            selectElement.SelectByText("Appium");

            // Deselecting option by index of 2
            selectElement.DeselectByIndex(2);

            // Selecting option by index of 1
            selectElement.SelectByIndex(1);

            // Getting list of selected option elements
            List<IWebElement> selectedOptions = selectElement.AllSelectedOptions.ToList();

            // Deselecting all options
            selectElement.DeselectAll();
        }

        public static void Form(IWebDriver driver)
        {
            // Navigate to test Url
            driver.Navigate().GoToUrl($"http://www.seleniumframework.com/Practiceform/");

            // Finding name element of form by name
            IWebElement name = driver.FindElement(By.Name("name"));

            // Fiiling name element
            name.SendKeys("opa");

            // Finding email element of form by Xpath
            IWebElement email = driver.FindElement(By.XPath("//input[@placeholder = 'E-mail *']"));

            // Fiiling email element
            email.SendKeys("opa");

            // Finding telephone element of form by name
            IWebElement telephone = driver.FindElement(By.Name("telephone"));

            // Fiiling telephone element
            telephone.SendKeys("chirik");

            // Submiting whole form by using Submit() method on one of forms descendants
            telephone.Submit();
        }

        public static void Checkbox(IWebDriver driver)
        {
            // Navigate to test Url
            driver.Navigate().GoToUrl($"http://www.leafground.com/pages/checkbox.html");

            // Finding checkbox element by Xpath 
            IWebElement check = driver.FindElement(By.XPath("//label[text()='Confirm Selenium is checked']/../input"));

            // Getting value of checkbox element
            bool value = check.Selected;

            if (value)
            {
                // Changing value of checkbox element to not selected if it is selected
                check.Click();
            }

            // Finding checkbox elements by Xpath 
            List<IWebElement> checkList = driver.FindElements(By.XPath("//label[text()='Select all below checkboxes ']/../input")).ToList();


            // Selecting checkbox element with index of 1
            checkList[1].Click();

            // Changing value of checkbox elements to selected if it is not selected
            checkList.ForEach((e) =>
            {
                if (!e.Selected)
                    e.Click();
            });
        }

        public static void Practise(IWebDriver driver)
        {
            /*   Get elements from https://atata-framework.github.io/atata-sample-app/#!/products
             *   under column Amount that have number 5 in their text using XPath 
             *   and CSS selectors   */
            driver.Navigate().GoToUrl("https://atata-framework.github.io/atata-sample-app/#!/products");
            var ProductsXpathElements = driver.FindElements(By.XPath("//tr/td[3][contains(text(),'5')]")).ToList();
            Console.WriteLine($"Count of products where Amount contains the '5' digit By XPath: {ProductsXpathElements.Count}");
            var ProductsCssElements = driver.FindElements(By.CssSelector("tr td:nth-child(3)")).Where(x => x.Text.Contains("5")).ToList();
            Console.WriteLine($"Count of products where Amount contains the '5' digit By CSS Selector: {ProductsXpathElements.Count}");
            var dict = new Dictionary<string, int>();
            /*   Get from https://atata-framework.github.io/atata-sample-app/#!/plans
             *   numbers of projects from payment plans using XPath and CSS selectors    */

            driver.Navigate().GoToUrl(" https://atata-framework.github.io/atata-sample-app/#!/plans");
            var plansXpathElements = driver.FindElements(By.XPath("//b[@class='projects-num']")).ToList();
            Console.WriteLine("Number of projects in plans. ByXpath:");
            foreach (var item in plansXpathElements)
            {
                Console.WriteLine(item.Text);
            }

            var plansCssElements = driver.FindElements(By.CssSelector(".projects-num")).ToList();
            Console.WriteLine("Number of projects in plans. ByCSS:");
            foreach (var item in plansCssElements)
            {
                Console.WriteLine(item.Text);
            }

            /*   get timer element from http://www.seleniumframework.com/Practiceform/ 
             *   when there is 35 seconds remaining Explicitly 
             *   and when there is 30 seconds remaining Implicitly   */

            int secondsToWaitImplicity = 10;
            int secondsToWaitExplicity = 10;

            driver.Navigate().GoToUrl("http://www.seleniumframework.com/Practiceform/");
            WebDriverWait expWait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWaitExplicity));
            var expElement = expWait.Until((d) =>
            {
                if (d.FindElement(By.Id("clock")).Text == "Seconds remaining: 35")
                    return d.FindElement(By.Id("clock"));
                else
                    return null;
            });
            Console.WriteLine(expElement.Text);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWaitImplicity);
            var impElement = driver.FindElement(By.XPath("//span[@id='clock'][contains(text(),'30')]"));
            Console.WriteLine(impElement.Text);

            /*   From https://tern.gp.gov.ua/ua/search.html
             *   select "За зменьшенням" from search dropdown and 
             *   select "Сортувати по: Даті" RadioButton    */

            driver.Navigate().GoToUrl("https://tern.gp.gov.ua/ua/search.html");

            IWebElement element = driver.FindElement(By.Name("order"));
            SelectElement selectElement = new SelectElement(element);

            selectElement.SelectByText("За зменьшенням");

            var radios = driver.FindElements(By.ClassName("label-option"));

            var radioTitle = radios.Where(x => x.GetAttribute("value").Equals("date")).FirstOrDefault();
            radioTitle.Click();

            /*  From http://www.seleniumframework.com/Practiceform/
             *  fill in and submit "Subscribe" form     */
            driver.Navigate().GoToUrl("http://www.seleniumframework.com/Practiceform/");

            var email = driver.FindElement(By.XPath("//input[@value='Subscribe']/..//input[@name='email']"));
            email.SendKeys("vasyl.romaniuk@fortegrp.net");
            email.Submit();
        }
    }
}