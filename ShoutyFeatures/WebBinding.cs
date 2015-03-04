using System;
using System.Collections.Generic;
using System.Threading;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Hosting.Self;
using Nancy.TinyIoc;
using Nancy.ViewEngines;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace ShoutyFeatures
{
    [Binding]
    public class WebBinding
    {
        private const string Url = "http://localhost:1234";
        private static readonly HostConfiguration HostConfiguration = new HostConfiguration()
        {
            UrlReservations = new UrlReservations()
            {
                CreateAutomatically = true
            }
        };

        private IWebDriver _browser;
        private NancyHost _server;

        [BeforeScenario()]
        public void StartServer()
        {
            _server = new NancyHost(HostConfiguration, new Uri(Url));
            _server.Start();
        }

        [BeforeScenario()]
        public void OpenBrowser()
        {
            _browser = new InternetExplorerDriver();
            _browser.Navigate().GoToUrl(Url + "/people/John");
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

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer c, IPipelines p)
        {
            this.Conventions.ViewLocationConventions.Add((viewName, model, context) =>
            {
                // This doesn't seem to work :-(
                // So we copy the views for now...
                return string.Concat("../../../ShoutyWeb/views/", viewName);
            });   
        }
    }
}