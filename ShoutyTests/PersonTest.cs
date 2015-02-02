using System;
using NUnit.Framework;
using Moq;
using Shouty;

namespace ShoutyTests
{
  [TestFixture]
  class PersonTest
  {
    Mock<INetwork> mock = new Mock<INetwork>();

    [Test]
    public void SubscribesToTheNetwork()
    {
      var sean = new Person(mock.Object);

      mock.Verify(network => network.Subscribe(sean));
    }

    [Test]
    public void BroadcastsShoutsToTheNetwork()
    {
      var message = "Free bagels!";
      var sean = new Person(mock.Object);

      sean.Shout(message);
      mock.Verify(network => network.Broadcast(message, 0));
    }

    [Test]
    public void RemembersMessagesHeard()
    {
      var firstMessage = "Free bagels!";
      var secondMessage = "Free coffee!";

      var lucy = new Person(mock.Object);

      lucy.Hear(firstMessage);
      lucy.Hear(secondMessage);

      Assert.That(lucy.MessagesHeard(), Contains.Item(firstMessage));
      Assert.That(lucy.MessagesHeard(), Contains.Item(secondMessage));
    }

  }
}
