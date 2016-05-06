using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Shouty.Specs
{
    public interface IAppDriver
    {
        void SetLocation(string name, Coordinate coordinate);

        void Shout(string name, string message);

        IDictionary<string, string> GetMessagesHeardBy(string name);
    }

    [Binding]
    public class RegisterDomainDriver
    {
        private readonly IObjectContainer objectContainer;

        public RegisterDomainDriver(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var domainDriver = new DomainDriver();
            objectContainer.RegisterInstanceAs<IAppDriver>(domainDriver);
        }
    }

    public class DomainDriver : IAppDriver
    {
        private readonly ShoutyNetwork shouty = new ShoutyNetwork();

        public void SetLocation(string name, Coordinate coordinate)
        {
            shouty.SetLocation(name, coordinate);
        }


        public void Shout(string shouter, string message)
        {
            shouty.Shout(shouter, message);
        }


        public IDictionary<string, string> GetMessagesHeardBy(string name)
        {
            return shouty.GetMessagesHeardBy(name);
        }
    }
}
