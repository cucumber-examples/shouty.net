using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Shouty;

namespace ShoutyFeatures
{
  [Binding]
  public class ShoutSteps
  {
    [Given(@"Lucy is (.*) metres from Sean")]
    public void GivenLucyIsMetresFromSean(int p0)
    {
      ScenarioContext.Current.Pending();
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
