using System;
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
            //_browser.Navigate().GoToUrl(WebHooks.Url + "/people/John");
        }

        [Given(@"the following locations:")]
        public void GivenTheFollowingLocations(Table table)
        {
            throw new Exception("FIXME");
        }

        [Given(@"(.*) is around")]
        public void GivenPersonIsAround(string personName)
        {
            throw new Exception("FIXME");
        }

        [Given(@"(.*) is in (.*)")]
        public void GivenPersonIsInLocation(string personName, string locationName)
        {
            throw new Exception("FIXME");
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