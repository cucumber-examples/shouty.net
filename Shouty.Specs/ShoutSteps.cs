using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Shouty.Specs
{
    [Binding]
    public class ShoutSteps
    {
        private readonly ShoutyApi shoutyApi = new ShoutyApi();

        [Given(@"Joe is (.*)m away from Mary")]
        public void GivenJoeIsMAwayFromMary(int distance)
        {
            shoutyApi.SetLocation("Joe", 0);
            shoutyApi.SetLocation("Mary", distance);
        }

        [When(@"Mary shouts ""(.*)""")]
        public void WhenMaryShouts(string shout)
        {
            shoutyApi.Shout("Mary", shout);
        }

        [Then(@"Joe should receive ""(.*)""")]
        public void ThenJoeShouldReceive(string expectedShout)
        {
            var actualShouts = shoutyApi.GetReceivedShouts("Joe");
            CollectionAssert.Contains(actualShouts, expectedShout);
        }

        [Then(@"Joe should not receive ""(.*)""")]
        public void ThenJoeShouldNotReceive(string expectedShout)
        {
            var actualShouts = shoutyApi.GetReceivedShouts("Joe");
            CollectionAssert.DoesNotContain(actualShouts, expectedShout);
        }

    }
}
