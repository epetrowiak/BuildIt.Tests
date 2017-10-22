using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UI.Weather.Tests.Harness.Components;
using UI.Weather.Tests.Data;

namespace UI.Weather.Tests.Suites
{
    [TestClass]
    public class WeatherForecastPageTests : BaseTest
    {
        public TestContext TestContext { get; set; }

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

        [TestMethod] //This will expect actual integration to service
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
     //  [DeploymentItem("Resources\\Edinburgh.csv")]
      //  [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "Resources\\Edinburgh.csv", "Edinburgh#csv", DataAccessMethod.Sequential)]
        public void ForecastIsUpdatedWhenCityIsChanged()
        {
            //Setup

            //Execute
            WeatherPage.UpdateCity("Edinburgh");

            //Assert
            for(int i = 1; i <= 5; i++)
            {
                VerifyForecastRow(i);
            }
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
        
        [TestMethod]
        public void DetailedForecastIsShownWhenClickingOnToday()
        {
            //Setup
            int rowNum = 1;
            var todayRow = WeatherPage.ForecastDay(rowNum);

            //Execute
            WeatherPage.UpdateCity("Edinburgh");
            todayRow.DayOfWeek.Click();

            //Assert
            for (int i = 1; i <= 4; i++)
            {
                VerifyForecastDetail(rowNum, i);
            }
        }

        [TestMethod]
        public void Only5DaysExistInForecast()
        {
            //Assert
            Assert.IsFalse(WeatherPage.ForecastDay(6).Exists());
        }

        //Helpers
        private void VerifyForecastDetail(int rowNum, int hourRow)
        {
            var row = WeatherPage.ForecastDetail(rowNum, hourRow);
            int collIndex = hourRow - 1;
            Assert.AreEqual(ExpectedData.EdinburghDay1Forecast["Time"][collIndex], row.Hour.Text, "Time is incorrect.");
            Assert.AreEqual(ExpectedData.EdinburghDay1Forecast["MaxTemp"][collIndex], row.MaxTemp.Text, "Max Temperature was not updated.");
            Assert.AreEqual(ExpectedData.EdinburghDay1Forecast["MinTemp"][collIndex], row.MinTemp.Text, "Min Temperature was not updated.");
            Assert.AreEqual(ExpectedData.EdinburghDay1Forecast["WindSpeed"][collIndex], row.WindSpeed.Text, "Wind Speed was not updated.");
            Assert.AreEqual(ExpectedData.EdinburghDay1Forecast["Rainfall"][collIndex], row.RainFall.Text, "Rain was not updated.");
            Assert.AreEqual(ExpectedData.EdinburghDay1Forecast["Pressure"][collIndex], row.Pressure.Text, "Pressure was not updated.");
        }

        private void VerifyForecastRow(int rowNum)
        {
            var row = WeatherPage.ForecastDay(rowNum);
            int collIndex = rowNum - 1;
            Assert.AreEqual(ExpectedData.Edinburgh5Day["MaxTemp"][collIndex], row.MaxTemp.Text, "Max Temperature was not updated.");
            Assert.AreEqual(ExpectedData.Edinburgh5Day["MinTemp"][collIndex], row.MinTemp.Text, "Min Temperature was not updated.");
            Assert.AreEqual(ExpectedData.Edinburgh5Day["WindSpeed"][collIndex], row.WindSpeed.Text, "Wind Speed was not updated.");
            Assert.AreEqual(ExpectedData.Edinburgh5Day["Rainfall"][collIndex], row.RainFall.Text, "Rain was not updated.");
            Assert.AreEqual(ExpectedData.Edinburgh5Day["Pressure"][collIndex], row.Pressure.Text, "Pressure was not updated.");
        }
    }
}
