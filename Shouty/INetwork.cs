using System;
namespace Shouty
{
  public interface INetwork
  {
    void Broadcast(string message, int location);
    void Subscribe(ISubscribe subscriber);
  }
}
