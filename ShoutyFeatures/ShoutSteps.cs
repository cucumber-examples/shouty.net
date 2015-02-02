using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Shouty;

namespace ShoutyFeatures
{
  [Binding]
  public class ShoutSteps
  {
    private Person lucy;
    private Person sean;
    private string lastMessage;
    private INetwork network;

    [Before]
    public void InitializeNetwork()
    {
      network = new InMemoryNetwork();
    }

    [Given(@"Lucy is (\d+) metres from Sean")]
    public void GivenLucyIsMetresFromSean(int distance)
    {
      lucy = new Person(network);
      sean = new Person(network);

      lucy.MoveTo(distance);
    }

    [Given(@"a person named (Lucy)")]
    public void GivenAPersonNamed(string name)
    {
      lucy = new Person(network);
    }

    [Given(@"a person named Sean")]
    public void GivenAPersonNamedSean()
    {
      sean = new Person(network);
    }

    [When(@"Sean shouts ""([^""]*)""")]
    public void WhenSeanShouts(string message)
    {
      lastMessage = message;
      sean.Shout(message);
    }

    [Then(@"Lucy hears Sean's message")]
    public void ThenLucyHearsSeanSMessage()
    {
      Assert.That(lucy.MessagesHeard(), Contains.Item(lastMessage));
    }
  }
}
