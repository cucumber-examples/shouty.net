using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty
{
  public class Network
  {
    private List<ISubscribe> subscribers = new List<ISubscribe> {};

    public void Subscribe(ISubscribe subscriber)
    {
      subscribers.Add(subscriber);
    }

    public void Broadcast(string message)
    {
      subscribers.ForEach(subscriber => subscriber.Hear(message));
    }
  }
}
