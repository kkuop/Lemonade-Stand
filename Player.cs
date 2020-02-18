using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        //public Pitcher pitcher;
        public Recipe recipe;
        public List<Pitcher> listOfPitchers;
        public int pitchersBefore;
        public int cupsSoldCounter;

        // constructor (SPAWNER)
        public Player()
        {
            inventory = new Inventory();
            wallet = new Wallet();
            //pitcher = new Pitcher();
            recipe = new Recipe();
            listOfPitchers = new List<Pitcher>();
        }

        // member methods (CAN DO)
    }
}
