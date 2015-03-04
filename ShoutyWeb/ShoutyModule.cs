using System;
using System.Collections.Generic;
using Nancy;
using Shouty;

namespace ShoutyWeb
{
    public class ShoutyModule : NancyModule
    {
        private static ShoutyApi _shoutyApi = new ShoutyApi();

        public ShoutyModule()
        {
            Get["/"] = _ => View["index.html"];

            Get["/people/{personName}"] = _ =>
            {
                try
                {
                    double lat = Request.Query["lat"];
                    double lon = Request.Query["lon"];
                    _shoutyApi.PersonIsIn(_.personName, new[] {lat, lon});
                }
                catch (Exception ignore)
                {
                    // Happens when lat/lon is not on query
                }

                Dictionary<string, object> model = new Dictionary<string, object>()
                {
                    {"personName", _.personName},
                    {"messages", _shoutyApi.MessagesHeardBy(_.personName)}
                };
                return View["person.html", model];
            };

            Post["/messages"] = _ =>
            {
                string personName = Request.Form["personName"];
                string message = Request.Form["message"];
                _shoutyApi.PersonShouts(personName, message);
                return Response.AsRedirect(Request.Headers.Referrer);
            };
        }

        public static void Reset()
        {
            _shoutyApi = new ShoutyApi();
        }
    }
}