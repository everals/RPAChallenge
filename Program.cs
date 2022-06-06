using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace RPAChallenge
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var employees = CSVParser.ParseEmployees("EmployeeInformation.csv");

			var driver = new ChromeDriver() { Url = "https://rpachallenge.com" };

			var formFiller = new FormFiller(driver);

			var startButton = driver.FindElement(By.TagName("button"));
			var submitButton = driver.FindElement(By.CssSelector($"[value=\"Submit\"]"));

			startButton.Click();
			formFiller.FillForms(inputsNames, employees, submitButton);
		}

		private static readonly List<string> inputsNames = new List<string>()
		{
			"labelFirstName", "labelLastName", "labelCompanyName", "labelRole", "labelAddress", "labelEmail",
			"labelPhone"
		};
	}
}
