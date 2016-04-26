using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouty;

namespace Shouty.Tests
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void ItCalculatesTheDistanceFromAnotherCoordinateAlongXAxis()
        {
            Coordinate a = new Coordinate(0, 0);
            Coordinate b = new Coordinate(1000, 0);
            Assert.AreEqual(1000, a.DistanceFrom(b));
        }
    }
}
