using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Globalization;

namespace ProjectName.Stranice
{
    public class RegistracijaStranica
    {
        private readonly IWebDriver driver;
        private readonly string mojRacunUrl = "https://mistparfumerija.ba/moj-racun/";

        public RegistracijaStranica(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OtvoriMojRacunStranicu()
        {
            driver.Navigate().GoToUrl(mojRacunUrl);
        }

        public void OtvoriRegistracijaStranicu()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var dugmeRegistracija = wait.Until(d => d.FindElement(By.XPath("//a[@href='#registerTab']")));
            dugmeRegistracija.Click();
        }

        public void RegistracijaKorisnika(string email, string lozinka)
        {
            var poljeEmailRegistracija = driver.FindElement(By.Id("reg_email"));
            poljeEmailRegistracija.Clear();
            poljeEmailRegistracija.SendKeys(email);
            var poljeLozinkaRegistracija = driver.FindElement(By.Id("reg_password"));
            poljeLozinkaRegistracija.Clear();
            poljeLozinkaRegistracija.SendKeys(lozinka);
            var dugmeRegistracija = driver.FindElement(By.Id("register-btn"));
            dugmeRegistracija.Click();
        }

        public bool RegistracijaUspjesna()
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    var successMessageElement = driver.FindElement(By.CssSelector(".alert-success"));
                    if (successMessageElement.Displayed)
                    {
                        return successMessageElement.Text.Contains("Aktivirajte vaš račun klikom na link u e-mailu");
                    }
                    System.Threading.Thread.Sleep(1000);
                }

                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}