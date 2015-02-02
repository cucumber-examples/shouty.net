using System;
namespace Shouty
{
  public interface INetwork
  {
    void Broadcast(string message);
    void Subscribe(ISubscribe subscriber);
  }
}
