using System;
using TechTalk.SpecFlow;

namespace Shouty.Specs
{
    [Binding]
    public class ShoutyHooks
    {
        [BeforeScenario]
        public void PrintBeforeMessage()
        {
            Console.WriteLine("this is before");
        }

        [AfterScenario]
        public void PrintAfterMessage()
        {
            Console.WriteLine("this is after");
        }
    }
}
