using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ShoutyFeatures
{
    [Binding]
    public class HearShoutSteps
    {
        private Broadcaster broadcaster = new Broadcaster();
        private Person jeff;
        private Person phil;
        private Person sally;

        [Given(@"Jeff is in the Norwich Castle")]
        public void GivenJeffIsInTheNorwichCastle()
        {
            jeff = new Person(broadcaster)
            {
                GeoLocation = new[] { 52.682729, 1.296386}
            };
        }

        [Given(@"Phil is in Washington DC")]
        public void GivenPhilIsInWashingtonDC()
        {
            phil = new Person(broadcaster)
            {
                GeoLocation = new[] { 38.8951, -77.0367}
            };
        }

        [Given(@"Sally is in the Norwich Castle")]
        public void GivenSallyIsInTheNorwichCastle()
        {
            sally = new Person(broadcaster)
            {
                GeoLocation = new[] { 52.682729, 1.296386 }
            };
        }

        [Given(@"Phil is in the Bell Hotel Norwich")]
        public void GivenPhilIsInTheBellHotelNorwich()
        {
            phil = new Person(broadcaster)
            {
                GeoLocation = new[] { 52.6725, 1.29517 }
            };
        }

        [When(@"Jeff shouts")]
        public void WhenJeffShouts()
        {
            jeff.Shout("hello");
        }

        [When(@"Sally shouts")]
        public void WhenSallyShouts()
        {
            sally.Shout("sally's shout");
        }

        [Then(@"Phil should not hear Jeff's shout")]
        public void ThenPhilShouldNotHearJeffSShout()
        {
            Assert.AreEqual(new List<string>(), phil.MessagesHeard);
        }

        [Then(@"Phil should hear Sally's shout")]
        public void ThenPhilShouldHearSallySShout()
        {
            List<string> expected = new List<string>();
            expected.Add("sally's shout");
            Assert.AreEqual(expected, phil.MessagesHeard);
        }
    }

    public class Person
    {
        private readonly Broadcaster broadcaster;
        private readonly List<string> messagesHeard = new List<string>();

        public Person(Broadcaster broadcaster)
        {
            this.broadcaster = broadcaster;
            broadcaster.Subscribe(this);
        }

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
            return DistanceInMetres(loc1, loc2) <= 1000;
        }

        private int DistanceInMetres(double[] loc1, double[] loc2)
        {
            return 1000;
        }

        public void Subscribe(Person person)
        {
            subscribers.Add(person);
        }
    }
}