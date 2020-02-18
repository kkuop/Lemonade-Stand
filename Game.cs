using System;
using System.Collections.Generic;

namespace LemonadeStand_3DayStarter
{
    public class Game
    {
        //member vars
        int howManyPlayers;
        int howManyDays;
        List<Player> player;
        List<Day> days;
        int currentDay;
        Store store;
        Random random;
        
        //constructor
        public Game()
        {
            random = new Random();
        }
        //member methods
        public void StartGame()
        {
            currentDay = 0;
            //Here is the best case for single responsibility (each method has its own responsibility as we run through the entire game)
            //Display rules
            DisplayRules();
            ClearConsole();
            //How many people will be playing?
            HowManyPlayers();
            //Choose duration 
            ChooseDuration();
            GenerateListOfDays();
            //Here is a case for the Open/Closed principle of SOLID
            //this while loop is open for extension but closed to modification
            while (currentDay < howManyDays)
            {
                Console.Clear();
                //Display menu
                DisplayMenu();
                Console.Clear();
                //Weather
                DisplayWeatherInformation();
                ClearConsole();
                //How many pitchers to make
                PrepareThePitcher();
                ClearConsole();
                //Set the cupsBefore var
                SetPitchersBeforeValue();
                //Open for business
                OpenForBusiness();
                //Set cupsSold equals to cupsBefore minus cupsLeftInPitcher
                RemoveCupsFromInventory();
                //Deduct what was used
                SubtractWhatWasUsedFromInventory();
                AddProfitsToWallet();
                //Display report
                DisplayReport();
                ClearConsole();
                ResetCupsSoldCounter();
                //Loop back through 
                currentDay++;                
            }
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
            do
            {
                Console.Clear();
                Console.Write("How many players?  (1-30)\n\n__");
                try
                {
                    howManyPlayers = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nThat is not a number... try again!\n");

                }
            }
            while (howManyPlayers < 1 || howManyPlayers > 30);
            for (int i = 0; i < howManyPlayers; i++)
            {
                player.Add(new Player());
            }
            Console.Clear();
        }

        private void ChooseDuration()
        {
            do
            {
                Console.Clear();
                Console.Write("How many days would you like the game to run?  (7-100)\n\n__");
                try
                {
                    howManyDays = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nThat is not a valid option... try again!\n");

                }
            } while (howManyDays < 7 || howManyDays > 100);
        }

        private void GenerateListOfDays()
        {
            days = new List<Day>();
            for (int i = 0; i < howManyDays; i++)
            {
                days.Add(new Day(random));

            }
            currentDay = 0;
        }

        private void DisplayWeatherInformation()
        {
            Console.WriteLine($"Today's forecast is: {days[currentDay].weather.condition}\n\nThe high temperature will be: {days[currentDay].weather.temperature} ");

        }

        private void DisplayInventory()
        {
            //Another SOLID principle... each of the methods will have a for loop
            //that allows for extension of the number of players without modifying the code
            for (int i = 0; i < howManyPlayers; i++)
            {
                Console.Clear();
                Console.WriteLine($"Player {i + 1}, here is your current inventory...\n");
                Console.WriteLine($"Lemons: {player[i].inventory.lemons.Count}\nSugar Cubes: {player[i].inventory.iceCubes.Count}\nIce Cubes: {player[i].inventory.iceCubes.Count}\nCups: {player[i].inventory.cups.Count}\n\nWallet: {player[i].wallet.Money}");
                ClearConsole();
            }
            Console.Clear();
            DisplayMenu();
        }

        private void BuyIngredientsFromStore()
        {
            store = new Store();

            for (int i = 0; i < player.Count; i++)
            {
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to stock your inventory...\n");
                store.SellLemons(player[i]);
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to stock your inventory...\n");
                store.SellSugarCubes(player[i]);
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to stock your inventory...\n");
                store.SellIceCubes(player[i]);
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to stock your inventory...\n");
                store.SellCups(player[i]);
            }
            Console.Clear();
            DisplayMenu();
        }

