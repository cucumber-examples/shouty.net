using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace ShoutyFeatures
{
    public class BrowserContext
    {
        //private readonly IWebDriver _browser = new ChromeDriver("../..");
        private readonly IWebDriver _browser = new InternetExplorerDriver("../..");

        public IWebDriver Browser
        {
            get
            {
                return _browser;   
            }
        }
    }
}
