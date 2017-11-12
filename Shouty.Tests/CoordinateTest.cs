using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouty;

namespace Shouty.Tests
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void ItCalculatesTheDistanceFromItself()
        {
            Coordinate a = new Coordinate(0, 0);
            Assert.AreEqual(0, a.DistanceFrom(a));
        }

        [TestMethod]
        public void ItCalculatesTheDistanceFromAnotherCoordinateAlongXAxis()
        {
            Coordinate a = new Coordinate(0, 0);
            Coordinate b = new Coordinate(600, 0);
            Assert.AreEqual(600, a.DistanceFrom(b));
        }

        // [TestMethod]
        // public void ItCalculatesTheDistanceFromAnotherCoordinate()
        // {
        //     Coordinate a = new Coordinate(0, 0);
        //     Coordinate b = new Coordinate(300, 400);
        //     Assert.AreEqual(500, a.DistanceFrom(b));
        // }
    }
}
