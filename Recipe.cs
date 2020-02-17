using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        //member vars
        public int amountOfLemons;
        public int amountOfSugarCubes;
        public int amountOfIceCubes;
        public double pricePerCup;
        //constructor
        public Recipe()
        {
            amountOfLemons = 0;
            amountOfSugarCubes = 0;
            amountOfIceCubes = 0;
            pricePerCup = 0;
            }
        //member methods
        
        public int HowManyLemons()
        {
            int userInput = 0;
            do {
                Console.Clear();
                Console.WriteLine("How many lemons should your pitcher contain?\n\n(1-10)");
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("That was not valid input... try again!");
                }
            } while (userInput<1 || userInput > 10);
            amountOfLemons = userInput;
            return userInput;
        }
        public int HowManySugars()
        {
            int userInput = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("How many sugar cubes should your pitcher contain?\n\n(1-10)");
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("That was not valid input... try again!");
                }
            } while (userInput < 1 || userInput > 10);
            return userInput;
        }
        public int HowManyIceCubes()
        {
            int userInput = 0;
            
            do
            {
                Console.Clear();
                Console.WriteLine("How many ice cubes should your pitcher contain?\n\n(1-10)");
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("That was not valid input... try again!");
                }
            } while (userInput < 1 || userInput > 10);
            return userInput;
        }
        public double HowMuchPerCup()
        {
            double userInput = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("How much would you like to charge per cup?\n\n(0.05-10)");
                try
                {
                    userInput = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("That was not valid input... try again!");
                }
            } while (userInput < .05 || userInput > 10);
            return userInput;
        }
    }
}
