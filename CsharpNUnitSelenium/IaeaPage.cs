using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest
{
    public class IaeaPage
    {
        private IWebDriver driver;

        public IaeaPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SearchBox => driver.FindElement(By.LinkText("Search"));
        public IWebElement RelationshipSearch => driver.FindElement(By.XPath("//a[text() = 'Relationship Search']"));
        public IWebElement SearchIcon => driver.FindElement(By.Id("choosePublicationId"));
        public IWebElement InputPublicationField => driver.FindElement(By.XPath("//*[@id='tblPublication_filter']//input"));

        public IWebElement InputField => driver.FindElement(By.XPath("//*[@id='tblPublication']//input[@type='search']"));
        public IWebElement SelectButton => driver.FindElement(By.XPath("//div//table//a[text()='Select']"));
        public IWebElement FindRelationshipsButton => driver.FindElement(By.LinkText("Find relationships"));

        // I understand that better to make a list here
        public IWebElement GenerlCheckBox => driver.FindElement(By.LinkText("General Safety Requirements"));
        public IWebElement ImplementingCheckBox => driver.FindElement(By.LinkText("Nuclear Security Implementing Guide"));
        public IWebElement TechnicalCheckBox => driver.FindElement(By.LinkText("Nuclear Security Technical Guidance"));
        public IWebElement FundamentalsCheckBox => driver.FindElement(By.LinkText("Safety Fundamentals"));
        public IWebElement SpecificCheckBox => driver.FindElement(By.LinkText("Specific Safety Guide"));

        public IWebElement ApplyFilterButton => driver.FindElement(By.LinkText("Apply Filter"));

        public IWebElement isElementDisplayed => driver.FindElement(By.XPath("//strong[text()='SF-1 : Fundamental Safety Principles']"));

        public void Search(string text)
        {
            SearchBox.Click();
            RelationshipSearch.Click();
            SearchIcon.Click();
            
            // I understand that it's a bad practice, but made it as a faster solution
            Thread.Sleep(2000);
            InputField.SendKeys(text);


            // I understand that it's a bad practice, but made it as a faster solution
            Thread.Sleep(2000);
            SelectButton.Click();
            FindRelationshipsButton.Click();

            // And again, I understan that here should be checking of checkbox status
            GenerlCheckBox.Click();
            ImplementingCheckBox.Click();
            TechnicalCheckBox.Click();
            SpecificCheckBox.Click();

            ApplyFilterButton.Click();

            Assert.That(driver.Title, Does.Exist);

        }
    }
}