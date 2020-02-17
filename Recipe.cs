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
        private void ClearCurrentConsoleLine()
        {
            int currentCursorLine = Console.CursorTop - 1;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentCursorLine);
        }
        public int HowManyLemons()
        {
            int userInput = 0;
            do {
                ClearCurrentConsoleLine();
                Console.Write("How many lemons should your pitcher contain? (1-10)\n\n__");
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
                ClearCurrentConsoleLine();
                Console.Write("How many sugar cubes should your pitcher contain?  (1-10)\n\n__");
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
                ClearCurrentConsoleLine();
                Console.Write("How many ice cubes should your pitcher contain?  (1-10)\n\n__");
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
                ClearCurrentConsoleLine();
                Console.Write("How much would you like to charge per cup?  (0.05-10)\n\n__");
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
