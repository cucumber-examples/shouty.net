using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shouty.Tests
{
    public class LocationTests
    {
        [Fact]
        public void SameLocationHasZeroDistance()
        {
            //arrange
            var location = new Location(42);

            //act
            var distance = location.DistanceTo(location);

            //assert
            Assert.Equal(0, distance);
        }
    }
}
