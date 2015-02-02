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

    public Person(INetwork network)
    {
      this.network = network;
      network.Subscribe(this);
    }

    public void Shout(string message)
    {
      network.Broadcast(message);
    }

    public List<String> MessagesHeard()
    {
      return messagesHeard;
    }

    public void Hear(string message)
    {
      messagesHeard.Add(message);
    }
  }
}
