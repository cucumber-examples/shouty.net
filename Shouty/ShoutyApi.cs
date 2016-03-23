using System.Collections.Generic;

namespace Shouty
{
    public class ShoutyApi
    {
        private readonly List<string> shouts = new List<string>(); 

        public void Shout(string shout)
        {
            shouts.Add(shout);
        }

        public List<string> GetReceivedShouts()
        {
            return shouts;
        }
    }
}
