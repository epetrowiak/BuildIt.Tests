using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UI.Weather.Tests.Harness.Driver;
using UI.Weather.Tests.Harness.Page;

namespace UI.Weather.Tests.Suites
{
    [TestClass]
    public class BaseTest
    {
        private static string DEFAULT_HOST { get; set; }
        private static string DEFAULT_PORT { get; set; }

        protected static IWebDriver Driver { get; set; }

        public WeatherPage WeatherPage { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Driver = DriverFactory.Instance;
            var reader = new System.Configuration.AppSettingsReader();
            DEFAULT_HOST = (string) reader.GetValue("host", typeof(string));
            DEFAULT_PORT = (string) reader.GetValue("port", typeof(string));
        }

        [TestInitialize]
        public void TestInit()
        {
            Driver.Url = $"http://{DEFAULT_HOST}:{DEFAULT_PORT}/";

            WeatherPage = new WeatherPage();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Driver?.Close();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Driver?.Quit();
            Driver?.Dispose();
            Driver = null;
        }
    }
}
