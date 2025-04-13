using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjectName.Utils
{
    public class WebDriverManager
    {
        private static IWebDriver driver;

        private WebDriverManager() { }

        public static IWebDriver DajDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void UgasiDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}