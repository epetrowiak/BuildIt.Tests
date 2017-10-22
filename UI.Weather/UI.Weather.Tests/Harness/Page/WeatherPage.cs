using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Weather.Tests.Harness.Components;
using UI.Weather.Tests.Harness.Driver;

namespace UI.Weather.Tests.Harness.Page
{
    public class WeatherPage
    {
        private WebDriverWait wait;

        public IWebElement TitleHeader => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h1")));
        public IWebElement CityTextfield => wait.Until(ExpectedConditions.ElementIsVisible(By.Id("city")));
        public IWebElement ErrorMessage => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"div[data-test=error]")));

        public WeatherPage()
        {
            wait = new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(10));
        }

        public ForecastRow ForecastDay(int row)
        {
            return new ForecastRow(row);
        }

        public ForecastHourDetail ForecastDetail(int row, int hourRow)
        {
            return new ForecastHourDetail(row, hourRow);
        }

        public void Navigate()
        {
            //do nothing
        }
        
        public void UpdateCity(string cityName)
        {
            CityTextfield.Clear();
            CityTextfield.SendKeys(cityName);
            CityTextfield.Submit();
        }

        public string GetCurrentCity()
        {
            return CityTextfield.GetAttribute("value");
        }

    }
}
