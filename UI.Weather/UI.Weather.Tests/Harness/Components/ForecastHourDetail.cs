using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Weather.Tests.Harness.Driver;

namespace UI.Weather.Tests.Harness.Components
{
    public class ForecastHourDetail
    {
        private int row;
        private int hourRow;

        public IWebElement Hour => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=hour-{row}-{hourRow}]"));

        public IWebElement WeatherIcon => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=description-{row}-{hourRow}]"));
        public IWebElement MaxTemp => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=maximum-{row}-{hourRow}]"));
        public IWebElement MinTemp => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=minimum-{row}-{hourRow}]"));

        public IWebElement WindSpeed => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=speed-{row}-{hourRow}]"));
        public IWebElement DirectionIcon => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=direction-{row}-{hourRow}]"));
        public IWebElement RainFall => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=rainfall-{row}-{hourRow}]"));
        public IWebElement Pressure => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=pressure-{row}-{hourRow}]"));

        public ForecastHourDetail(int row, int hourRow)
        {
            this.row = row;
            this.hourRow = hourRow;
        }
    }
}
