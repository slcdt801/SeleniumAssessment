using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAssessment.WebPages
{
	public class AddOrRemoveElementsPage
	{
		public AddOrRemoveElementsPage(ChromeDriver chromeDriver)
		{
			_chromeDriver = chromeDriver;
		}

		#region Fields
		private ChromeDriver _chromeDriver;
		private IWebElement DeleteElementsContainer => _chromeDriver.FindElement(By.Id("elements"));
		#endregion Fields

		#region Properties
		public IWebElement ContentClass => _chromeDriver.FindElement(By.Id("content"));
		public List<IWebElement> DeleteButtons => DeleteElementsContainer?.FindElements(By.ClassName("added-manually")).ToList();
		public IWebElement AddElementButton => _chromeDriver.FindElement(By.TagName("button"));
		#endregion
	}
}
