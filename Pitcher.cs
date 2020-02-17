using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher
    {
        //member vars
        public int cupsLeftInPitcher;
        public int cupsBefore;
        public int cupsSold;
        //constructor
        public Pitcher()
        {
            cupsLeftInPitcher = 0;
        }
        //member methods
        public void PourACup()
        {
            cupsLeftInPitcher -= 1;
        }
    }
}
