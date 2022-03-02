using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAssessment.WebPages
{
    public class HeroKuAppPage
    {
        #region Constants
        public const string Url = "http://the-internet.herokuapp.com/";
        #endregion Constants

        public HeroKuAppPage(ChromeDriver chromeDriver)
        {
            _chromeDriver = chromeDriver;
        }

        #region Fields
        private ChromeDriver _chromeDriver;
        private IWebElement ParentContainer => _chromeDriver.FindElement(By.Id("content"));
        private List<IWebElement> ChildElements => ParentContainer.FindElements(By.TagName("li")).ToList();
        #endregion Fields

        #region Properties
        public IWebElement AddOrRemoveElements => ChildElements.
            FirstOrDefault(x => x.Text == "Add/Remove Elements")?.
            FindElement(By.TagName("a"));
        #endregion Properties
    }
}
