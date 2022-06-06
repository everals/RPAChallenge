using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace RPAChallenge
{
	internal class FormFiller
	{
		public FormFiller(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void FillForms(List<string> inputsNames, IEnumerable<Employee> employees, IWebElement submitButton)
		{
			foreach (var employee in employees)
			{
				var form = GetInputForm(driver, inputsNames);
				FillForm(form, employee);
				submitButton.Click();
			}
		}

		private static Dictionary<string, IWebElement> GetInputForm(ISearchContext driver, IEnumerable<string> inputsNames)
		{
			var inputForm = new Dictionary<string, IWebElement>();

			foreach (var inputName in inputsNames)
			{
				var webElement = driver.FindElement(By.CssSelector($"[ng-reflect-name=\"{inputName}\"]"));
				inputForm.Add(inputName, webElement);
			}

			return inputForm;
		}

		private static void FillForm(IReadOnlyDictionary<string, IWebElement> inputs, Employee employee)
		{
			foreach (var (inputName, webElement) in inputs)
			{
				webElement.SendKeys(employee.GetFieldValue(inputName));
			}
		}

		private IWebDriver driver;
	}
}
