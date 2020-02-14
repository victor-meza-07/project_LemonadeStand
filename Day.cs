using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        public Weather weather;
        public List<Customer> dailyCustomers; //Formally customers
        public string name;
        public int ID;
        public Day(Random random)
        {
            weather = new Weather();
            addDailyCustomers(random);
        }

        private void addDailyCustomers(Random random) 
        {
            if ((weather.temperature > 60) && (weather.temperature < 80)) 
            {
                int chanceOfCustomerSpawn = random.Next(10, 20);
                for (int i = 0; i <chanceOfCustomerSpawn ; i++)
                {
                    dailyCustomers.Add(new Customer(random));
                }
            }
            
        }
    }
}
