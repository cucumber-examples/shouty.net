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

    [Given(@"Lucy is (.*) metres from Sean")]
    public void GivenLucyIsMetresFromSean(int distance)
    {
      lucy = new Person();
      sean = new Person();

      lucy.MoveTo(distance);
    }

    [When(@"Sean shouts ""(.*)""")]
    public void WhenSeanShouts(string p0)
    {
      ScenarioContext.Current.Pending();
    }

    [Then(@"Lucy hears Sean's message")]
    public void ThenLucyHearsSeanSMessage()
    {
      ScenarioContext.Current.Pending();
    }
  }
}
