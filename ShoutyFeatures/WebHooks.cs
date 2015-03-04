using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;
using OpenQA.Selenium;
using ShoutyWeb;
using TechTalk.SpecFlow;

namespace ShoutyFeatures
{
    [Binding, Scope(Tag = "web")]
    public class WebHooks
    {
        private readonly IWebDriver _browser;
        public const string Url = "http://localhost:1234";
        private static readonly HostConfiguration HostConfiguration = new HostConfiguration()
        {
            UrlReservations = new UrlReservations()
            {
                CreateAutomatically = true
            }
        };

        private NancyHost _server;

        public WebHooks(BrowserContext browserContext)
        {
            _browser = browserContext.Browser;
        }

        [BeforeScenario()]
        public void StartServer()
        {
            ShoutyModule.Reset();
            _server = new NancyHost(HostConfiguration, new Uri(Url));
            _server.Start();
        }

        [AfterScenario()]
        public void CloseBrowser()
        {
            _browser.Close();
        }

        [AfterScenario()]
        public void StopServer()
        {
            _server.Stop();
            _server.Dispose();
        }
    }

    // Tell Nancy to load views from the ShoutyWeb project
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer c, IPipelines p)
        {
            Conventions.ViewLocationConventions.Add((viewName, model, context) =>
                string.Concat("../../../ShoutyWeb/views/", viewName));
        }

        protected override IRootPathProvider RootPathProvider
        {
            get { return new CustomRootPathProvider(); }
        }
    }

    public class CustomRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}