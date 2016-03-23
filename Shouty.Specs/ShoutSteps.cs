using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Shouty.Specs
{
    [Binding]
    public class ShoutSteps
    {
        private ShoutyApi shoutyApi;

        [Given(@"Joe is (.*)m away from Mary")]
        public void GivenJoeIsMAwayFromMary(int p0)
        {
        }

        [When(@"Mary shouts ""(.*)""")]
        public void WhenMaryShouts(string shout)
        {
            shoutyApi = new ShoutyApi();
            shoutyApi.Shout(shout);
        }

        [Then(@"Joe should receive ""(.*)""")]
        public void ThenJoeShouldReceive(string expectedShout)
        {
            var actualShouts = shoutyApi.GetReceivedShouts();
            CollectionAssert.Contains(actualShouts, expectedShout);
        }
    }
}
