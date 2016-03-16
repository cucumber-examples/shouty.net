using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Shouty;

namespace ShoutyFeatures
{
    [Binding]
    public class ShoutSteps
    {
        private readonly ShoutyApi shoutyApi = new ShoutyApi();

        [Given(@"Linda is (.*)m away from Fred")]
        public void GivenLindaIsMAwayFromFred(int distanceInMetres)
        {
            shoutyApi.SetLocation("Fred", 0);
            shoutyApi.SetLocation("Linda", distanceInMetres);
        }

        [When(@"Fred shouts")]
        public void WhenFredShouts()
        {
            shoutyApi.Shout("Fred", "hello world!");
        }

        [Then(@"Linda should hear nothing")]
        public void ThenLindaShouldHearNothing()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
