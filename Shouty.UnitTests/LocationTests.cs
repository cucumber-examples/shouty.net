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

            Assert.AreEqual(disctance, 10);
        }
    }
}
