using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        //member vars
        public Weather weather;
        public WeatherData weatherReal;
        public List<Customer> customers;
        Random parentRandom;
        private int dayCount;
        
        //constructor
        public Day(Random Rng, string city, int dayCounterForWeather)
        {
            parentRandom = Rng;
            this.dayCount = dayCounterForWeather;            
            if (dayCounterForWeather <= 5)
            {                
                weatherReal = new WeatherData(city, dayCounterForWeather);
                weatherReal.CheckWeather();               
            }
            else
            {
                weather = new Weather(parentRandom);
            }
            customers = DetermineNumberOfCustomers();
        }
        //member methods
        private List<Customer> DetermineNumberOfCustomers ()
        {
            int amountOfCustomers;
            customers = new List<Customer>();
            if (dayCount <= 5)
            {
                if (Convert.ToDouble(weatherReal.HighTemperature) > 75)
                {
                    amountOfCustomers = parentRandom.Next(30, 50);
                }
                else if (Convert.ToDouble(weatherReal.HighTemperature) > 65)
                {
                    amountOfCustomers = parentRandom.Next(10, 35);
                }
                else
                {
                    amountOfCustomers = parentRandom.Next(0, 15);
                }
            }
            else
            {
                if (weather.condition == "Hot and Dry" )
                {
                    amountOfCustomers = parentRandom.Next(30, 50);

                }
                else if (weather.condition == "Mostly Sunny" )
                {
                    amountOfCustomers = parentRandom.Next(10, 35);
                }
                else
                {
                    amountOfCustomers = parentRandom.Next(0, 15);

                }
            }
            for (int i = 0; i < amountOfCustomers; i++)
            {
                customers.Add(new Customer(parentRandom));
            }
            return customers;
        }
    }
}
