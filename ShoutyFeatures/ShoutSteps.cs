using System;
using TechTalk.SpecFlow;

namespace ShoutyFeatures
{
    [Binding]
    public class ShoutSteps
    {
        private Network network;

        [Before]
        public void createNetwork()
        {
            this.network = new Network();
        }

        [Given(@"a person named Sean")]
        public void GivenAPersonNamedSean()
        {
            network.AddPerson(new Person("Sean"));
        }
        
        [Given(@"a person named Lucy")]
        public void GivenAPersonNamedLucy()
        {
            network.AddPerson(new Person("Lucy"));
        }
        
        [When(@"Sean shouts ""(.*)""")]
        public void WhenSeanShouts(string message)
        {
            Shout shout = new Shout(network.GetPersonNamed("Sean"), message);
            network.Broadcast(shout);
        }
        
        [Then(@"Lucy hears ""(.*)""")]
        public void ThenLucyHears(string expectedMessage)
        {
            NUnit.Framework.Assert.Contains(expectedMessage, network.GetPersonNamed("Lucy").MessagesHeard);
        }
    }
}
