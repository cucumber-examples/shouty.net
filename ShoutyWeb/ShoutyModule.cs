using System;
using System.Collections.Generic;
using Nancy;
using Shouty;

namespace ShoutyWeb
{
    public class ShoutyModule : NancyModule
    {
        private static readonly ShoutyApi _shoutyApi = new ShoutyApi();

        public ShoutyModule()
        {
            Console.WriteLine("ShoutyModule created");

            Get["/"] = _ => View["index.html"];

            Get["/people/{personName}"] = _ =>
            {
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
                Console.WriteLine(personName + ":" + message);
                _shoutyApi.PersonShouts(personName, message);
                var heard = _shoutyApi.MessagesHeardBy(personName);
                Console.WriteLine(heard);
                return Response.AsRedirect(Request.Headers.Referrer);
            };
        }
    }
}