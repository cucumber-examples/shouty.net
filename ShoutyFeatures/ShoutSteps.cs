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

    [Given(@"Lucy is (\d+) metres from Sean")]
    public void GivenLucyIsMetresFromSean(int distance)
    {
      var network = new InMemoryNetwork();
      lucy = new Person(network);
      sean = new Person(network);

      lucy.MoveTo(distance);
    }

    [Given(@"a person named Lucy")]
    public void GivenAPersonNamedLucy()
    {
      ScenarioContext.Current.Pending();
    }

    [Given(@"a person named Sean")]
    public void GivenAPersonNamedSean()
    {
      ScenarioContext.Current.Pending();
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
