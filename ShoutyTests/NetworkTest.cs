using System;
using NUnit.Framework;
using Moq;
using Shouty;

namespace ShoutyTests
{
  [TestFixture]
  public class NetworkTest
  {
    int range = 100;
    INetwork network;
    string message = "Free bagels";

    [SetUp]
    public void Init()
    {
      network = new InMemoryNetwork(range);
    }

    [Test]
    public void BroadcastMessageToListenersWithinRange()
    {    
      var mock = new Mock<ISubscribe>();
      var seanLocation = 0;

      mock.Setup(lucy => lucy.Location).Returns(100);
      
      network.Subscribe(mock.Object);
      network.Broadcast(message, seanLocation);

      mock.Verify(lucy => lucy.Hear(message));
    }

    [Test]
    public void DoesNotBroadcastMessageToListenerOutOfRange()
    {
      var mock = new Mock<ISubscribe>();
      var seanLocation = 0;

      mock.Setup(laura => laura.Location).Returns(101);

      network.Subscribe(mock.Object);
      network.Broadcast(message, seanLocation);

      mock.Verify(laura => laura.Hear(message), Times.Never());
    }

    [Test]
    public void DoesNotBroadcastMessageToListenerOutOfRangeWithNegativeDistance()
    {
      var mock = new Mock<ISubscribe>();
      var sallyLocation = 101;

      mock.Setup(lionel => lionel.Location).Returns(0);

      network.Subscribe(mock.Object);
      network.Broadcast(message, sallyLocation);

      mock.Verify(lionel => lionel.Hear(message), Times.Never());
    }
  }
}
