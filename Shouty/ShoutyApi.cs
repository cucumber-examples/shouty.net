using System.Collections.Generic;

namespace Shouty
{
    // High level Facade for Shouty. Hexagonal style.
    public class ShoutyApi
    {
        private readonly Dictionary<string,Person> _people = new Dictionary<string, Person>();
        private readonly Broadcaster _broadcaster = new Broadcaster();

        public void PersonIsIn(string personName, double[] geoLocation)
        {
            var person = FindOrCreatePersonNamed(personName);
            person.GeoLocation = geoLocation;
        }

        public void PersonShouts(string personName, string message)
        {
            FindOrCreatePersonNamed(personName).Shout(message);
        }

        public IEnumerable<string> MessagesHeardBy(string personName)
        {
            return FindOrCreatePersonNamed(personName).MessagesHeard;
        }

        public Person FindOrCreatePersonNamed(string personName)
        {
            Person person;
            if (!_people.TryGetValue(personName, out person))
            {
                _people[personName] = person = new Person(_broadcaster);
            }
            return person;
        }

    }
}