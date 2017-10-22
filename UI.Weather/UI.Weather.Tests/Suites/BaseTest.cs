using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UI.Weather.Tests.Harness.Driver;
using UI.Weather.Tests.Harness.Page;

namespace UI.Weather.Tests.Suites
{
    [TestClass]
    public class BaseTest
    {
        protected static IWebDriver Driver { get; set; }

        public WeatherPage WeatherPage { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Driver = DriverFactory.Instance;
        }

        [TestInitialize]
        public void TestInit()
        {
            Driver.Url = "http://localhost:3000/";

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
