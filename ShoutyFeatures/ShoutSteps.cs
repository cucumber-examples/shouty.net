using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using Shouty;
using System.Collections.Generic;

namespace ShoutyFeatures
{
  [Binding]
  public class ShoutSteps
  {
    private string lastMessage;
    private INetwork network;
    private Dictionary<string, Person> people;

    [Before]
    public void InitializePeople()
    {
      people = new Dictionary<string, Person> { };
    }

    [Given(@"the range is (\d+)")]
    public void GivenTheRangeIs(int range)
    {
      network = new InMemoryNetwork(range);
    }

    [Given(@"the following people:")]
    public void GivenTheFollowingPeople(Table table)
    {
      IEnumerable<PersonRow> rows = table.CreateSet<PersonRow>();

      foreach (PersonRow row in rows)
      {
        people[row.name] = new Person(network, row.location);
      }
    }

    [Given(@"a person named (\w+) at location (\d+)")]
    public void GivenAPersonNamedAtLocation(string name, int location)
    {
      people.Add(name, new Person(network, location));
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

    [Then(@"Larry does not hear Sean's message")]
    public void ThenLarryDoesNotHearSeanSMessage()
    {
      Assert.That(people["Larry"].MessagesHeard(), Has.No.Member(lastMessage));
    }
  }
}
