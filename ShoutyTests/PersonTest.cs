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
      Person sean = new Person(mock.Object, 0);
      mock.Verify(network => network.Subscribe(sean));
    }

    [Test]
    public void HasALocation()
    {
      Person lucy = new Person(mock.Object, 100);
      Assert.That(lucy.Location, Is.EqualTo(100));
    }

    [Test]
    public void BroadcastsShoutsToTheNetwork()
    {
      var message = "Free bagels!";
      var sean = new Person(mock.Object, 0);

      sean.Shout(message);
      mock.Verify(network => network.Broadcast(message, 0));
    }

    [Test]
    public void RemembersMessagesHeard()
    {
      var firstMessage = "Free bagels!";
      var secondMessage = "Free coffee!";

      var lucy = new Person(mock.Object, 100);

      lucy.Hear(firstMessage);
      lucy.Hear(secondMessage);

      Assert.That(lucy.MessagesHeard(), Contains.Item(firstMessage));
      Assert.That(lucy.MessagesHeard(), Contains.Item(secondMessage));
    }

  }
}
