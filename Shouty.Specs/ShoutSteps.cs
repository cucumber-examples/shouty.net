using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Shouty.Specs
{

    [Binding]
    public class ShoutSteps
    {
        private const string ARBITRARY_MESSAGE = "Hello, world";

        public IAppDriver Driver { get; set; }

        public ShoutSteps(IAppDriver driver)
        {
            this.Driver = driver;
        }

        [Given(@"Lucy is at \[(.*), (.*)]")]
        public void GivenLucyIsAt(int xCoord, int yCoord)
        {
            Driver.SetLocation("Lucy", new Coordinate(xCoord, yCoord));
        }

        [Given(@"Sean is at \[(.*), (.*)]")]
        public void GivenSeanIsAt(int xCoord, int yCoord)
        {
            Driver.SetLocation("Sean", new Coordinate(xCoord, yCoord));
        }

        [When(@"Sean shouts")]
        public void WhenSeanShouts()
        {
            Driver.Shout("Sean", ARBITRARY_MESSAGE);
        }

        [Then(@"Lucy should hear Sean")]
        public void ThenLucyShouldHearSean()
        {
            Assert.AreEqual(1, Driver.GetMessagesHeardBy("Lucy").Count);
        }

        [Then(@"Lucy should hear nothing")]
        public void ThenLucyShouldHearNothing()
        {
            Assert.AreEqual(0, Driver.GetMessagesHeardBy("Lucy").Count);
        }

    }
}
