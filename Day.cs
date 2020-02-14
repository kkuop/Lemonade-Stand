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
            customers = DetermineNumberOfCustomers();
        }
        //member methods
        private List<Customer> DetermineNumberOfCustomers ()
        {
            int randomIntegerForGoodConditions = new Random().Next(30, 50);
            int randomIntegerForMediumConditions = new Random().Next(10, 35);
            int randomIntegerForBadConditions = new Random().Next(0, 15);
            if(weather.condition == "Hot and Dry")
            {
                customers = new List<Customer>();
                for (int i = 0; i < randomIntegerForGoodConditions; i++)
                {
                    customers.Add(new Customer());
                }
                return customers;
            }
            else if (weather.condition == "Mostly Sunny" )
            {
                customers = new List<Customer>();
                for (int i = 0; i < randomIntegerForMediumConditions; i++)
                {
                    customers.Add(new Customer());
                }
                return customers;
            }
            else
            {
                customers = new List<Customer>();
                for (int i = 0; i < randomIntegerForBadConditions; i++)
                {
                    customers.Add(new Customer());
                }
                return customers;
            }
        }
    }
}
