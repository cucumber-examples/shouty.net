using System;
using TechTalk.SpecFlow;

namespace Shouty.Specs
{
    [Binding]
    public class ShoutyHooks
    {
        [BeforeScenario("@SpecialTest", Order = 0)]
        public void PrintSpecialMessage()
        {
            Console.WriteLine("this is special");
        }

        [BeforeScenario(Order = 1)]
        public void PrintBeforeMessage()
        {
            Console.WriteLine("this is before");
        }

        [AfterScenario(Order = 1)]
        public void PrintAfterMessage()
        {
            Console.WriteLine("this is after");
        }

        [BeforeScenario(Order = 2)]
        public void OtherPrintBeforeMessage()
        {
            Console.WriteLine("this is other before");
        }

        [AfterScenario(Order = 2)]
        public void OtherPrintAfterMessage()
        {
            Console.WriteLine("this is other after");
        }
    }
}
