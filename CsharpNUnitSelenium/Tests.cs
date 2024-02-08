using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-notifications");
            chromeOptions.AddArguments("--lang=en-US"); 
            driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("https://nucleus-apps.iaea.org/nss-oui/collections/relationship");
        }

        [Test]
        public void Test1()
        {
            var iaeaPage = new IaeaPage(driver);
            iaeaPage.Search("GSR Part 2");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}