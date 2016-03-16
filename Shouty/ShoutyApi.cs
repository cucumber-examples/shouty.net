using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty
{
    public class ShoutyApi : IShoutyApi
    {
        private readonly Dictionary<string, Person> personsByName = new Dictionary<string, Person>();

        private Person GetOrCreatePerson(string name)
        {
            Person person;
            if (!personsByName.TryGetValue(name, out person))
            {
                person = new Person(name);
                personsByName.Add(name, person);
            }
            return person;
        }

        public Person GetPerson(string name)
        {
            return GetOrCreatePerson(name);
        }

        public void SetLocation(string name, Location position)
        {
            GetOrCreatePerson(name).SetLocation(position);
        }

        public void Shout(string name, string message)
        {
            var shouter = GetOrCreatePerson(name);

            foreach (var person in personsByName.Values)
            {
                if (person.Location.GetDistanceFrom(shouter.Location) <= 1000)
                    person.Hear(message);
            }
        }

        public List<string> GetMessages(string name)
        {
            return GetOrCreatePerson(name).MessagesHeard.ToList();
        }

        public void Dispose()
        {
            //nop
        }
    }
}
