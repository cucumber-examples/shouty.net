using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty
{
    public class Person
    {
        public int location = 0;
        public List<string> messagesHeard = new List<string>();

        public void Hear(string message)
        {
            messagesHeard.Add(message);
        }

        public bool withinRangeOf(Person other)
        {
            return Math.Abs(other.location - this.location) <= 1000;
        }
    };

    public class ShoutyMainApi
    {
        private Person findOrCreatePerson(string name)
        {
            Person value = new Person();
            if (!people.TryGetValue(name, out value))
            {
                people.Add(name, new Person());
            }
            return people[name];
        }

        private Dictionary<String, Person> people = new Dictionary<string, Person>();
        public void SetLocation(string name, int location)
        {
            findOrCreatePerson(name).location = location;
        }

        public void Shout(string name, string message)
        {
            Person shouter = findOrCreatePerson(name);
            foreach (Person potentialHearer in people.Values)
            {
                if (potentialHearer.withinRangeOf(shouter))
                {
                    potentialHearer.Hear(message);
                }
            }
        }

        public List<string> messagesHeard(string name)
        {
            return findOrCreatePerson(name).messagesHeard;
        }
    };
}
