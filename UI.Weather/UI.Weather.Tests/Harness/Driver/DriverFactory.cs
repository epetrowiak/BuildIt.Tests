using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Weather.Tests.Harness.Driver
{
    public class DriverFactory
    {
        private static IWebDriver _driver;
        public static IWebDriver Instance {
            get
            {
                if(_driver == null)
                {
                    _driver = Init();
                }

                return _driver;
            }
        }

        private static IWebDriver Init()
        {
            var chromeExeFilePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Resources");
            var driver = new ChromeDriver(chromeExeFilePath);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }
    }
}
