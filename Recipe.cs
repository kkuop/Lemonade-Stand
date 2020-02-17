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
        private void ClearConsole()
        {
            Console.WriteLine("That is not valid input!\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public int HowManyLemons()
        {
            int userInput = 0;
            Console.WriteLine("How many lemons should your pitcher contain?");
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception)
            {
                ClearConsole();
                HowManyLemons();
            }
            amountOfLemons = userInput;
            return userInput;
        }
        public int HowManySugars()
        {
            int userInput = 0;
            Console.WriteLine("How many sugar cubes should your pitcher contain?");
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                ClearConsole();
                HowManySugars();
            }
            return userInput;
        }
        public int HowManyIceCubes()
        {
            int userInput = 0;
            Console.WriteLine("How many ice cubes should your pitcher contain?");
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                ClearConsole();
                HowManyIceCubes();
            }
            return userInput;
        }
        public double HowMuchPerCup()
        {
            double userInput = 0;
            Console.WriteLine("How much would you like to charge per cup?");
            try
            {
                userInput = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception)
            {
                ClearConsole();
                HowMuchPerCup();
            }
            return userInput;
        }
    }
}
