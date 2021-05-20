using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Shouty.Specs
{
    [Binding]
    public class Conversions
    {
        [StepArgumentTransformation]
        public PersonLocation[] ConvertPersonLocations(Table personLocationsTable)
        {
            return personLocationsTable.CreateSet<PersonLocation>().ToArray();
        }

        [StepArgumentTransformation(@"(.*), (.*)")]
        public Coordinate ConvertCoordinate(int xCoord, int yCoord)
        {
            return new Coordinate(xCoord, yCoord);
        }
    }
}
