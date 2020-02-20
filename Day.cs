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
        private List<Day> week;
        public Day(Random random, List<Day> week)
        {
            this.week = week;
            weather = new Weather(random);
            dailyCustomers = new List<Customer>();
            addDailyCustomers(random);
            SetID();
        }

        private void addDailyCustomers(Random random) 
        {
            int chanceOfCustomerSpawn;
            if ((weather.temperature > 60) && (weather.temperature < 80)) 
            {
                chanceOfCustomerSpawn = random.Next(10, 20);
                for (int i = 0; i <chanceOfCustomerSpawn ; i++)
                {
                    dailyCustomers.Add(new Customer(random, week));
                }
            }
            else if ((weather.temperature > 79) && (weather.temperature < 90))
            {
                chanceOfCustomerSpawn = random.Next(15, 30);
                for (int i = 0; i < chanceOfCustomerSpawn; i++)
                {
                    dailyCustomers.Add(new Customer(random, this.week));
                }
            }
            else if ((weather.temperature > 89))
            {
                chanceOfCustomerSpawn = random.Next(25, 40);
                for (int i = 0; i < chanceOfCustomerSpawn; i++)
                {
                    dailyCustomers.Add(new Customer(random, this.week));
                }
            }
            else if ((weather.temperature > 10) && (weather.temperature < 61))
            {
                chanceOfCustomerSpawn = random.Next(2, 10);
                for (int i = 0; i < chanceOfCustomerSpawn; i++)
                {
                    dailyCustomers.Add(new Customer(random, this.week));
                }
            }
            else if (weather.temperature < 11)
            {
                chanceOfCustomerSpawn = random.Next(0, 2);
                for (int i = 0; i < chanceOfCustomerSpawn; i++)
                {
                    dailyCustomers.Add(new Customer(random, this.week));
                }
            }
        }
        private void SetID() 
        {
            if ((dailyCustomers.Count >= 10) && (dailyCustomers.Count <20) ) { this.ID = 2; } //Moderate Day
            else if ((dailyCustomers.Count >= 20) && (dailyCustomers.Count < 30)) { this.ID = 3; } //Good Day
            else if ((dailyCustomers.Count >= 30) && (dailyCustomers.Count < 41)) { this.ID = 4; }//GREAT DAY
            else if ((dailyCustomers.Count >= 2) && (dailyCustomers.Count > 10)) { this.ID = 1; }//BAD DAY
            else if ((dailyCustomers.Count >= 0) && (dailyCustomers.Count < 2)) { this.ID = 0; }//AWFUL DAY
        }
    }
}
