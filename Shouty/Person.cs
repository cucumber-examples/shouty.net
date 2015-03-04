using System.Collections.Generic;

namespace Shouty
{
    public class Person
    {
        private readonly Broadcaster _broadcaster;
        private readonly List<string> _messagesHeard = new List<string>();

        public Person(Broadcaster broadcaster)
        {
            this._broadcaster = broadcaster;
            this.GeoLocation = new[] {0.0, 0.0};
            broadcaster.Subscribe(this);
        }

        // TODO: Extract to GeoLocation class
        public double[] GeoLocation { get; set; }

        public List<string> MessagesHeard
        {
            get
            {
                return _messagesHeard;
            }
        }

        public void Shout(string message)
        {
            _broadcaster.Broadcast(message, GeoLocation);
        }

        public void Hear(string message)
        {
            _messagesHeard.Add(message);
        }
    }
}