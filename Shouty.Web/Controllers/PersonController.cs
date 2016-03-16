using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shouty.Web.Controllers
{
    public class PersonController : Controller
    {
        public static ShoutyApi ShoutyApi = new ShoutyApi();
        
        public ActionResult Index(string id)
        {
            var person = ShoutyApi.GetPerson(id);

            return View(person);
        }

        [HttpPost]
        public ActionResult SetLocation(string id, double lat, double lon)
        {
            var location = new Location(lat, lon);
            ShoutyApi.SetLocation(id, location);

            return RedirectToAction("Index", new { id });
        }

        [HttpPost]
        public ActionResult Shout(string id, string message)
        {
            ShoutyApi.Shout(id, message);

            return RedirectToAction("Index", new { id });
        }
    }
}