using Nancy;

namespace ShoutyWeb
{
    public class ShoutyModule : NancyModule
    {
        public ShoutyModule()
        {
            Get["/"] = parameters => "Hello World!!!";
        }
    }
}