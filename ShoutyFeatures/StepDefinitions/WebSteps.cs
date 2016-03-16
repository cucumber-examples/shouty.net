using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Shouty;
using TechTalk.SpecFlow;

namespace ShoutyFeatures.StepDefinitions
{
    [Binding, Scope(Tag = "web")]
    public class WebSteps
    {
        private readonly IWebDriver webDriver = new FirefoxDriver();
        private const string baseUrl = "http://localhost:13636";

        [Given(@"(.*) is at (.*)")]
        public void GivenPersonIsAt(string name, Location location)
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

        [When(@"Fred shouts")]
        public void WhenFredShouts()
        {
            GoToPersonPage("Fred");

            var messageTextBox = webDriver.FindElement(By.Id("message"));
            messageTextBox.SendKeys("hello world!");

            messageTextBox.Submit();
        }

        [Then(@"Linda should hear nothing")]
        public void ThenLindaShouldHearNothing()
        {
            var messages = GetHeardMessages("Linda");
            Assert.AreEqual(0, messages.Count, "Should hear nothing");
        }

        [Then(@"Linda should hear Fred’s shout")]
        public void ThenLindaShouldHearFredSShout()
        {
            var messages = GetHeardMessages("Linda");
            CollectionAssert.Contains(messages, "hello world!", "should hear the message");
        }

        private List<string> GetHeardMessages(string name)
        {
            GoToPersonPage(name);
            var messages = webDriver.FindElements(By.ClassName("message")).Select(e => e.Text).ToList();
            return messages;
        }

        [BeforeScenario]
        public void ResetApp()
        {
            webDriver.Navigate().GoToUrl(baseUrl + "/api/TestReset");
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            webDriver.Quit();
        }
    }
}
