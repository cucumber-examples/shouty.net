using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Shouty;

namespace ShoutyFeatures
{
    [Binding]
    public class UserHearsShoutSteps
    {
        private ShoutyMainApi shouty = new ShoutyMainApi();

        [Given(@"Lucy and Bob are (.*)m apart")]
        public void GivenLucyAndBobAreMApart(int distance)
        {
            shouty.SetLocation("Lucy", 0);
            shouty.SetLocation("Bob", distance);
        }

        [When(@"Bobs shouts ""(.*)""")]
        public void WhenBobsShouts(string message)
        {
            shouty.Shout("Bob", message);
        }

        [Then(@"Lucy hears ""(.*)""")]
        public void ThenLucyHears(string message)
        {
            Assert.That(shouty.messagesHeard("Lucy"), Contains.Item(message));
        }

        [Then(@"Lucy doesn't hear anything")]
        public void ThenLucyDoesnTHearAnything()
        {
            Assert.That(shouty.messagesHeard("Lucy"), Is.Empty);
            // Assert.Equals(shouty.messagesHeard("Lucy").count, 0);
        }
    }
}
