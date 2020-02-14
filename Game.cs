using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        //member vars
        int howManyPlayers;
        int howManyDays;
        //constructor

        //member methods
        public void StartGame()
        {
            //Here is the best case for single responsibility (each method has its own responsibility as we run through the entire game)
            //Display rules
            DisplayRules();
            ClearConsole();
            //How many people will be playing?
            HowManyPlayers();
            ClearConsole();
            //Choose duration (7,14,21,28)
            ChooseDuration();
            ClearConsole();
            //Display weather report
            //Get user input (how many glasses, what will be the price)
            //Crunch the numbers
            //Display report
            //Loop back through starting from displaying the weather report
        }
        private void ClearConsole()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void DisplayRules()
        {
            Console.WriteLine("Welcome to Lemonade Stand!");
            ClearConsole();
            Console.WriteLine("How to play:\n");
            Console.WriteLine("You are in charge of a lemonade stand. Each day, \nyou will control the recipe, how many glasses\nyou make, and how much to charge for each one. \nHowever, there will be random weather patterns \nthat may affect your sales each day. Make the \nmost money at the end and you win!");
            
        }
        private void HowManyPlayers()
        {
            Console.Write("How many players?\n\n__");
            try
            {
                howManyPlayers = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\nThat is not a number... try again!\n");
                HowManyPlayers();
            }
            for (int i=0;i<howManyPlayers;i++)
            {
                new Player();
            }
            
        }
        private void ChooseDuration()
        {
            Console.Write("How many days would you like the game to run? (At least 7 and no more than 100)\n\n__");
            try
            {
                howManyDays = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception)
            {
                Console.WriteLine("\nThat is not a number... try again!\n");
                ChooseDuration();
            }
            if(howManyDays<7||howManyDays>100)
            {
                Console.Clear();
                Console.WriteLine("Please pick a number between 7 and 100!");
                ClearConsole();                
                ChooseDuration();
            }
            else
            {
                Console.WriteLine("\nHere comes day 1");
            }
            
        }
    }
}
