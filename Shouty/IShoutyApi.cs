using System;
using System.Collections.Generic;

namespace Shouty
{
    public interface IShoutyApi : IDisposable
    {
        void SetLocation(string name, Location position);
        void Shout(string name, string message);
        List<string> GetMessages(string name);
    }
}