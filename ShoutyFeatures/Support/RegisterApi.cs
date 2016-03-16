using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Shouty;
using ShoutyFeatures.StepDefinitions;
using TechTalk.SpecFlow;

namespace ShoutyFeatures.Support
{
    [Binding]
    public class RegisterApi
    {
        private readonly IObjectContainer container;

        public RegisterApi(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void Register()
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("web") ||
                FeatureContext.Current.FeatureInfo.Tags.Contains("web"))
            {
                container.RegisterTypeAs<ShoutyWebDriver, IShoutyApi>();
            }
            else
            {
                container.RegisterTypeAs<ShoutyApi, IShoutyApi>();
            }
        }
    }
}
