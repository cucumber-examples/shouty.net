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

    [Given(@"Lucy is (.*) metres from Sean")]
    public void GivenLucyIsMetresFromSean(int distance)
    {
      lucy = new Person();
      sean = new Person();

      lucy.MoveTo(distance);
    }

    [When(@"Sean shouts ""(.*)""")]
    public void WhenSeanShouts(string message)
    {
      lastMessage = message;
      sean.Shout(message);
    }

    [Then(@"Lucy hears Sean's message")]
    public void ThenLucyHearsSeanSMessage()
    {
      Assert.That(lucy.messagesHeard(), Contains.Item(lastMessage));
    }
  }
}
