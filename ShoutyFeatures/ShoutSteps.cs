using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Shouty;
using System.Collections.Generic;

namespace ShoutyFeatures
{
  [Binding]
  public class ShoutSteps
  {
    private Person lucy;
    private Person sean;
    private string lastMessage;
    private INetwork network;
    private Dictionary<string, Person> people;

    [Before]
    public void InitializeNetwork()
    {
      network = new InMemoryNetwork();
    }

    [Before]
    public void InitializePeople()
    {
      people = new Dictionary<string, Person> { };
    }

    [Given(@"a person named (\w+)")]
    public void GivenAPersonNamed(string name)
    {
      people.Add(name, new Person(network));
    }

    [When(@"Sean shouts ""([^""]*)""")]
    public void WhenSeanShouts(string message)
    {
      lastMessage = message;
      people["Sean"].Shout(message);
    }

    [Then(@"Lucy hears Sean's message")]
    public void ThenLucyHearsSeanSMessage()
    {
      Assert.That(people["Lucy"].MessagesHeard(), Contains.Item(lastMessage));
    }
  }
}
