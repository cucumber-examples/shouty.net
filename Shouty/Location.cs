using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty
{
    public class Location
    {
        public double Lat { get; private set; }
        public double Lon { get; private set; }

        public Location(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }

        public double GetDistanceFrom(Location other)
        {
            return Math.Abs(other.Lat - this.Lat);
        }
    }
}
