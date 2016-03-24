using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shouty.Tests
{
    public class Location2DTests
    {
        [Fact]
        public void SameLocationHasZeroDistance()
        {
            //arrange
            var location = new Location2D(42, 23);

            //act
            var distance = location.DistanceTo(location);

            //assert
            Assert.Equal(0, distance);
        }

        [Fact]
        public void SameXDifferentYHasNonZeroDistance()
        {
            var location1 = new Location2D(42, 23);
            var location2 = new Location2D(42, 0);

            var distance = location1.DistanceTo(location2);

            Assert.NotEqual(0, distance);
        }

        [Fact]
        public void CheckSomeExactDistanceForY()
        {
            var location1 = new Location2D(42, 23);
            var location2 = new Location2D(42, 0);

            var distance = location1.DistanceTo(location2);

            Assert.Equal(23, distance);
        }

        [Fact]
        public void SameYDistanceIsXDifference()
        {
            var location1 = new Location2D(0, 23);
            var location2 = new Location2D(42, 23);

            var distance = location1.DistanceTo(location2);

            Assert.Equal(42, distance);
        }

        [Fact]
        public void SameYDistanceIsXDifferenceReverse()
        {
            var location1 = new Location2D(42, 23);
            var location2 = new Location2D(0, 23);

            var distance = location1.DistanceTo(location2);

            Assert.Equal(42, distance);
        }

        [Fact]
        public void DifferentXDifferentY()
        {
            var location1 = new Location2D(30, 0);
            var location2 = new Location2D(0, 40);

            var distance = location1.DistanceTo(location2);

            Assert.Equal(50, distance);
        }


        
    }
}
