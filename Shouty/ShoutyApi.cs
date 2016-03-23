using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Shouty
{
    public class ShoutyApi
    {
        private readonly Dictionary<string, Person> persons = new Dictionary<string, Person>();

        public void SetLocation(string name, int location)
        {
            var person = GetOrCreate(name);
            person.Location = location;
        }

        private Person GetOrCreate(string name)
        {
            Person result;
            if (!persons.TryGetValue(name, out result))
            {
                result = new Person(name);
                persons.Add(name, result);
            }
            return result;
        }

        public void Shout(string name, string shout)
        {
            var shoutee = GetOrCreate(name);
            foreach (var person in persons.Values)
            {
                if (Math.Abs(shoutee.Location - person.Location) < 1000)
                    person.Receive(shout);
            }
        }

        public List<string> GetReceivedShouts(string name)
        {
            var person = GetOrCreate(name);
            return person.ReceivedSouts;
        }
    }
}
