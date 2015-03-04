using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ShoutyFeatures
{
    [Binding, Scope(Tag = "web")]
    public class ShoutWebSteps
    {
        private IWebDriver _browser;

        public ShoutWebSteps(BrowserContext browserContext)
        {
            _browser = browserContext.Browser;
        }

        private readonly Dictionary<string, double[]> _geoLocations = new Dictionary<string, double[]>();

        [Given(@"the following locations:")]
        public void GivenTheFollowingLocations(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                var locationName = tableRow["name"];
                var lat = Double.Parse(tableRow["lat"]);
                var lon = Double.Parse(tableRow["lon"]);
                _geoLocations.Add(locationName, new[] { lat, lon });
            }
        }

        [Given(@"(.*) is around")]
        public void GivenPersonIsAround(string personName)
        {
            GoToPersonsPage(personName);
            Thread.Sleep(1000);
        }

        private void GoToPersonsPage(string personName)
        {
            _browser.Navigate().GoToUrl(WebHooks.Url + "/people/" + personName);
        }

        [Given(@"(.*) is in (.*)")]
        public void GivenPersonIsInLocation(string personName, string locationName)
        {
            var geoLocation = _geoLocations[locationName];
            _browser.Navigate().GoToUrl(
                WebHooks.Url + "/people/" + personName + "?lat=" + geoLocation[0] + "&lon=" + geoLocation[1]);
            Thread.Sleep(1000);
        }

        [When(@"(.*) shouts")]
        public void WhenPersonShouts(string personName)
        {
            GoToPersonsPage(personName);
            var messageField = _browser.FindElement(By.Name("message"));
            messageField.SendKeys("Hello from " + personName);
            messageField.Submit();
            Thread.Sleep(1000);
        }

        [When(@"(.*) shouts ""(.*)""")]
        public void WhenPersonShouts(string personName, string message)
        {
            throw new Exception("FIXME");
        }

        [Then(@"(.*) should hear:")]
        public void ThenPersonShouldHear(string personName, Table expectedShoutsTable)
        {
            throw new Exception("FIXME");
        }

        [Then(@"(.*) should not hear anything")]
        public void ThenPersonShouldNotHearAnything(string personName)
        {
            GoToPersonsPage(personName);
            ReadOnlyCollection<IWebElement> lis = _browser.FindElements(By.CssSelector("#messages li"));
            Assert.AreEqual(new List<IWebElement>(), lis);
        }

        [Then(@"(.*) should hear ""(.*)""")]
        public void ThenPerspnShouldHearMessage(string personName, string expectedMessage)
        {
            throw new Exception("FIXME");
        }

        [After]
        public void SleepIfFailed()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                Thread.Sleep(20000);
            }
        }
    }
}