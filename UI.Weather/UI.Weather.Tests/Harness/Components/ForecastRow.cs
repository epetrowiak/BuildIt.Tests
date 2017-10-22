using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Weather.Tests.Harness.Driver;

namespace UI.Weather.Tests.Harness.Components
{
    public class ForecastRow
    {
        private int row;

        public IWebElement DayOfWeek => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=day-{row}]"));
        public IWebElement DayOfMonth => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=date-{row}]"));

        public IWebElement WeatherIcon => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=description-{row}]"));
        public IWebElement MaxTemp => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=maximum-{row}]"));
        public IWebElement MinTemp => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=minimum-{row}]"));

        public IWebElement WindSpeed => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=speed-{row}]"));
        public IWebElement DirectionIcon => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=direction-{row}]"));
        public IWebElement RainFall => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=rainfall-{row}]"));
        public IWebElement Pressure => DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=pressure-{row}]"));

        public ForecastRow(int row)
        {
            this.row = row;
        }
    }
}
