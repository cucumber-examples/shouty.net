using System.Collections.Generic;

namespace Shouty
{
    public class ShoutyNetwork
    {
        private readonly Dictionary<string, Coordinate> locationsByPerson = new Dictionary<string, Coordinate>();
        private readonly Dictionary<string, List<string> > shoutsByPerson = new Dictionary<string, List<string> >();
        private const int MESSAGE_RANGE = 1000;

        public void SetLocation(string personName, Coordinate coordinate)
        {
            locationsByPerson[personName] = coordinate;
        }

        public void Shout(string shouterName, string message)
        {
            if (!shoutsByPerson.ContainsKey(shouterName))
            {
                List<string> personsShouts = new List<string>();
                shoutsByPerson[shouterName] = personsShouts;
            }

            shoutsByPerson[shouterName].Add(message);
        }

        public IDictionary<string, List<string> > GetShoutsHeardBy(string listenerName)
        {
            var shoutsHeard = new Dictionary<string, List<string> >();

            foreach (var shout in shoutsByPerson)
            {
                var shouter = shout.Key;
                if (shouter.Equals(listenerName)) 
                    continue;
                var personsShouts = shout.Value;

                int distance = locationsByPerson[shouter]
                    .DistanceFrom(locationsByPerson[listenerName]);

                if (distance < MESSAGE_RANGE)
                    shoutsHeard.Add(shouter, personsShouts);
            }

            return shoutsHeard;
        }
    }
}
