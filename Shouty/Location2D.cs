using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty
{
    public class Location2D
    {
        private int _x;
        private int _y;

        public Location2D(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public double DistanceTo(Location2D location)
        {
            return Math.Sqrt(
                Math.Pow(_x - location._x, 2) + 
                Math.Pow(_y - location._y, 2));
        }
    }
}
