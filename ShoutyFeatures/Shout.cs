using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoutyFeatures
{
    class Shout
    {
        private Person shouter;
        public string Message;

        public Shout(Person shouter, string message)
        {
            this.shouter = shouter;
            this.Message = message;
        }
    }
}
