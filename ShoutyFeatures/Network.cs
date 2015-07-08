using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoutyFeatures
{
    class Network
    {
        private Dictionary<string, Person> people = new Dictionary<string, Person>();

        internal void AddPerson(Person person)
        {
            people.Add(person.name, person);
        }

        internal Person GetPersonNamed(string name)
        {
            return people[name];
        }

        internal void Broadcast(Shout shout)
        {
            foreach (Person person in people.Values)
            {
                person.Hear(shout);
            }
        }
    }
}
