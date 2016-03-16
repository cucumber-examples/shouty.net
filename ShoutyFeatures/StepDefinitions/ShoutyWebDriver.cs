using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Shouty;

namespace ShoutyFeatures.StepDefinitions
{
    class ShoutyWebDriver : IShoutyApi
    {
        private readonly IWebDriver webDriver = new FirefoxDriver();
        private const string baseUrl = "http://localhost:13636";

        public ShoutyWebDriver()
        {
            webDriver.Navigate().GoToUrl(baseUrl + "/api/TestReset");
        }

        public void SetLocation(string name, Location location)
        {
            GoToPersonPage(name);
            var latTextBox = webDriver.FindElement(By.Id("lat"));
            latTextBox.SendKeys(location.Lat.ToString());

            var lonTextBox = webDriver.FindElement(By.Id("lon"));
            lonTextBox.SendKeys(location.Lon.ToString());

            lonTextBox.Submit();
        }

        private void GoToPersonPage(string name)
        {
            webDriver.Navigate().GoToUrl(baseUrl + "/Person/Index/" + name);
        }

        public void Shout(string name, string message)
        {
            GoToPersonPage(name);

            var messageTextBox = webDriver.FindElement(By.Id("message"));
            messageTextBox.SendKeys(message);

            messageTextBox.Submit();
        }

        public List<string> GetMessages(string name)
        {
            GoToPersonPage(name);
            var messages = webDriver.FindElements(By.ClassName("message")).Select(e => e.Text).ToList();
            return messages;
        }

        public void Dispose()
        {
            webDriver.Quit();
        }
    }
}
