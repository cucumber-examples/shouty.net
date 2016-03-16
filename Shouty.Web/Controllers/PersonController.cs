using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shouty.Web.Controllers
{
    public class PersonController : Controller
    {
        public static ShoutyApi shoutyApi = new ShoutyApi();
        
        public ActionResult Index(string id)
        {
            var person = shoutyApi.GetPerson(id);

            return View(person);
        }

        [HttpPost]
        public ActionResult SetLocation(string id, double lat, double lon)
        {
            var location = new Location(lat, lon);
            shoutyApi.SetLocation(id, location);

            return RedirectToAction("Index", new { id });
        }
    }
}