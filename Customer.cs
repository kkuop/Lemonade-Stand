using System;
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
        public int likesHowMuchLemon;
        public int likesHowMuchSugar;
        public int likesHowMuchIce;
        Random parentRandom;
        
        //constructor
        public Customer(Random rng)
        {
            parentRandom = rng;
            name = GetName();
            buyingPower = CalculateBuyingPower();
            likesHowMuchIce = DetermineHowMuchIceCustomerLikes();
            likesHowMuchLemon = DetermineHowMuchLemonCustomerLikes();
            likesHowMuchSugar = DetermineHowMuchSugarCustomerLikes();
        }
        //member methods
        private string GetName()
        {
            names = new List<string> { "Beckie ", "Casimira  ", "Myesha  ", "Monika  ", "Una  ", "Cesar  ", "Renae  ", "Aleisha  ", "Randy  ", "Jordon  ", "Geraldo  ", "Normand  ", "Marilu  ", "Madeline  ", "Francesco  ", "Hulda  ", "Carolyn  ", "Marline  ", "Anderson  ", "Marquitta  ", "Lupita  ", "Louella  ", "Lottie  ", "Alfonzo  ", "Yanira  ", "Rona  ", "Newton  ", "Latina  ", "Vicente  ", "Migdalia  ", "Winfred  ", "Somer  ", "Raphael  ", "Shakira  ", "Ghislaine  ", "Fiona  ", "Deanna  ", "Eldora  ", "Cinda  ", "Desmond  ", "Mistie  ", "Lashaun  ", "Dusty  ", "Tanja  ", "Christinia  ", "Rhea  ", "Marg  ", "Ashanti  ", "Filiberto  ", "Harley  " };
            string chosenOne = names[parentRandom.Next(0,50)];
            return chosenOne;
        }
        private double CalculateBuyingPower ()
        {
            int randomInteger = parentRandom.Next(0,5);
            double randomDouble = parentRandom.NextDouble();
            double result = randomInteger + randomDouble;
            return result;
        }
        private int DetermineHowMuchIceCustomerLikes()
        {
            int iceRandom = parentRandom.Next(1, 100);
            if (iceRandom < 20) 
            { 
                return parentRandom.Next(1, 3);
            }
            else if (iceRandom >= 20 && iceRandom <= 80)
            {
                return parentRandom.Next(3, 8);
            }
            else
            {
                return parentRandom.Next(8, 11);
            }
        }
        private int DetermineHowMuchLemonCustomerLikes()
        {
            int lemonRandom = parentRandom.Next(1, 100);
            if (lemonRandom < 20)
            {
                return parentRandom.Next(1, 3);
            }
            else if (lemonRandom >= 20 && lemonRandom <= 80)
            {
                return parentRandom.Next(3, 8);
            }
            else
            {
                return parentRandom.Next(8, 11);
            }
        }
        private int DetermineHowMuchSugarCustomerLikes()
        {
            int sugarRandom = parentRandom.Next(1, 100);
            if (sugarRandom < 20)
            {
                return parentRandom.Next(1, 3);
            }
            else if (sugarRandom >=20 && sugarRandom <=80)
            {
                return parentRandom.Next(3, 8);
            }
            else
            {
                return parentRandom.Next(8, 11);
            }
        }
    }
}