        private void BuildRecipe()
        {
            Console.Clear();
            for (int i = 0; i < player.Count; i++)
            {
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to build your recipe...\n\nCurrent value: {player[i].recipe.amountOfLemons}\n");
                //player[i].recipe.amountOfLemons = player[i].recipe.HowManyLemons();
                player[i].recipe.HowManyLemons();
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to build your recipe...\n\nCurrent value: {player[i].recipe.amountOfSugarCubes}\n");
                player[i].recipe.HowManySugars();
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to build your recipe...\n\nCurrent value: {player[i].recipe.amountOfIceCubes}\n");
                player[i].recipe.HowManyIceCubes();
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to build your recipe...\n\nCurrent value: {player[i].recipe.pricePerCup}\n");
                player[i].recipe.HowMuchPerCup();

            }
            Console.Clear();
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            ConsoleKeyInfo userInput;
            do
            {
                Console.WriteLine("Please choose an option...\n\na)Change Recipe\nb)Buy Ingredients\nc)See Inventory\nd)Advance Day\n");
                userInput = Console.ReadKey();
                if (userInput.KeyChar == 'a')
                {
                    BuildRecipe();
                }
                else if (userInput.KeyChar == 'b')
                {
                    BuyIngredientsFromStore();
                }
                else if (userInput.KeyChar == 'c')
                {
                    DisplayInventory();
                }
                else if (userInput.KeyChar == 'd')
                {
                    for (int i = 0; i < howManyPlayers; i++)
                    {
                        if (player[i].recipe.amountOfLemons < 1 || player[i].recipe.amountOfSugarCubes < 1 || player[i].recipe.amountOfIceCubes < 1 || player[i].recipe.pricePerCup < .05)
                        {
                            Console.Clear();
                            Console.WriteLine($"Player {i + 1}, you should setup your recipe first!\n");
                            DisplayMenu();
                        }

                        if (player[i].inventory.lemons.Count < 1 || player[i].inventory.sugarCubes.Count < 1 || player[i].inventory.iceCubes.Count < 1 || player[i].inventory.cups.Count < 1)
                        {
                            Console.Clear();
                            Console.WriteLine($"Player {i + 1}, you should buy some inventory first!\n");
                            DisplayMenu();
                        }
                    }
                }
            } while (userInput.KeyChar != 'a' && userInput.KeyChar != 'b' && userInput.KeyChar != 'c' && userInput.KeyChar != 'd');
        }

        private void PrepareThePitcher()
        {
            int userInput = -1;
            int maxLemons;
            int maxSugars;
            int maxIce;
            int maxPitchers;
            for (int i = 0; i < player.Count; i++)
            {
                maxLemons = player[i].inventory.lemons.Count / player[i].recipe.amountOfLemons;
                maxSugars = player[i].inventory.sugarCubes.Count / player[i].recipe.amountOfSugarCubes;
                maxIce = player[i].inventory.iceCubes.Count / player[i].recipe.amountOfIceCubes;
                if ((maxLemons < maxSugars) && (maxLemons < maxIce))
                {
                    maxPitchers = maxLemons;
                }
                else if ((maxSugars < maxLemons) && (maxSugars < maxIce)) {
                    maxPitchers = maxSugars;
                }
                else
                {
                    maxPitchers = maxIce;
                }
                //fix the following line
                
                do
                {
                    Console.Clear();
                    Console.Write($"Player {i + 1}, how many pitchers of lemonade would you\nlike to make? You have enough supply to make {maxPitchers}...\n\n__");
                    try
                    {
                        userInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("That is not valid input... try again!");
                    }
                } while (userInput < 0 || userInput > maxPitchers);


                //add pitchers to list
                for (int j = 0; j < userInput; j++)
                {
                    player[i].listOfPitchers.Add(new Pitcher());
                }
            }
        }

