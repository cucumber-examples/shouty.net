using NUnit.Framework;

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
