using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {
        public static void ClearConsole()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void DisplayRules()
        {
            Console.WriteLine("Welcome to Lemonade Stand!");
            ClearConsole();
            Console.WriteLine("How to play:\n");
            Console.WriteLine("You are in charge of a lemonade stand. Each day, \nyou will control the recipe, how many glasses\nyou make, and how much to charge for each one. \nHowever, there will be random weather patterns \nthat may affect your sales each day. Make the \nmost money at the end and you win!");
        }
        public static int HowManyPlayers(string prompt, int min, int max)
        {
            int userInput = 0;
            do
            {
                Console.Clear();
                Console.Write(prompt);
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nThat is not a number... try again!\n");

                }
            }
            while (userInput < min || userInput > max);
            return userInput;
        }
        public static int ChooseDuration(string prompt, int min, int max)
        {
            int userInput = 0;
            do
            {
                Console.Clear();
                Console.Write(prompt);
                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nThat is not a valid option... try again!\n");

                }
            } while (userInput < min || userInput > max);
            return userInput;
        }
        public static void DisplayWeatherInformation(string condition, int temp)
        {
            Console.WriteLine($"Today's forecast is: {condition}\n\nThe high temperature will be: {temp} ");
        }
        public static void DisplayRealWeatherInformation(string city, string condition, string temperature, string highTemperature, string precipitation)
        {
            Console.WriteLine($"Today's forecast for {city}:\n\n{condition}\n\nCurrent Temp: {temperature}\n\nHigh Temp: {highTemperature}\n\nPrecipitation: {precipitation}");
        }
        public static string ChooseWhereToOpenStand(string prompt)
        {
            Console.Clear();
            string userInput;
            Console.Write(prompt);
            userInput = Console.ReadLine();
            userInput.Replace(" ",string.Empty);
            userInput.Replace("  ", string.Empty);
            return userInput;
        } 
        public static void DisplayInventory(int player, int lemonCount, int sugarCount, int iceCount, int cupsCount, double money)
        {
            Console.Clear();
            Console.WriteLine($"Player {player}, here is your current inventory...\n");
            Console.WriteLine($"Lemons: {lemonCount}\nSugar Cubes: {sugarCount}\nIce Cubes: {iceCount}\nCups: {cupsCount}\n\nWallet: {money}");
        }
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
