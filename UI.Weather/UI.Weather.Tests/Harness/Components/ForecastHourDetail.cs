using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        private WebDriverWait wait;
        private int row;
        private int hourRow;

        public IWebElement Hour => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=hour-{row}-{hourRow}]")));

        public IWebElement WeatherIcon => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=description-{row}-{hourRow}]")));
        public IWebElement MaxTemp => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=maximum-{row}-{hourRow}]")));
        public IWebElement MinTemp => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=minimum-{row}-{hourRow}]")));

        public IWebElement WindSpeed => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=speed-{row}-{hourRow}]")));
        public IWebElement DirectionIcon => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=direction-{row}-{hourRow}]")));
        public IWebElement RainFall => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=rainfall-{row}-{hourRow}]")));
        public IWebElement Pressure => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=pressure-{row}-{hourRow}]")));

        public ForecastHourDetail(int row, int hourRow)
        {
            this.row = row;
            this.hourRow = hourRow;
        }
    }
}
