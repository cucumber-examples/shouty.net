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

        public Person(Broadcaster broadcaster)
        {
            this.broadcaster = broadcaster;
        }

        public double[] GeoLocation { get; set; }

        public List<string> MessagesHeard
        {
            get
            {
                return new List<string>();
            }
        }

        public void Shout(string message)
        {
            broadcaster.broadcast(message);
        }
    }

    public class Broadcaster
    {
        public void broadcast(string message)
        {
        }
    }
}