using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty.Specs
{
    public class DomainDriver : IAppDriver
    {
        private readonly ShoutyNetwork shouty = new ShoutyNetwork();

        public void SetLocation(string name, Coordinate coordinate)
        {
            shouty.SetLocation(name, coordinate);
        }

        public void Shout(string shouter, string message)
        {
            shouty.Shout(shouter, message);
        }


        public IDictionary<string, string> GetMessagesHeardBy(string name)
        {
            return shouty.GetMessagesHeardBy(name);
        }


        public void cleanup()
        {
            //no-op
        }
    }
}
