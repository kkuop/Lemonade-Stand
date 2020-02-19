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
            //this while loop is open for extension and closed to modification
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
                //Deduct what was used
                SubtractWhatWasUsedFromInventory();
                AddProfitsToWallet();
                //Display report
                DisplayReport();
                ClearConsole();
                ResetCupsSoldCounter();
                PourOutUnsoldLemonade();
                //Loop back through 
                currentDay++;                
            }
            //Compare players
            DetermineWinner();
        }

        private void ClearConsole()
        {
            UserInterface.ClearConsole();
        }

        private void DisplayRules()
        {
            UserInterface.DisplayRules();
        }

        private void HowManyPlayers()
        {
            player = new List<Player>();
            howManyPlayers = UserInterface.HowManyPlayers("How many players ? (1 - 30)\n\n__", 1, 20);
            for (int i = 0; i < howManyPlayers; i++)
            {
                player.Add(new Player());
            }
            Console.Clear();
        }

        private void ChooseDuration()
        {
            howManyDays = UserInterface.ChooseDuration("How many days would you like the game to run?  (7-100)\n\n__", 7, 30);
        }

        private void GenerateListOfDays()
        {
            int dayCounterForWeather = 0;
            
            days = new List<Day>();
            string city = UserInterface.ChooseWhereToOpenStand("Type in a city to open your stand\n\n__");
            for (int i = 0; i < howManyDays; i++)
            {
                days.Add(new Day(random, city, dayCounterForWeather));
                dayCounterForWeather++;
            }
            currentDay = 0;
        }

        private void DisplayWeatherInformation()
        {
            if (currentDay > 5)
            {
                UserInterface.DisplayWeatherInformation(days[currentDay].weather.condition, days[currentDay].weather.temperature);
            }
            else
            {
                UserInterface.DisplayRealWeatherInformation(days[currentDay].weatherReal.City, days[currentDay].weatherReal.Condition, days[currentDay].weatherReal.Temperature, days[currentDay].weatherReal.HighTemperature, days[currentDay].weatherReal.Precipitation);
            }
        }

        private void DisplayInventory()
        {
            //Another SOLID principle... each of the methods will have a for loop
            //that allows for extension of the number of players without modifying the code
            for (int i = 0; i < howManyPlayers; i++)
            {
                UserInterface.DisplayInventory(i + 1, player[i].inventory.lemons.Count, player[i].inventory.sugarCubes.Count, player[i].inventory.iceCubes.Count, player[i].inventory.cups.Count, player[i].wallet.Money);
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
                Console.WriteLine($"\nPlayer {i + 1}, it's time to stock your inventory...\n\nYour recipe calls for: {player[i].recipe.amountOfLemons}\n\nCurrent value: {player[i].inventory.lemons.Count}\n\nWallet: {player[i].wallet.Money}\n\nPrice per lemon: {store.pricePerLemon}\n");
                store.SellLemons(player[i]);
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to stock your inventory...\n\nYour recipe calls for: {player[i].recipe.amountOfSugarCubes}\n\nCurrent value: {player[i].inventory.sugarCubes.Count}\n\nWallet: {player[i].wallet.Money}\n\nPrice per sugar cube: {store.pricePerSugarCube}\n");
                store.SellSugarCubes(player[i]);
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to stock your inventory...\n\nYour recipe calls for: {player[i].recipe.amountOfIceCubes}\n\nCurrent value: {player[i].inventory.iceCubes.Count}\n\nWallet: {player[i].wallet.Money}\n\nPrice per ice cube: {store.pricePerIceCube}\n");
                store.SellIceCubes(player[i]);
                Console.Clear();
                Console.WriteLine($"\nPlayer {i + 1}, it's time to stock your inventory...\n\nCurrent value: {player[i].inventory.cups.Count}\n\nWallet:{player[i].wallet.Money}\n\nPrice per cup: {store.pricePerCup}\n");
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
                if (currentDay <=5)
                {
                    Console.WriteLine($"Todays forecast: Day {currentDay+1} | {days[currentDay].weatherReal.Condition} | {days[currentDay].weatherReal.HighTemperature}");
                }
                else
                {
                    Console.WriteLine($"Todays forecast:  Day {currentDay + 1} | {days[currentDay].weather.condition} | {days[currentDay].weather.temperature}\n");
                }                
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
            //I set userInput to -1 so the while loop continues if the user enters a letter since 0 is a valid input
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
                player[i].maxPitchers = maxPitchers;
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
            //set the pitchersBefore variable to the count of the list
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
                    if (player[i].listOfPitchers.Count < 1 || player[i].inventory.cups.Count < 1)
                    {
                        continue;
                    }
                    if (
                        (days[currentDay].customers[j].buyingPower > player[i].recipe.pricePerCup) &&
                        (days[currentDay].customers[j].likesHowMuchIce - player[i].recipe.amountOfIceCubes < random.Next(1,4) || days[currentDay].customers[j].likesHowMuchIce - player[i].recipe.amountOfIceCubes > random.Next(-1,-4)) &&
                        (days[currentDay].customers[j].likesHowMuchLemon - player[i].recipe.amountOfLemons < random.Next(1,4) || days[currentDay].customers[j].likesHowMuchLemon - player[i].recipe.amountOfLemons > random.Next(-1,-4)) &&
                        (days[currentDay].customers[j].likesHowMuchSugar - player[i].recipe.amountOfSugarCubes < random.Next(1,4) || days[currentDay].customers[j].likesHowMuchSugar - player[i].recipe.amountOfSugarCubes > random.Next(-1, -4)))
                    {
                        player[i].listOfPitchers[0].PourACup();
                        player[i].cupsSoldCounter++;
                        player[i].inventory.cups.RemoveAt(0);
                        Console.WriteLine($"{days[currentDay].customers[j].name} purchased a cup of lemonade!");
                        if(player[i].listOfPitchers[0].cupsLeftInPitcher<1)
                        {
                            player[i].listOfPitchers.RemoveAt(0);
                        }
                    }
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
                    //considers the possiblity of selling a partial pitcher
                    pitchersUsed = (player[i].cupsSoldCounter / 8) + 1;
                    //handles the exception that would arise from selling out
                    if (pitchersUsed > player[i].maxPitchers)
                    {
                        pitchersUsed = player[i].maxPitchers;
                    }
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
        private void PourOutUnsoldLemonade()
        {
            for (int i = 0; i < howManyPlayers; i++)
            {
                if(player[i].listOfPitchers.Count<1)
                {
                    break;
                }
                else
                {
                    for (int j = 0; j < player[i].listOfPitchers.Count; j++)
                    {
                        player[i].listOfPitchers.RemoveAt(0);
                    }
                }
            }
        }
        private void DetermineWinner()
        {
            int winner = 0;

            for (int i = 0; i < howManyPlayers; i++)
            {
                for (int j = 0; j < howManyPlayers; j++)
                {
                    if (player[i].wallet.Money < player[j].wallet.Money)
                    {
                        i = j;
                    }
                    else
                    {
                        winner = i;
                    }                    
                }                
            }
            Console.WriteLine($"The winner is Player {winner+1}!");
        }
    }
}
