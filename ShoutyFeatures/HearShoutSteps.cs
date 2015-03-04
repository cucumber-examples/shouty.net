using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ShoutyFeatures
{
    [Binding]
    public class HearShoutSteps
    {
        private Broadcaster broadcaster = new Broadcaster();

        private Dictionary<string, Person> people = new Dictionary<string, Person>();
        private Dictionary<string, double[]> locations = new Dictionary<string, double[]>();

        public HearShoutSteps()
        {
            people.Add("Phil", new Person(broadcaster));
            people.Add("Sally", new Person(broadcaster));
            people.Add("Jeff", new Person(broadcaster));
        }

        [Given(@"the following locations:")]
        public void GivenTheFollowingLocations(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                var locationName = tableRow["name"];
                var lat = Double.Parse(tableRow["lat"]);
                var lon = Double.Parse(tableRow["lon"]);
                locations.Add(locationName, new[] { lat, lon });
            }
        }

        [Given(@"(.*) is in (.*)")]
        public void GivenSomeoneIsInLocation(string personName, string locationName)
        {
            var person = people[personName];
            var geoLocation = locations[locationName];
            person.GeoLocation = geoLocation;
        }

        [When(@"Jeff shouts")]
        public void WhenJeffShouts()
        {
            people["Jeff"].Shout("hello");
        }

        [When(@"Sally shouts")]
        public void WhenSallyShouts()
        {
            people["Sally"].Shout("sally's shout");
        }

        [When(@"Sally shouts ""(.*)""")]
        public void WhenSallyShouts(string message)
        {
            people["Sally"].Shout(message);
        }

        [When(@"Jeff shouts ""(.*)""")]
        public void WhenJeffShouts(string message)
        {
            people["Jeff"].Shout(message);
        }

        [Then(@"Phil should hear:")]
        public void ThenPhilShouldHear(Table expectedShoutsTable)
        {
            var expectedShouts = expectedShoutsTable.Rows.Select(row => row[0]);
            var actualShouts = people["Phil"].MessagesHeard;
            Assert.AreEqual(expectedShouts, actualShouts);
        }


        [Then(@"Phil should not hear Jeff's shout")]
        public void ThenPhilShouldNotHearJeffSShout()
        {
            Assert.AreEqual(new List<string>(), people["Phil"].MessagesHeard);
        }

        [Then(@"Phil should hear Sally's shout")]
        public void ThenPhilShouldHearSallySShout()
        {
            List<string> expected = new List<string>();
            expected.Add("sally's shout");
            Assert.AreEqual(expected, people["Phil"].MessagesHeard);
        }
    }

    public class Person
    {
        private readonly Broadcaster broadcaster;
        private readonly List<string> messagesHeard = new List<string>();

        public Person(Broadcaster broadcaster)
        {
            this.broadcaster = broadcaster;
            this.GeoLocation = new[] {0.0, 0.0};
            broadcaster.Subscribe(this);
        }

        // TODO: Extract to GeoLocation class
        public double[] GeoLocation { get; set; }

        public List<string> MessagesHeard
        {
            get
            {
                return messagesHeard;
            }
        }

        public void Shout(string message)
        {
            broadcaster.Broadcast(message, GeoLocation);
        }

        public void Hear(string message)
        {
            messagesHeard.Add(message);
        }
    }

    public class Broadcaster
    {
        private readonly List<Person> subscribers = new List<Person>();

        public void Broadcast(string message, double[] shouterGeoLocation)
        {
            // Loop over all subscribers
            foreach (var subscriber in subscribers)
            {
                //   Deliver message if subscriber is in range
                if (IsInRange(subscriber.GeoLocation, shouterGeoLocation))
                {
                    subscriber.Hear(message);
                }
            }
        }

        private bool IsInRange(double[] loc1, double[] loc2)
        {
            var d = distance(loc1[0], loc1[1], loc2[0], loc2[1]) <= 1000;
            Console.WriteLine("Distance: %d", d);
            return d;
        }

        // Taken from geodatasource.com
        private double distance(double lat1, double lon1, double lat2, double lon2) {
          double theta = lon1 - lon2;
          double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
          dist = Math.Acos(dist);
          dist = rad2deg(dist);
          dist = dist * 60 * 1.1515;
          dist = dist * 1.609344;
          return (dist);
        }

        private double deg2rad(double deg) {
          return (deg * Math.PI / 180.0);
        }

        private double rad2deg(double rad) {
          return (rad / Math.PI * 180.0);
        }

        public void Subscribe(Person person)
        {
            subscribers.Add(person);
        }
    }
}