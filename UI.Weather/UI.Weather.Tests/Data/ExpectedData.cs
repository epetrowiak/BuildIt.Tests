using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Weather.Tests.Data
{
    public class ExpectedData
    {
        public static IReadOnlyDictionary<string, List<string>> Edinburgh5Day = new Dictionary<string, List<string>>()
        {
            { "MaxTemp", new List<string>{"18°", "16°", "14°" , "14°" , "14°" } },
            { "MinTemp", new List<string>{ "6°", "4°", "11°", "8°" , "11°" } },
            { "WindSpeed", new List<string>{ "1kph", "1kph", "2kph", "6kph", "10kph" } },
            { "Rainfall", new List<string>{"0mm", "6mm", "8mm", "3mm", "20mm" } },
            { "Pressure", new List<string>{"1008mb", "1006mb", "1002mb", "1001mb", "995mb" } },
        };

        public static IReadOnlyDictionary<string, List<string>> EdinburghDay1Forecast= new Dictionary<string, List<string>>()
        {
            { "Time", new List<string>{"1300", "1600", "1900", "2200" } },
            { "MaxTemp", new List<string>{"18°", "17°", "14°" , "7°" } },
            { "MinTemp", new List<string>{ "14°", "15°", "12°", "6°" } },
            { "WindSpeed", new List<string>{ "1kph", "1kph", "1kph", "1kph" } },
            { "Rainfall", new List<string>{"0mm", "0mm", "0mm", "0mm" } },
            { "Pressure", new List<string>{"1008mb", "1007mb", "1007mb", "1007mb",} },
        };
    }
}
