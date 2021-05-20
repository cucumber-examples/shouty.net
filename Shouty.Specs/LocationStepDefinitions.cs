using System;
using TechTalk.SpecFlow;

namespace Shouty.Specs
{
    [Binding]
    public class LocationStepDefinitions
    {
        private readonly ShoutyContext shoutyContext;

        public LocationStepDefinitions(ShoutyContext shoutyContext)
        {
            this.shoutyContext = shoutyContext;
        }

        [Given(@"{word} is at {Coordinate}")]
        public void GivenPersonIsAt(string name, Coordinate coordinate)
        {
            shoutyContext.Shouty.SetLocation(name, coordinate);
        }

        [Given("people are located at")]
        public void GivenPeopleAreLocatedAt(PersonLocation[] personLocations)
        {
            foreach (var personLocation in personLocations)
            {
                shoutyContext.Shouty.SetLocation(personLocation.Name,
                    new Coordinate(personLocation.X, personLocation.X));
            }
        }
    }
}
