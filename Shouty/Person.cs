using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shouty
{
  public class Person : ISubscribe
  {
    private INetwork network;
    private List<String> messagesHeard = new List<string> { };
    private int location;

    public Person(INetwork network, int location)
    {
      this.network = network;
      this.location = location;
      network.Subscribe(this);
    }

    public void Shout(string message)
    {
      network.Broadcast(message, Location);
    }

    public List<String> MessagesHeard()
    {
      return messagesHeard;
    }

    public void Hear(string message)
    {
      messagesHeard.Add(message);
    }


    public int Location
    {
      get { return location; }
    }
  }
}
