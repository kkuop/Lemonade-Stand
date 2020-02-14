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
        int cupsLeftInPitcher;
        //constructor
        public Pitcher()
        {
            cupsLeftInPitcher = 12;
        }
        //member methods
        public void PourACup()
        {
            cupsLeftInPitcher -= 1;
        }
    }
}
