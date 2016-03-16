using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Shouty;
using ShoutyFeatures.StepDefinitions;

namespace ShoutyFeatures
{
    [Binding]
    public class ShoutSteps
    {
        private readonly IShoutyApi shoutyApi;

        public ShoutSteps(IShoutyApi shoutyApi)
        {
            this.shoutyApi = shoutyApi;
        }

        [Given(@"(.*) is at (.*)")]
        public void GivenPersonIsAt(string name, Location location)
        {
            shoutyApi.SetLocation(name, location);
        }

        [Given(@"Linda is (.*)m away from Fred")]
        public void GivenLindaIsMAwayFromFred(int distanceInMetres)
        {
            shoutyApi.SetLocation("Fred", new Location(0, 0));
            shoutyApi.SetLocation("Linda", new Location(0, distanceInMetres));
        }

        [When(@"Fred shouts")]
        public void WhenFredShouts()
        {
            shoutyApi.Shout("Fred", "hello world!");
        }

        [Then(@"Linda should hear nothing")]
        public void ThenLindaShouldHearNothing()
        {
            var messages = shoutyApi.GetMessages("Linda");
            Assert.AreEqual(0, messages.Count, "Should hear nothing");
        }

        [Then(@"Linda should hear Fred’s shout")]
        public void ThenLindaShouldHearFredSShout()
        {
            var messages = shoutyApi.GetMessages("Linda");
            CollectionAssert.Contains(messages, "hello world!", "should hear the message");
        }
    }
}
