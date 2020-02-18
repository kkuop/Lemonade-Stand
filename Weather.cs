﻿using System;
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
        Random parentRandom;

        //constructor
        public Weather(Random rng)
        {
            parentRandom = rng;
            condition = GenerateRandomCondition();
            temperature = GenerateRandomTemperature();
        }
        //member methods
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
