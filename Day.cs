using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        //member vars
        public Weather weather;
        public List<Customer> customers;
        //constructor
        public Day()
        {
            weather = new Weather();
            customers = new List<Customer>();
        }
        //member methods
    }
}
