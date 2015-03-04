using System;
using System.Collections.Generic;
using System.Threading;
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
            _browser.Navigate().GoToUrl(WebHooks.Url + "/people/" + personName);
        }

        [Given(@"(.*) is in (.*)")]
        public void GivenPersonIsInLocation(string personName, string locationName)
        {
            var geoLocation = _geoLocations[locationName];
            _browser.Navigate().GoToUrl(
                WebHooks.Url + "/people/" + personName + "?lat=" + geoLocation[0] + "&lon=" + geoLocation[1]);
        }

        [When(@"(.*) shouts")]
        public void WhenPersonShouts(string personName)
        {
            throw new Exception("FIXME");
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
            throw new Exception("FIXME");
        }

        [Then(@"(.*) should hear ""(.*)""")]
        public void ThenPerspnShouldHearMessage(string personName, string expectedMessage)
        {
            throw new Exception("FIXME");
        }
    }
}