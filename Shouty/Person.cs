using System.Collections.Generic;

namespace Shouty
{
    public class Person
    {
        public string Name { get; set; }
        public Location2D Location { get; set; }
        public List<string> ReceivedSouts { get; private set; } 

        public Person(string name)
        {
            Name = name;
            ReceivedSouts = new List<string>();
        }

        public void Receive(string shout)
        {
            ReceivedSouts.Add(shout);
        }
    }
}