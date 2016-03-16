using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Shouty;

namespace ShoutyFeatures
{
    [Binding]
    public class ShoutSteps
    {
        [Given(@"Linda is (.*)m away from Fred")]
        public void GivenLindaIsMAwayFromFred(int distanceInMetres)
        {
            var shoutyApi = new ShoutyApi();
            shoutyApi.SetLocation("Fred", 0);
            shoutyApi.SetLocation("Linda", distanceInMetres);
        }

        [When(@"Fred shouts")]
        public void WhenFredShouts()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Linda should hear nothing")]
        public void ThenLindaShouldHearNothing()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
