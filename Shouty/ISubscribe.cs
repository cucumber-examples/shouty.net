using System;
namespace Shouty
{
  public interface ISubscribe
  {
    void Hear(string message);

    int Location { get; }
  }
}
