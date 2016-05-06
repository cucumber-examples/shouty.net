using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty.Specs
{
    class UiDriver : IAppDriver
    {
        private IWebDriver browser = new FirefoxDriver();

        public void SetLocation(string name, Coordinate coordinate)
        {
            browser.Navigate().GoToUrl("http://www.google.com/");
        }

        public void Shout(string name, string message)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> GetMessagesHeardBy(string name)
        {
            throw new NotImplementedException();
        }


        public void cleanup()
        {
            browser.Quit();
        }
    }
}
