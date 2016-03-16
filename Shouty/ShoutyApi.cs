using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty
{
    public class ShoutyApi
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

        public void SetLocation(string name, int position)
        {
            GetOrCreatePerson(name).SetLocation(position);
        }

        public void Shout(string name, string message)
        {
            foreach (var person in personsByName.Values)
            {
                person.Hear(message);
            }
        }

        public List<string> GetMessages(string name)
        {
            return GetOrCreatePerson(name).MessagesHeard.ToList();
        }
    }
}
