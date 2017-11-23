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
            // TODO: actually calculate distance beteen the coordinates.
            //       e.g. return Math.Abs(xCoord - other.xCoord);

            return 0;
        }
    }
}
