using NUnit.Framework;
using OpenQA.Selenium;
using ProjectName.Utils;

namespace ProjectName.Testovi
{
    public class TestnaBaza
    {
        protected IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = WebDriverManager.DajDriver();
            Driver.Navigate().GoToUrl("https://mistparfumerija.ba");
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverManager.UgasiDriver();
        }
    }
}