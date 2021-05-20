using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        [StepArgumentTransformation]
        public PersonLocation[] ConvertPersonLocations(Table personLocationsTable)
        {
            return personLocationsTable.CreateSet<PersonLocation>().ToArray();
        }

        [Given(@"{word} is at {int}, {int}")]
        public void GivenPersonIsAt(string name, int xCoord, int yCoord)
        {
            shoutyContext.Shouty.SetLocation(name, new Coordinate(xCoord, yCoord));
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
