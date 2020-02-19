using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        //member vars
        public string City { get; set; }
        public string Temperature { get; set; }
        public string HighTemperature { get; set; }
        public string Condition { get; set; }
        public string Precipitation { get; set; }

        public int currentDay;
        public string condition;
        public int temperature;
        Random parentRandom;
        WeatherAPI weatherAPI;

        //constructor
        public Weather(Random rng)
        {
            parentRandom = rng;
            condition = GenerateRandomCondition();
            temperature = GenerateRandomTemperature();
        }
        public Weather(string city, int currentDay)
        {
            weatherAPI = new WeatherAPI(city,currentDay);
            City = city;
            this.currentDay = currentDay;
        }
        //member methods
        public void CheckWeather()
        {
            Temperature = weatherAPI.GetCurrentTemperature(currentDay);
            HighTemperature = weatherAPI.GetHighTemperature(currentDay);
            Condition = weatherAPI.GetDescription(currentDay);
            Precipitation = weatherAPI.GetPrecipitation(currentDay);
        }
        private string GenerateRandomCondition()
        {
            int randomValue = parentRandom.Next(1, 30);
            if (randomValue <= 5)
            {
                return "Thunderstorms";
            }
            else if (randomValue > 5 && randomValue < 15)
            {
                return "Mostly Sunny";
            }
            else
            {
                return "Hot and Dry";
            }
        }
        private int GenerateRandomTemperature()
        {
            if(condition=="Thunderstorms")
            {                
                return parentRandom.Next(45, 65);
            }
            else if (condition == "Mostly Sunny")
            {
                return parentRandom.Next(65, 80);
            }
            else
            {
                return parentRandom.Next(75, 99);
            }            
        }
    }
}
