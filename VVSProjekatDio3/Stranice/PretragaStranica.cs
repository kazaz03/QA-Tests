using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ProjectName.Stranice
{
    public class PretragaStranica
    {
        private readonly IWebDriver driver;

        public PretragaStranica(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement PoljeZaPretragu => driver.FindElement(By.Id("custom-search-input"));

        public void UnesiUpitPretrage(string upit)
        {
            PoljeZaPretragu.Clear();
            PoljeZaPretragu.SendKeys(upit);
        }

        public bool RezultatPrikazan(string nazivProizvoda)
        {
            try
            {
                var rezultati = driver.FindElements(By.CssSelector("#search-results .search-result-hover a"));
                foreach (var rezultat in rezultati)
                    if (rezultat.Text.Contains(nazivProizvoda, StringComparison.OrdinalIgnoreCase))
                        return true;
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool NemaRezultata(string nazivProizvoda)
        {
            try
            {
                var rezultati = driver.FindElements(By.CssSelector("#search-results .search-result-hover a"));
                return !(rezultati.Count > 0);
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
    }
}