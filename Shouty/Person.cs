using System.Collections.Generic;

namespace Shouty
{
    public class Person
    {
        private readonly List<string> messagesHeard = new List<string>();

        public string Name { get; private set; }
        public int Location { get; private set; }
        public IEnumerable<string> MessagesHeard => messagesHeard;

        public Person(string name)
        {
            Name = name;
        }

        public void SetLocation(int location)
        {
            Location = location;
        }

        public void Hear(string message)
        {
            messagesHeard.Add(message);
        }
    }
}