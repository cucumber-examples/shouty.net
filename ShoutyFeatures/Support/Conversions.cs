using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouty;
using TechTalk.SpecFlow;

namespace ShoutyFeatures.Support
{
    [Binding]
    public class Conversions
    {
        [StepArgumentTransformation(@"\[(.*), (.*)]")]
        public Location ConvertLocation(double lat, double lon)
        {
            return new Location(lat, lon);
        }
    }
}
