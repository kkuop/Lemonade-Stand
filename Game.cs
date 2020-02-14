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
        //constructor

        //member methods
        public void StartGame()
        {
            //Here is the best case for single responsibility (each method has its own responsibility as we run through the entire game)
            //Display rules
            DisplayRules();
            //How many people will be playing?
            HowManyPlayers();
            //Choose duration (7,14,21,28)
            //Display weather report
            //Get user input (how many glasses, what will be the price)
            //Crunch the numbers
            //Display report
            //Loop back through starting from displaying the weather report
        }
        private void DisplayRules()
        {
            Console.WriteLine("Welcome to Lemonade Stand!");
            Console.WriteLine("How to play:");
        }
        private void HowManyPlayers()
        {
            Console.WriteLine("How many players?");
            try
            {
                howManyPlayers = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("That is not a number... try again!");
                HowManyPlayers();
            }
            for (int i=0;i<howManyPlayers;i++)
            {
                new Player();
            }
        }
    }
}
