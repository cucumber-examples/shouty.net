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
    public void BroadcastMessageToListenersWithinRange()
    {
      var range = 100;
      var network = new InMemoryNetwork(range);
      var message = "Free bagels";
      var mock = new Mock<ISubscribe>();
      var seanLocation = 0;

      mock.Setup(person => person.Location).Returns(100);
      
      network.Subscribe(mock.Object);
      network.Broadcast(message, seanLocation);

      mock.Verify(person => person.Hear(message));
    }
  }
}
