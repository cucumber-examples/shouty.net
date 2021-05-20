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

        [Test]
        public void ItCalculatesTheDistanceFromAnotherCoordinate()
        {
            Coordinate a = new Coordinate(0, 0);
            Coordinate b = new Coordinate(300, 400);
            Assert.AreEqual(500, a.DistanceFrom(b));
        }

        // Use this code to implement Pythagoras' theorem in Coordinate.cs:
        //
        // return (int)Math.Sqrt(
        //     Math.Pow(xCoord - other.xCoord, 2)
        //     + Math.Pow(yCoord - other.yCoord, 2)
        // );
    }
}
