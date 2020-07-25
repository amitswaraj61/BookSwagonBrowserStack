

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using OpenQA.Selenium.Remote;

namespace BookSwagon
{
    public class Base
    {

        protected IWebDriver driver;
        protected string profile;
        protected string environment;

        public Base(string profile, string environment)
        {
            this.profile = profile;
            this.environment = environment;
        }

        [OneTimeSetUp]
        [Obsolete]
        public void Init()
        {

            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + profile) as NameValueCollection;
            NameValueCollection settings = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;


            DesiredCapabilities capability = new DesiredCapabilities();

            foreach (string key in caps.AllKeys)
            {
                capability.SetCapability(key, caps[key]);
            }

            foreach (string key in settings.AllKeys)
            {
                capability.SetCapability(key, settings[key]);
            }

            String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            if (username == null)
            {
                username = ConfigurationManager.AppSettings.Get("user");
            }

            String accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
            if (accesskey == null)
            {
                accesskey = ConfigurationManager.AppSettings.Get("key");
            }

            capability.SetCapability("browserstack.user", username);
            capability.SetCapability("browserstack.key", accesskey);

            String appId = Environment.GetEnvironmentVariable("BROWSERSTACK_APP_ID");
            if (appId != null)
            {
                capability.SetCapability("app", appId);
            }

 driver = new RemoteWebDriver(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
        }

        [OneTimeTearDown]
        public void Close()
        {
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
 
