using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ProjectName.Stranice
{
    public class HomeStranica
    {
        private readonly IWebDriver driver;

        public HomeStranica(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement PretragaInput()
        {
            return driver.FindElement(By.Id("custom-search-input"));
        }

        public void PretraziProizvod(string nazivProizvoda)
        {
            PretragaInput().SendKeys(nazivProizvoda);
        }

        public void OdaberiProizvodIzRezultata(string nazivProizvoda)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            var proizvod = wait.Until(driver => driver.FindElement(By.XPath($"//a[contains(., '{nazivProizvoda}')]")));
            proizvod.Click();
        }
    }
}