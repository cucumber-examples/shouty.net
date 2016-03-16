#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shouty.Web.Controllers
{
    public class TestResetController : ApiController
    {
        public string Get()
        {
            PersonController.ShoutyApi = new ShoutyApi();
            return "success!";
        }
    }
}
#endif