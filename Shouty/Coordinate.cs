using System;

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

        public int DistanceFrom(Coordinate other)
        {
            // TODO: actually calculate distance between the coordinates.
            //       e.g. return Math.Abs(xCoord - other.xCoord);

            return 0;
        }
    }
}
