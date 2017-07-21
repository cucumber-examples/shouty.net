using System;
using NUnit.Framework;
using Shouty;

namespace Shouty.Tests
{
    [TestFixture]
    public class CoordinateTest
    {
        [Test]
        public void ItCalculatesTheDistanceFromItself()
        {
            Coordinate a = new Coordinate(0, 0);
            Assert.AreEqual(0, a.DistanceFrom(a));
        }

        [Test]
        public void ItCalculatesTheDistanceFromAnotherCoordinateAlongXAxis()
        {
            Coordinate a = new Coordinate(0, 0);
            Coordinate b = new Coordinate(1000, 0);
            Assert.AreEqual(1000, a.DistanceFrom(b));
        }
    }
}
