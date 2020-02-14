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
        public Day()
        {
            weather = new Weather();   
        }

        private void addDailyCustomers() 
        {
            dailyCustomers.Add(new Customer {name="Paul", })
        }
    }
}
