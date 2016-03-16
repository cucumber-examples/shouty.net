using System;
using NUnit.Framework;

namespace Shouty.UnitTests
{
    [TestFixture]
    public class LocationTests
    {
        [Test]
        public void DistanceShouldBeTheDifferenceOfLatIfLonIsTheSame()
        {
            var loc1 = new Location(0, 0);
            var loc2 = new Location(10, 0);

            var disctance = loc1.GetDistanceFrom(loc2);

            Assert.AreEqual(10, disctance);
        }

        [Test]
        public void DistanceShouldBeNonNegative()
        {
            var loc1 = new Location(0, 0);
            var loc2 = new Location(-10, 0);

            var disctance = loc1.GetDistanceFrom(loc2);

            Assert.AreEqual(10, disctance);
        }

        [Test]
        public void DistanceShouldBeTheDifferenceOfLonIfLatIsTheSame()
        {
            var loc1 = new Location(0, 0);
            var loc2 = new Location(0, 10);

            var disctance = loc1.GetDistanceFrom(loc2);

            Assert.AreEqual(10, disctance);
        }

        [Test]
        public void DistanceShouldBeCalculatedWithPythagorasIfBothCoordinatesVary()
        {
            var loc1 = new Location(0, 0);
            var loc2 = new Location(3, 4);

            var disctance = loc1.GetDistanceFrom(loc2);

            Assert.AreEqual(5, disctance);
        }
    }
}
