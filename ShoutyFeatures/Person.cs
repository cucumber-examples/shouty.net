using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoutyFeatures
{
    class Person
    {
        public string name;
        public List<string> MessagesHeard = new List<string>();

        public Person(string name)
        {
            this.name = name;
        }

        internal void Hear(Shout shout)
        {
            this.MessagesHeard.Add(shout.Message);
        }
    }
}
