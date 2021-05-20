using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Shouty.Specs
{
    [Binding]
    public class ShoutStepDefinitions
    {
        private const string ARBITRARY_MESSAGE = "Hello, world";
        private readonly ShoutyContext shoutyContext;

        public ShoutStepDefinitions(ShoutyContext shoutyContext)
        {
            this.shoutyContext = shoutyContext;
        }

        [When(@"{word} shouts")]
        public void WhenPersonShouts(string name)
        {
            shoutyContext.Shouty.Shout(name, ARBITRARY_MESSAGE);
        }

        [Then("Lucy should not hear Oscar")]
        public void ThenLucyShouldNotHearOscar()
        {
            Assert.IsFalse(shoutyContext.Shouty.GetShoutsHeardBy("Lucy").ContainsKey("Oscar"));
        }

        [Then(@"Lucy should hear Sean")]
        public void ThenLucyShouldHearSean()
        {
            Assert.AreEqual(1, shoutyContext.Shouty.GetShoutsHeardBy("Lucy").Count);
        }

        [Then(@"Lucy should hear nothing")]
        public void ThenLucyShouldHearNothing()
        {
            Assert.AreEqual(0, shoutyContext.Shouty.GetShoutsHeardBy("Lucy").Count);
        }

        [Then("Lucy should hear {int} shouts from Sean")]
        public void ThenLucyShouldHearShoutsFromSean(int expectedNumberOfShouts)
        {
            var shoutsHeard = shoutyContext.Shouty.GetShoutsHeardBy("Lucy");
            var shoutsByShouter = shoutsHeard["Sean"];
            Assert.AreEqual(expectedNumberOfShouts, shoutsByShouter.Count);
        }
    }
}
