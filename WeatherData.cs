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
        public string Condition { get; set; }

        //constructor
        public WeatherData(string City)
        {
            this.City = City;
        }
        //member methods
        public void CheckWeather()
        {
            WeatherAPI weatherAPI = new WeatherAPI(City);
            Temperature = weatherAPI.GetTemperature();
            Condition = weatherAPI.GetDescription();
        }
    }
}
