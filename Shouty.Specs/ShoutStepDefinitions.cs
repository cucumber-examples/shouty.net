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

        [Given("people are located at")]
        public void GivenPeopleAreLocatedAt(Table personLocations)
        {
            foreach (var row in personLocations.Rows)
            {
                shouty.SetLocation(
                    row["name"],
                    new Coordinate(
                        int.Parse(row["x"]),
                        int.Parse(row["y"])));
            }
        }

        [When(@"{word} shouts")]
        public void WhenPersonShouts(string name)
        {
            shouty.Shout(name, ARBITRARY_MESSAGE);
        }

        [Then("Lucy should not hear Oscar")]
        public void ThenLucyShouldNotHearOscar()
        {
            Assert.IsFalse(shouty.GetShoutsHeardBy("Lucy").ContainsKey("Oscar"));
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
