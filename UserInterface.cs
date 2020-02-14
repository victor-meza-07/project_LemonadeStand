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
        public static string DisplayPlayerNamePrompt() 
        {
            bool userInputwasValid = false;
            string playername = null;
            while (!userInputwasValid) 
            {
                Console.WriteLine("Please Enter A Name For Yourself");
                playername = Console.ReadLine();
                if ((playername != null) && (playername.Length != 0))
                {
                    Console.WriteLine($"Thanks {playername}");
                    userInputwasValid = true;
                }
                else 
                {
                    Console.WriteLine("No, Really; we need a name for you");
                }
            }
            return playername;
        }
        public static string DisplayStoreNamePrompt()
        {
            bool userInputwasValid = false;
            string storename = null;
            while (!userInputwasValid)
            {
                Console.WriteLine("Please Enter A Name For Your Store");
                storename = Console.ReadLine();
                if ((storename != null) && (storename.Length != 0))
                {
                    Console.WriteLine($"Thanks {storename}");
                    userInputwasValid = true;
                }
                else
                {
                    Console.WriteLine("No, Really; we need a name for your store");
                }
            }
            return storename;
        }
        public static int DisplayDifficultyPrompt() 
        {
            int difficulty = 0;
            bool validuserinput = false;
            while (!validuserinput)
            {
                Console.WriteLine($"Choose a difficulty!");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");
                validuserinput = Int32.TryParse( Console.ReadLine(), out difficulty);
                if ((difficulty < 1) || (difficulty > 3)) { validuserinput = false; Console.WriteLine("Seriously, type an int on the screen!"); }
            }
            return difficulty;
        }
    }
}
