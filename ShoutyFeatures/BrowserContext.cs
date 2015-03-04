using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace ShoutyFeatures
{
    public class BrowserContext
    {
        private IWebDriver _browser = new InternetExplorerDriver();

        public IWebDriver Browser
        {
            get
            {
                return _browser;   
            }
        }
    }
}
