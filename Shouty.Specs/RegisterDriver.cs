using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Shouty.Specs
{
    [Binding]
    public class RegisterDriver
    {
        private readonly IObjectContainer objectContainer;

        public RegisterDriver(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("web"))
            {
                var uiDriver = new UiDriver();
                objectContainer.RegisterInstanceAs<IAppDriver>(uiDriver);
            }
            else
            {
                var domainDriver = new DomainDriver();
                objectContainer.RegisterInstanceAs<IAppDriver>(domainDriver);
            }

        }
    }

}
