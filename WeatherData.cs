using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class WeatherData
    {
        public string City { get; set; }
        public string Temperature { get; set; }
        public string HighTemperature { get; set; }
        public string Condition { get; set; }
        public string Precipitation { get; set; }

        public int currentDay;
        //constructor
        public WeatherData(string City, int currentDay)
        {
            this.City = City;
            this.currentDay = currentDay;
        }
        //member methods
        public void CheckWeather()
        {
            WeatherAPI weatherAPI = new WeatherAPI(City);
            Temperature = weatherAPI.GetCurrentTemperature(currentDay);
            HighTemperature = weatherAPI.GetHighTemperature(currentDay);
            Condition = weatherAPI.GetDescription(currentDay);
            Precipitation = weatherAPI.GetPrecipitation(currentDay);
        }
    }
}
