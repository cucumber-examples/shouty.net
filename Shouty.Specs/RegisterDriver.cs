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
        private IAppDriver driver;

        public RegisterDriver(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("web"))
            {
                driver = new UiDriver();
                objectContainer.RegisterInstanceAs<IAppDriver>(driver);
            }
            else
            {
                driver = new DomainDriver();
                objectContainer.RegisterInstanceAs<IAppDriver>(driver);
            }

        }

        [AfterScenario]
        public void CleanupDriver()
        {
            driver.cleanup();
        }
    }

}
