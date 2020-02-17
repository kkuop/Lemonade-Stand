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
        List<Player> player;
        List<Day> days;
        int currentDay;
        Store store;
        //constructor

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
            ClearConsole();
            BuildRecipe();
            BuyIngredientsFromStore();
            while (currentDay < howManyDays)
            {
                ClearConsole();
                //Display menu
                DisplayMenu();
                ClearConsole();
                //Weather
                DisplayWeatherInformation();
                ClearConsole();
                //How many pitchers to make
                PrepareThePitcher();
                ClearConsole();
                //Open for business
                OpenForBusiness();
                //Display report
                DisplayReport();
                ClearConsole();
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
                Console.WriteLine("\nLet's build your recipe!");                
            }
            
        }

        private void GenerateListOfDays()
        {
            days = new List<Day>();
            for (int i = 0; i < howManyDays; i++)
            {
                days.Add(new Day());
            }
            currentDay = 0;
        }
        private void DisplayWeatherInformation()
        {
            Console.WriteLine($"Today's forecast is: {days[currentDay].weather.condition}\n\nThe high temperature will be: {days[currentDay].weather.temperature} ");
            
        }
        private void DisplayInventory()
        {
            for (int i = 0; i < howManyPlayers; i++)
            {
                Console.Clear();
            Console.WriteLine($"Player {i+1}, here is your current inventory...\n");
            Console.WriteLine($"Lemons: {player[i].inventory.lemons.Count}\nSugar Cubes: {player[i].inventory.iceCubes.Count}\nIce Cubes: {player[i].inventory.iceCubes.Count}\nCups: {player[i].inventory.cups.Count}\n\nWallet: {player[i].wallet.Money}");
                
            }
        }
        private void BuyIngredientsFromStore()
        {
            store = new Store();
            
            for (int i = 0; i < player.Count; i++)
            {
                Console.Clear();
                Console.WriteLine($"\nPlayer {i+1}, it's time to stock your inventory...");
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
                player[i].recipe.amountOfLemons = player[i].recipe.HowManyLemons();
                player[i].recipe.amountOfSugarCubes = player[i].recipe.HowManySugars();
                player[i].recipe.amountOfIceCubes = player[i].recipe.HowManyIceCubes();
                player[i].recipe.pricePerCup = player[i].recipe.HowMuchPerCup();
                 
            }
        }
        private void DisplayMenu()
        {
            Console.WriteLine("Please choose an option...\n\na)Change Recipe\nb)Buy Ingredients\nc)See Inventory\nd)Advance Day\n");
            ConsoleKeyInfo userInput = Console.ReadKey();
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
            else
            {
                Console.Clear();
            }
        }
        private void PrepareThePitcher()
        {
            int userInput = 0; 
            for (int i = 0; i < player.Count; i++)
            {
                if ((player[i].recipe.amountOfLemons > player[i].inventory.lemons.Count) || (player[i].recipe.amountOfSugarCubes > player[i].inventory.sugarCubes.Count) || (player[i].recipe.amountOfIceCubes > player[i].inventory.iceCubes.Count))
                {
                    Console.Clear();
                    Console.WriteLine($"Player {i+1}, you do not have enough supply to make the pitcher of lemonade!\n\nYou will sell 0 cups of lemonade this round.");
                    ClearConsole();
                    continue;
                }
                Console.Write($"Player {i+1}, how many cups of lemonade would you like to make? You have {player[i].inventory.cups.Count} available...\n__");
                do
                {
                    try
                    {
                        userInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("That is not valid input... try again!");
                    }
                } while (userInput == 0);


                player[i].pitcher.cupsLeftInPitcher = userInput;
            }
        }
        private void OpenForBusiness()
        
        {
            //make two vars to track count of pitchers before and after
            for (int i = 0; i < howManyPlayers; i++)
            {
                player[i].pitcher.cupsBefore = player[i].pitcher.cupsLeftInPitcher;
            }
            for (int i = 0; i < howManyPlayers; i++)
            {
                for (int j = 0; j < days[currentDay].customers.Count; j++)
                {
                    if (player[i].pitcher.cupsLeftInPitcher < 1)
                    {
                        continue;
                    }
                    if (days[currentDay].customers[j].buyingPower>player[currentDay].recipe.pricePerCup)
                    {
                        player[i].pitcher.PourACup();
                        Console.WriteLine($"{days[currentDay].customers[j].name} purchased a cup of lemonade!");
                    }
                    
                }
            }
            //when for loop is done, update the pitchersAfter var to reflect how much was sold
            for (int i = 0; i < howManyPlayers; i++)
            {
                player[i].pitcher.cupsSold = player[i].pitcher.cupsBefore - player[i].pitcher.cupsLeftInPitcher;
            }
        }
        private void DisplayReport()
        {
            for (int i = 0; i < howManyPlayers; i++)
            {
                Console.Write($"Player {i+1}, you sold {player[i].pitcher.cupsSold} cups of lemonade!\n\nHere is your updated inventory...\nLemons: {player[i].inventory.lemons.Count}\nSugar Cubes: {player[i].inventory.sugarCubes.Count}\nIce Cubes: {player[i].inventory.iceCubes.Count}\nCups: {player[i].inventory.cups.Count}\n\nWallet: {player[i].wallet.Money}");
                
            }
        }
    }
}