        private void SetPitchersBeforeValue()
        {
            //make two vars to track count of pitchers before and after
            for (int i = 0; i < howManyPlayers; i++)
            {
                    player[i].pitchersBefore = player[i].listOfPitchers.Count;
            }
        }

        private void OpenForBusiness()
        {
            for (int i = 0; i < howManyPlayers; i++)
            {
                for (int j = 0; j < days[currentDay].customers.Count; j++)
                {
                    //fix when the list of pitchers is emptied
                    if (player[i].listOfPitchers.Count < 1)
                    {
                        continue;
                    }
                    if (
                        (days[currentDay].customers[j].buyingPower > player[i].recipe.pricePerCup) &&
                        (days[currentDay].customers[j].likesHowMuchIce - player[i].recipe.amountOfIceCubes < 2 || days[currentDay].customers[j].likesHowMuchIce - player[i].recipe.amountOfIceCubes > -2) &&
                        (days[currentDay].customers[j].likesHowMuchLemon - player[i].recipe.amountOfLemons < 2 || days[currentDay].customers[j].likesHowMuchLemon - player[i].recipe.amountOfLemons > -2) &&
                        (days[currentDay].customers[j].likesHowMuchSugar - player[i].recipe.amountOfSugarCubes < 2 || days[currentDay].customers[j].likesHowMuchSugar - player[i].recipe.amountOfSugarCubes > -2))
                    {
                        player[i].listOfPitchers[0].PourACup();
                        player[i].cupsSoldCounter++;
                        Console.WriteLine($"{days[currentDay].customers[j].name} purchased a cup of lemonade!");
                        if(player[i].listOfPitchers[0].cupsLeftInPitcher<1)
                        {
                            player[i].listOfPitchers.RemoveAt(0);
                        }
                    }
                }
            }
        }

        private void RemoveCupsFromInventory()
        {
            //when for loop is done, update the cupsSold to reflect how much was sold
            for (int i = 0; i < howManyPlayers; i++)
            {
                
                for (int j = 0; j < player[i].cupsSoldCounter; j++)
                {
                    player[i].inventory.cups.RemoveAt(0);
                }

            }
        }

        private void SubtractWhatWasUsedFromInventory()
        {
            int pitchersUsed;
            
            for (int i = 0; i < howManyPlayers; i++)
            {
                try
                {
                    pitchersUsed = (player[i].cupsSoldCounter / player[i].pitchersBefore) + 1;
                }
                catch(Exception)
                {
                    continue;
                }
                
                for (int j = 0; j < player[i].recipe.amountOfLemons * pitchersUsed; j++)
                {
                    player[i].inventory.RemoveLemonsFromInventory();
                }
                for (int j = 0; j < player[i].recipe.amountOfSugarCubes * pitchersUsed; j++)
                {
                    player[i].inventory.RemoveSugarCubesFromInventory();
                }
                for (int j = 0; j < player[i].recipe.amountOfIceCubes * pitchersUsed; j++)
                {
                    player[i].inventory.RemoveIceCubesFromInventory();
                }
            }
        }

        private void AddProfitsToWallet()
        {
            for (int i = 0; i < howManyPlayers; i++)
            {
                double profits = player[i].recipe.pricePerCup * player[i].cupsSoldCounter;
                player[i].wallet.AddMoneyToWallet(profits);
            }
        }

        private void DisplayReport()
        {
            for (int i = 0; i < howManyPlayers; i++)
            {
                Console.Write($"\nPlayer {i + 1}, you sold {player[i].cupsSoldCounter} cups of lemonade!\n\nHere is your updated inventory...\nLemons: {player[i].inventory.lemons.Count}\nSugar Cubes: {player[i].inventory.sugarCubes.Count}\nIce Cubes: {player[i].inventory.iceCubes.Count}\nCups: {player[i].inventory.cups.Count}\n\nWallet: {player[i].wallet.Money}");

            }
        }
        private void ResetCupsSoldCounter()
        {
            for (int i = 0; i < howManyPlayers; i++)
            {
                player[i].cupsSoldCounter = 0;
            }
        }
    }
}
