using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shouty
{
  public class Person : ISubscribe
  {
    public void MoveTo(int distance)
    {
    }

    public void Shout(string message)
    {
    }

    public List<String> MessagesHeard()
    {
      return new List<string> {
        "Free bagels!"
      };
    }

    public void Hear(string message)
    {
      throw new NotImplementedException();
    }
  }
}
