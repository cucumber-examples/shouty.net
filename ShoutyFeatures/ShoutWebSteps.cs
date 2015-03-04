using System.Threading;
using TechTalk.SpecFlow;

namespace ShoutyFeatures
{
    [Binding, Scope(Tag = "web")]
    public class ShoutWebSteps
    {
        public ShoutWebSteps(BrowserContext browserContext)
        {
            var browser = browserContext.Browser;
            browser.Navigate().GoToUrl(WebHooks.Url + "/people/John");
            Thread.Sleep(5000);
        }

        [Given(@"the following locations:")]
        public void GivenTheFollowingLocations(Table table)
        {
            // Copy from other stepdef? Factor it out to other class?
        }
    }
}