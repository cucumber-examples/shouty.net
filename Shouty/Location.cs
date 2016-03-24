using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty
{
    public class Location
    {
        public int Coordinate { get; private set; }

        public Location(int coordinate)
        {
            Coordinate = coordinate;
        }

        public int DistanceTo(Location other)
        {
            return 0;
        }
    }
}
