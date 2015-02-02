using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shouty
{
  public class InMemoryNetwork : INetwork
  {
    private List<ISubscribe> subscribers = new List<ISubscribe> {};
    private int range;

    public InMemoryNetwork(int range)
    {
      this.range = range;
    }

    public void Subscribe(ISubscribe subscriber)
    {
      subscribers.Add(subscriber);
    }

    public void Broadcast(string message, int location)
    {
      subscribers.FindAll(subscriber => IsInRange(location, subscriber.Location)).
        ForEach(subscriber => subscriber.Hear(message));
    }

    private bool IsInRange(int broadcastLocation, int listenerLocation)
    {
      return Math.Abs(listenerLocation - broadcastLocation) <= range;
    }
  }
}
