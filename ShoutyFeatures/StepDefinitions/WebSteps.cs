using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouty;
using TechTalk.SpecFlow;

namespace ShoutyFeatures.StepDefinitions
{
    [Binding, Scope(Tag = "web")]
    public class WebSteps
    {
        [Given(@"(.*) is at (.*)")]
        public void GivenPersonIsAt(string name, Location location)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Fred shouts")]
        public void WhenFredShouts()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Linda should hear nothing")]
        public void ThenLindaShouldHearNothing()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Linda should hear Fred’s shout")]
        public void ThenLindaShouldHearFredSShout()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
