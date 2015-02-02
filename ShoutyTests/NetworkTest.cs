using System;
using NUnit.Framework;
using Moq;
using Shouty;

namespace ShoutyTests
{
  [TestFixture]
  public class NetworkTest
  {
    [Test]
    public void BroadcastMessageToListeners()
    {
      InMemoryNetwork network = new InMemoryNetwork();
      var message = "Free bagels";
      var mock = new Mock<ISubscribe>();
      
      network.Subscribe(mock.Object);
      network.Broadcast(message);

      mock.Verify(person => person.Hear(message));
    }
  }
}
