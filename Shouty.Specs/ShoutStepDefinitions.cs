using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Shouty.Specs
{
    [Binding]
    public class ShoutStepDefinitions
    {
        private const string ARBITRARY_MESSAGE = "Hello, world";
        private readonly ShoutyNetwork shouty = new ShoutyNetwork();

        [Given(@"{word} is at {int}, {int}")]
        public void GivenPersonIsAt(string name, int xCoord, int yCoord)
        {
            shouty.SetLocation(name, new Coordinate(xCoord, yCoord));
        }

        [When(@"Sean shouts")]
        public void WhenSeanShouts()
        {
            shouty.Shout("Sean", ARBITRARY_MESSAGE);
        }

        [Then(@"Lucy should hear Sean")]
        public void ThenLucyShouldHearSean()
        {
            Assert.AreEqual(1, shouty.GetShoutsHeardBy("Lucy").Count);
        }

        [Then(@"Lucy should hear nothing")]
        public void ThenLucyShouldHearNothing()
        {
            Assert.AreEqual(0, shouty.GetShoutsHeardBy("Lucy").Count);
        }
    }
}
