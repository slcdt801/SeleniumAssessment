using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumAssessment.WebPages;

namespace SeleniumAssessment
{
    public class Tests
    {
        private const string _chromeDriverDirectory = @"C:\DriverPath";

        private ChromeDriver _chromeDriver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            try
            {
                _chromeDriver = new ChromeDriver(_chromeDriverDirectory, options);
            }
            catch
            {
                _chromeDriver = new ChromeDriver(@"./", options);
            }

            _chromeDriver.Navigate().GoToUrl(HeroKuAppPage.Url);
        }


        // Pass in desired and expected delete buttons to add
        [TestCase(5)]
        [Test, Author("Osmar Roman")]
        public void VerifyDeleteButtonsAdded(int numberOfElementsToAdd)
        {
            var heroKuAppPage = new HeroKuAppPage(_chromeDriver);
            var addOrRemoveElementsPage = new AddOrRemoveElementsPage(_chromeDriver);

            Assert.True(heroKuAppPage.AddOrRemoveElements.Displayed,
                $"{nameof(heroKuAppPage.AddOrRemoveElements)} link was not displayed on the home page.");

            heroKuAppPage.AddOrRemoveElements.Click();

            Assert.True(addOrRemoveElementsPage.AddElementButton.Displayed,
                $"{nameof(addOrRemoveElementsPage.AddElementButton)} button was not displayed on the Add or Remove Elements page.");

            for (int i = 0; i < numberOfElementsToAdd; i++)
            {
                addOrRemoveElementsPage.AddElementButton.Click();
            }

            var countOfDeleteButtons = addOrRemoveElementsPage.DeleteButtons.Count;

            Assert.AreEqual(countOfDeleteButtons, numberOfElementsToAdd,
                $"Expected {numberOfElementsToAdd} delete buttons on the page, " +
                $"but {countOfDeleteButtons} delete buttons were found instead.");
        }

        [TearDown]
        public void TearDown()
        {
            _chromeDriver?.Close();
        }
    }
}