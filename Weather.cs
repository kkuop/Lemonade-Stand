using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        //member vars
        public string condition;
        public int temperature;
        int lowRangeForBadConditions;
        int highRangeForBadConditions;
        int lowRangeForGoodConditions;
        int highRangeForGoodConditions;
        int lowRangeForMediumConditions;
        int highRangeForMediumConditions;
        //constructor
        public Weather()
        {
            lowRangeForBadConditions = 45;
            highRangeForBadConditions = 65;
            lowRangeForMediumConditions = 65;
            highRangeForMediumConditions = 85;
            lowRangeForGoodConditions = 75;
            highRangeForGoodConditions = 95;
            condition = GenerateRandomCondition();
            temperature = GenerateRandomTemperature();
        }
        //member methods
        private string GenerateRandomCondition()
        {
            int randomValue = new Random().Next(1, 30);
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
                return new Random().Next(lowRangeForBadConditions, highRangeForBadConditions);
            }
            else if (condition == "Mostly Sunny")
            {
                return new Random().Next(lowRangeForMediumConditions, highRangeForMediumConditions);
            }
            else
            {
                return new Random().Next(lowRangeForGoodConditions, highRangeForGoodConditions);
            }            
        }
    }
}
