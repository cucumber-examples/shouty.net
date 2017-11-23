using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Shouty.Specs
{
    [Binding]
    public class ShoutSteps
    {
        private const string ARBITRARY_MESSAGE = "Hello, world";
        private readonly ShoutyNetwork shouty = new ShoutyNetwork();

        [Given(@"Lucy is at (.*), (.*)")]
        public void GivenLucyIsAt(int xCoord, int yCoord)
        {
            shouty.SetLocation("Lucy", new Coordinate(xCoord, yCoord));
        }

        [Given(@"Sean is at (.*), (.*)")]
        public void GivenSeanIsAt(int xCoord, int yCoord)
        {
            shouty.SetLocation("Sean", new Coordinate(xCoord, yCoord));
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
