using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
	class Program
	{

		//IWebDriver driver = new ChromeDriver();


		static void Main(string[] args)
		{
			IWebDriver driver = new ChromeDriver();

			driver.Navigate().GoToUrl("http://www.leafground.com/pages/radio.html");

			var defaultSelectedRAdio = driver.FindElements(By.CssSelector("div.large-6.small-12.columns"));
			IWebElement getChecked = defaultSelectedRAdio[1];
			Console.WriteLine("Return text " + defaultSelectedRAdio);



			//var editMenu = driver.FindElement(By.PartialLinkText("Edit"));
			//editMenu.Click();

			//var enterEmail = driver.FindElement(By.Id("email"));
			//enterEmail.SendKeys("test.email@gmail.com");

			//var deleteInput = driver.FindElements(By.Name("username"));
			//deleteInput.Last().Clear();

			//var confirmThatDisabled = driver.FindElements(By.TagName("input"));

			//if(!confirmThatDisabled.Last().Enabled)
			//{
			//	Console.WriteLine("last input is disabled");
			//}

			//driver.Navigate().Back();

			//var buttonMenu = driver.FindElement(By.PartialLinkText("Button"));
			//buttonMenu.Click();

			//var pageUrl = driver.Url;

			//var goToHomeButton = driver.FindElement(By.Id("home"));
			//goToHomeButton.Click();

			//driver.Navigate().Back();

			//var getCssCollor = driver.FindElement(By.Id("color"));
			//String buttonColor = getCssCollor.GetCssValue("background-color");
			//Console.WriteLine("What color am I? " + buttonColor);


			//driver.Navigate().Back();

			//var hyperLinkMenu = driver.FindElement(By.PartialLinkText("HyperLink"));
			//hyperLinkMenu.Click();

			//var goToHomeLink = driver.FindElement(By.LinkText("Go to Home Page"));
			//goToHomeLink.Click();


			//driver.Navigate().Back();

			//var radioButtonMenu = driver.FindElement(By.PartialLinkText("Radio Button"));
			//radioButtonMenu.Click();

			//var clickNo = driver.FindElement(By.Id("no"));
			//clickNo.Click();




		}
	}
}
