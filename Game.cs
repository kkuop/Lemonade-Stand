﻿using System;
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
        List<Player> player;
        List<Day> days;
        int currentDay;
        Store store;
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
            //Choose duration (7,14,21,28)
            ChooseDuration();
            ClearConsole();
            //Display weather report
            GenerateListOfDays();
            DisplayWeatherInformation();
            ClearConsole();
            //Get user input (how many glasses, what will be the price)
            BuyIngredientsFromStore();
            BuildRecipe();
            //Crunch the numbers (run the algorithm)
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
            player = new List<Player>();
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
                player.Add(new Player());
            }
            Console.Clear();
            
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
                Console.Clear();
                Console.WriteLine("\nHere comes day 1");                
            }
            
        }

        private void GenerateListOfDays()
        {
            days = new List<Day>();
            for (int i = 0; i < howManyDays; i++)
            {
                days.Add(new Day());
            }
        }
        private void DisplayWeatherInformation()
        {
            currentDay = 0;
            Console.WriteLine($"Today's forecast is: {days[currentDay].weather.condition}\n\nThe high temperature will be: {days[currentDay].weather.temperature} ");
        }
        private void BuyIngredientsFromStore()
        {
            store = new Store();
            
            for (int i = 0; i < player.Count; i++)
            {
                Console.Clear();
                Console.WriteLine($"\nPlayer {i+1}, it's time to make your lemonade...");
                store.SellLemons(player[i]);
                store.SellSugarCubes(player[i]);
                store.SellIceCubes(player[i]);
                store.SellCups(player[i]);
            }            
        }
        private void BuildRecipe()
        {
            for (int i = 0; i < player.Count; i++)
            {
                Console.Clear();
                Console.WriteLine($"\nPlayer {i+1}, it's time to build your recipe...");
                player[i].recipe.HowManyLemons();
                player[i].recipe.HowManySugars();
                player[i].recipe.HowManyIceCubes();
                player[i].recipe.HowMuchPerCup();
            }
        }
    }
}
