using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty.Specs
{
    class UiDriver : IAppDriver
    {
        public void SetLocation(string name, Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public void Shout(string name, string message)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, string> GetMessagesHeardBy(string name)
        {
            throw new NotImplementedException();
        }
    }
}
