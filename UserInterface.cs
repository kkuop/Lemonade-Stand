using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {
        public static int GetIntUserInput(string prompt, int min, int max)
        {
            int userInput = 0;
            do
            {
                
                Console.Write(prompt);
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("That was not valid input... try again!");
                }
            } while (userInput < min || userInput > max);
            return userInput;

        }
        public static double GetDoubleUserInput(string prompt, double min, double max)
        {
            double userInput = 0;
            do
            {

                Console.Write(prompt);
                try
                {
                    userInput = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("That was not valid input... try again!");
                }
            } while (userInput < min || userInput > max);
            return userInput;
        }
        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.Write("Please enter a positive integer (or 0 to cancel):\n__");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }
    }
}
