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
        
        public int HowManyLemons()
        {
            int userInput = UserInterface.GetIntUserInput("How many lemons should your pitcher contain ? (1 - 10)\n\n__", 1, 10);
            amountOfLemons = userInput;
            return userInput;
        }
        public int HowManySugars()
        {
            int userInput = UserInterface.GetIntUserInput("How many sugar cubes should your pitcher contain ? (1 - 10)\n\n__",1,10);
            amountOfSugarCubes = userInput;
            return userInput;
        }
        public int HowManyIceCubes()
        {
            int userInput = UserInterface.GetIntUserInput("How many ice cubes should your pitcher contain?  (1-10)\n\n__",1,10);
            amountOfIceCubes = userInput;
            return userInput;
        }
        public double HowMuchPerCup()
        {
            double userInput = UserInterface.GetDoubleUserInput("How much would you like to charge per cup? (0.05-5.00)\n\n__",.05,5);
            pricePerCup = userInput;
            return userInput;
        }
    }
}
