using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Shouty.Specs
{
    public interface IAppDriver
    {
        void SetLocation(string name, Coordinate coordinate);

        void Shout(string name, string message);

        IDictionary<string, string> GetMessagesHeardBy(string name);

        void cleanup();
    }
}
