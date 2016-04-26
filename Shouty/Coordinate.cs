using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shouty
{
    public class Coordinate
    {
        private readonly int xCoord;
        private readonly int yCoord;

        public Coordinate(int xCoord, int yCoord)
        {
            this.xCoord = xCoord;
            this.yCoord = yCoord;
        }

        public int DistanceFrom(Coordinate coordinate)
        {
            // TODO: actually caluculate distance. I think we need to use pythagoras' theorem?
            return 0;
        }
    }
}
