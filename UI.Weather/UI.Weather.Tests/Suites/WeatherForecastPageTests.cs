using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UI.Weather.Tests.Harness.Components;

namespace UI.Weather.Tests.Suites
{
    [TestClass]
    public class WeatherForecastPageTests : BaseTest
    {
        [TestInitialize]
        public void Setup()
        {
            WeatherPage.Navigate();
        }

        [TestMethod]
        public void ForecastDefaultsToGlasgow()
        {
            //Assert
            Assert.IsTrue(WeatherPage.TitleHeader.Displayed, "Unable to find header");
            Assert.AreEqual("Glasgow", WeatherPage.GetCurrentCity()
                , "Unexpected city found on initial page open.");
        }

        [TestMethod]
        public void ForecastShowsNext5Days()
        {
            //Setup
            var now = DateTime.Now;

            //Assert
            for(int i = 0; i < 5; i++)
            {
                string expectedWeekDay = now.AddDays(i).DayOfWeek.ToString().Substring(0, 3);
                int expectedDate = now.AddDays(i).Day;
                ForecastRow forecastRow = WeatherPage.ForecastDay(i + 1);
                Assert.AreEqual(expectedWeekDay, forecastRow.DayOfWeek.Text, "Day of week is incorrect in row " + i);
                Assert.AreEqual(expectedDate, forecastRow.DayOfMonth.Text, "Day of month is incorrect in row " + i);
            }
        }

        [TestMethod]
        public void ForecastIsUpdatedWhenCityIsChanged()
        {
            //Setup
            var initialTemp = GetForecastTemps();

            //Execute
            WeatherPage.UpdateCity("Edinburgh");

            //Assert
            Assert.AreNotEqual(initialTemp, GetForecastTemps(), "Temperatures were not updated.");
        }

        [TestMethod]
        public void ErrorIsShownWhenCityIsNotInUK()
        {
            //Setup

            //Execute
            WeatherPage.UpdateCity("Madrid");

            //Assert
            Assert.IsTrue(WeatherPage.ErrorMessage.Displayed, "Error message is not visible");
            Assert.AreEqual("Error retrieving the forecast", WeatherPage.ErrorMessage.Text, "Error message is incorrect");
        }

        //Helpers

        private string GetForecastTemps()
        {
            var weekTemp = "";
            for (int i = 1; i <= 5; i++)
            {
                weekTemp += WeatherPage.ForecastDay(i).MaxTemp.Text;
            }

            return weekTemp;
        }
    }
}
