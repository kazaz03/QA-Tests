using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ProjectName.Stranice
{
    public class KorpaStranica
    {
        private readonly IWebDriver driver;

        public KorpaStranica(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OtvoriKorpu()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var dugmeKorpa = wait.Until(d => d.FindElement(By.XPath("//a[@data-bs-toggle='offcanvas' and @href='#modalShoppingCart']")));
            dugmeKorpa.Click();
        }

        public void DodajUKorpu()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var dugmeDodajUKorpu = wait.Until(driver => driver.FindElement(By.Id("add-to-cart-btn")));
            dugmeDodajUKorpu.Click();
        }

        public bool ProvjeriProizvodUKorpi(string nazivProizvoda)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                return wait.Until(driver => driver.FindElement(By.XPath($"//a[contains(text(), '{nazivProizvoda}')]"))).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ObrisiProizvodIzKorpe()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var dugmeObrisi = wait.Until(d => d.FindElement(By.XPath("//svg[contains(@onclick, 'removeProduct(event,')]")));
            dugmeObrisi.Click();
        }

        public bool ProvjeriDaLiJeKorpaPrazna()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                var poruka = wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(), 'Tvoja korpa je prazna!')]")));
                return poruka.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}