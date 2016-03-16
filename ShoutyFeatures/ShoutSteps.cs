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
            ScenarioContext.Current.Pending();
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
