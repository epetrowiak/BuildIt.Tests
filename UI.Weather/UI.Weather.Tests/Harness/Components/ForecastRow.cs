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
    public class ForecastRow
    {
        private WebDriverWait wait;
        private int row;

        public IWebElement DayOfWeek => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=day-{row}]")));
        public IWebElement DayOfMonth => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=date-{row}]")));

        public IWebElement WeatherIcon => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=description-{row}]")));
        public IWebElement MaxTemp => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=maximum-{row}]")));
        public IWebElement MinTemp => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=minimum-{row}]")));

        public IWebElement WindSpeed => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=speed-{row}]")));
        public IWebElement DirectionIcon => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=direction-{row}]")));
        public IWebElement RainFall => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=rainfall-{row}]")));
        public IWebElement Pressure => wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector($"span[data-test=pressure-{row}]")));

        public ForecastRow(int row)
        {
            this.row = row;
        }

        public bool Exists()
        {
            try
            {
                return DriverFactory.Instance.FindElement(By.CssSelector($"span[data-test=day-{row}]")).Displayed;
            }
            catch(NoSuchElementException e)
            {
                return false;
            }

        }

    }
}
