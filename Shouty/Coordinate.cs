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
            return (int)Math.Sqrt(
                Math.Pow(xCoord - other.xCoord, 2)
                + Math.Pow(yCoord - other.yCoord, 2)
            );
        }
    }
}
