using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {
        public static int GetNumberOfItems(Item itemToPurchase)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;
            string itemsToGet = itemToPurchase.name;

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
                    Console.WriteLine($"{storename} is a pretty good name for a lemonade stand");
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
        
        public static void DisplayIntro() 
        {
            Console.WriteLine("Welcome to Lemmonade Stand Tycoon");
            Console.WriteLine("You will encounter simulated events in game that will affect inventory levels among other things");
            Console.WriteLine("You can Always access a list of possible events in your menu.");
            Console.WriteLine("Remeber to Have fun!");
        }
        public static void DisplayMainMenu() 
        {
            Console.WriteLine("1. See List of Lemonade Stands");
            Console.WriteLine("2. See the Forecast");
            Console.WriteLine("3. Proffit and Loss Analysis");
            Console.WriteLine("4. Check Bank Account");
            Console.WriteLine("5. Open a new Location");
            Console.WriteLine("6. Start a marketing campaign");

        }
        public static void DisplaySupplimentalMenu() 
        {
            Console.Write("s - Store | d - Start Day");
            Console.WriteLine(" ");
        }

        public static bool ValidateMainMenuInput(string userinput, int minChoice, int maxChoice, out string validatedUserInput) 
        {
            bool validated = false;
            int userChoice = 0;
            validatedUserInput = "";
            try { userChoice = Convert.ToInt32(userinput); }
            catch (FormatException) 
            {
                switch (userinput) 
                {
                    case "s":
                        validatedUserInput = userinput;
                        validated = true; 
                        break;
                    case "d":
                        validatedUserInput = userinput;
                        validated = true;
                        break;
                    case "e":
                        validatedUserInput = userinput;
                        validated = true;
                        break;
                    default:
                        Console.WriteLine("Please enter an option on screen");
                        validated = false;
                        break;
                } // checks for supplimental menu
            }
            catch (OverflowException) 
            {
                Console.WriteLine("Please Enter A Positive Integer");
            }
            if ((validated != true) && ((userChoice < minChoice) || (userChoice > maxChoice)))
            {
                Console.WriteLine("Please Enter A Choice within the range of options");
            }
            else { validated = true; validatedUserInput = userinput; }

            return validated;
        }
        public static void DecideWhatToDisplayFromMainMenu(string userinput) 
        {
            if (userinput == "1") { Console.WriteLine($"you chose {userinput}"); }
            else if (userinput == "2") { Console.WriteLine($"you chose {userinput}"); }
            else if (userinput == "3") { Console.WriteLine($"you chose {userinput}"); }
            else if (userinput == "4") { Console.WriteLine($"you chose {userinput}"); }
            else if (userinput == "5") { Console.WriteLine($"you chose {userinput}"); }
            else if (userinput == "s") { Console.WriteLine($"you chose {userinput}"); }//Access the Store
            else if (userinput == "d") { Console.WriteLine($"you chose {userinput}"); }//Start a new Day
            else if (userinput == "e") { Console.WriteLine($"you chose {userinput}"); }//Possible Events in Game
        }
    }
}
