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
        Random random;
        //constructor
        public Day()
        {
            random = new Random();
            weather = new Weather();
            customers = DetermineNumberOfCustomers();
        }
        //member methods
        private List<Customer> DetermineNumberOfCustomers ()
        {
            int amountOfCustomers;
            customers = new List<Customer>();
            if (weather.condition == "Hot and Dry")
            {
                amountOfCustomers = random.Next(30, 50);
    
            }
            else if (weather.condition == "Mostly Sunny" )
            {
                amountOfCustomers = random.Next(10, 35);
            }
            else
            {
                amountOfCustomers = random.Next(0, 15);

            }
            for (int i = 0; i < amountOfCustomers; i++)
            {
                customers.Add(new Customer());
            }
            return customers;
        }
    }
}
