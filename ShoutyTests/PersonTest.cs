using System;
using NUnit.Framework;
using Moq;
using Shouty;

namespace ShoutyTests
{
  [TestFixture]
  class PersonTest
  {
    [Test]
    public void SubscribesToTheNetwork()
    {
      var mock = new Mock<INetwork>();

      var sean = new Person(mock.Object);

      mock.Verify(network => network.Subscribe(sean));
    }
  }
}
