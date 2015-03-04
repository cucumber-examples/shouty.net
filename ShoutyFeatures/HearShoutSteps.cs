using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouty;
using TechTalk.SpecFlow;

namespace ShoutyFeatures
{
    [Binding]
    public class HearShoutSteps
    {
        private readonly Broadcaster _broadcaster = new Broadcaster();

        private readonly Dictionary<string, Person> _people = new Dictionary<string, Person>();
        private readonly Dictionary<string, double[]> _locations = new Dictionary<string, double[]>();

        public HearShoutSteps()
        {
            _people.Add("Phil", new Person(_broadcaster));
            _people.Add("Sally", new Person(_broadcaster));
            _people.Add("Jeff", new Person(_broadcaster));
        }

        [Given(@"the following locations:")]
        public void GivenTheFollowingLocations(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                var locationName = tableRow["name"];
                var lat = Double.Parse(tableRow["lat"]);
                var lon = Double.Parse(tableRow["lon"]);
                _locations.Add(locationName, new[] { lat, lon });
            }
        }

        [Given(@"(.*) is in (.*)")]
        public void GivenSomeoneIsInLocation(string personName, string locationName)
        {
            var person = _people[personName];
            var geoLocation = _locations[locationName];
            person.GeoLocation = geoLocation;
        }

        [When(@"Jeff shouts")]
        public void WhenJeffShouts()
        {
            _people["Jeff"].Shout("hello");
        }

        [When(@"Sally shouts")]
        public void WhenSallyShouts()
        {
            _people["Sally"].Shout("sally's shout");
        }

        [When(@"Sally shouts ""(.*)""")]
        public void WhenSallyShouts(string message)
        {
            _people["Sally"].Shout(message);
        }

        [When(@"Jeff shouts ""(.*)""")]
        public void WhenJeffShouts(string message)
        {
            _people["Jeff"].Shout(message);
        }

        [Then(@"Phil should hear:")]
        public void ThenPhilShouldHear(Table expectedShoutsTable)
        {
            var expectedShouts = expectedShoutsTable.Rows.Select(row => row[0]);
            var actualShouts = _people["Phil"].MessagesHeard;
            Assert.AreEqual(expectedShouts, actualShouts);
        }


        [Then(@"Phil should not hear Jeff's shout")]
        public void ThenPhilShouldNotHearJeffSShout()
        {
            Assert.AreEqual(new List<string>(), _people["Phil"].MessagesHeard);
        }

        [Then(@"Phil should hear Sally's shout")]
        public void ThenPhilShouldHearSallySShout()
        {
            List<string> expected = new List<string> {"sally's shout"};
            Assert.AreEqual(expected, _people["Phil"].MessagesHeard);
        }
    }
}