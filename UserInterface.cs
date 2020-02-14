using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {
        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.WriteLine("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }

        public static void DisplayWeekInformation(List<Day> wekkdays) 
        {
            Console.WriteLine("HERE ARE THE WEEKDAYS");
            foreach (Day day in wekkdays) 
            {
                Console.WriteLine($"{day.name}: Customers->{day.dailyCustomers.Count} Temperature->{day.weather.temperature} Condition->{day.weather.condition}");
                Console.WriteLine("Customers");
                foreach (Customer customerinfo in day.dailyCustomers) 
                {
                    Console.WriteLine($"{customerinfo.name} : {customerinfo.SpendingPower}");
                }
            }
        }
    }
}
