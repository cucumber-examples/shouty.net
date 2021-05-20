using System.Linq;
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

        [StepArgumentTransformation]
        public PersonLocation[] ConvertPersonLocations(Table personLocationsTable)
        {
            return personLocationsTable.Rows
                .Select(row => new PersonLocation
                {
                    Name = row["name"],
                    X = int.Parse(row["x"]),
                    Y = int.Parse(row["y"])
                })
                .ToArray();
        }

        [Given("people are located at")]
        public void GivenPeopleAreLocatedAt(PersonLocation[] personLocations)
        {
            foreach (var personLocation in personLocations)
            {
                shouty.SetLocation(personLocation.Name, 
                    new Coordinate(personLocation.X, personLocation.X));
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
