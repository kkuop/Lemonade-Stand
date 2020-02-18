﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        //member vars
        public string name;
        private List<string> names;
        public double buyingPower;        
        
        //constructor
        public Customer()
        {
            name = GetName();
            buyingPower = CalculateBuyingPower();
        }
        //member methods
        private string GetName()
        {
            names = new List<string> { "Beckie ", "Casimira  ", "Myesha  ", "Monika  ", "Una  ", "Cesar  ", "Renae  ", "Aleisha  ", "Randy  ", "Jordon  ", "Geraldo  ", "Normand  ", "Marilu  ", "Madeline  ", "Francesco  ", "Hulda  ", "Carolyn  ", "Marline  ", "Anderson  ", "Marquitta  ", "Lupita  ", "Louella  ", "Lottie  ", "Alfonzo  ", "Yanira  ", "Rona  ", "Newton  ", "Latina  ", "Vicente  ", "Migdalia  ", "Winfred  ", "Somer  ", "Raphael  ", "Shakira  ", "Ghislaine  ", "Fiona  ", "Deanna  ", "Eldora  ", "Cinda  ", "Desmond  ", "Mistie  ", "Lashaun  ", "Dusty  ", "Tanja  ", "Christinia  ", "Rhea  ", "Marg  ", "Ashanti  ", "Filiberto  ", "Harley  " };
            string chosenOne = names[new Random().Next(0,50)];
            return chosenOne;
        }
        private double CalculateBuyingPower ()
        {
            int randomInteger = new Random().Next(0,10);
            double randomDouble = new Random().NextDouble();
            double result = randomInteger + randomDouble;
            return result;
        }
    }
}
