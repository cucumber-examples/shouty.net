using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouty;
using TechTalk.SpecFlow;

namespace ShoutyFeatures
{
    [Binding, Scope(Tag = "api")]
    public class ShoutApiSteps
    {
        private readonly ShoutyApi _shoutyApi = new ShoutyApi();
        private readonly Dictionary<string, double[]> _geoLocations = new Dictionary<string, double[]>();

        [Given(@"the following locations:")]
        public void GivenTheFollowingLocations(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                var locationName = tableRow["name"];
                var lat = Double.Parse(tableRow["lat"]);
                var lon = Double.Parse(tableRow["lon"]);
                _geoLocations.Add(locationName, new[] { lat, lon });
            }
        }

        [Given(@"(.*) is around")]
        public void GivenPersonIsAround(string personName)
        {
            _shoutyApi.FindOrCreatePersonNamed(personName);
        }

        [Given(@"(.*) is in (.*)")]
        public void GivenPersonIsInLocation(string personName, string locationName)
        {
            var geoLocation = _geoLocations[locationName];
            _shoutyApi.PersonIsIn(personName, geoLocation);
        }

        [When(@"(.*) shouts")]
        public void WhenPersonShouts(string personName)
        {
            _shoutyApi.PersonShouts(personName, "Hello from " + personName);
        }

        [When(@"(.*) shouts ""(.*)""")]
        public void WhenPersonShouts(string personName, string message)
        {
            _shoutyApi.PersonShouts(personName, message);
        }

        [Then(@"(.*) should hear:")]
        public void ThenPersonShouldHear(string personName, Table expectedShoutsTable)
        {
            var expectedShouts = expectedShoutsTable.Rows.Select(row => row[0]);
            var actualShouts = _shoutyApi.MessagesHeardBy(personName);
            Assert.AreEqual(expectedShouts, actualShouts);
        }


        [Then(@"(.*) should not hear anything")]
        public void ThenPersonShouldNotHearAnything(string personName)
        {
            Assert.AreEqual(new List<string>(), _shoutyApi.MessagesHeardBy(personName));
        }

        [Then(@"(.*) should hear ""(.*)""")]
        public void ThenPerspnShouldHearMessage(string personName, string expectedMessage)
        {
            List<string> expected = new List<string> {expectedMessage};
            Assert.AreEqual(expected, _shoutyApi.MessagesHeardBy(personName));
        }
    }
}