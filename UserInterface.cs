using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static void DisplayForecast(List<Day> week) 
        {
            Console.Clear();
            Console.Title = "This Weeks Forecast";
            foreach (Day day in week) 
            {
                Console.Write($"{day.name} |");
            }
            Console.WriteLine(" ");
            foreach (Day day in week) 
            {
                Console.Write($"{day.weather.condition} |");
            }
            Console.WriteLine(" ");
            foreach (Day day in week) 
            {
                Console.Write($"{day.weather.temperature} |");
            }
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
                    Console.ReadLine();
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
            Console.Title = "Lemonade Tycoon";
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
        public static void DisplayMainMenu(Player player) 
        {
            Console.Clear();
            Console.Beep();
            Console.Title = $"Smart, sexy, future Lemonade Tycoon :{player.name}'s - Main Menu";
            Console.WriteLine("1. See List of Lemonade Stands");
            Console.WriteLine("2. See the Forecast");
            Console.WriteLine("3. Proffit and Loss Analysis");
            Console.WriteLine("4. Check Bank Account");
            Console.WriteLine("5. Open a new Location");
            Console.WriteLine("6. Recipe Book");
            Console.WriteLine("7. Change Your Name");
            Console.WriteLine("8. End Game");
            if (player.canIAdvertise == true) 
            {
                Console.WriteLine("M. Start a marketing campaign");
            }

        }
        public static void DisplaySupplimentalMenu(Player player) 
        {
            Console.WriteLine(" ");
            Console.Write("s - Store | d - Start Day | e - Environmental Rules");
            if (player.canIAdvertise == true) { Console.Write(" | M - Launch a Marketing Campaign"); }
            Console.WriteLine(" ");
        }

        public static bool ValidateMainMenuInput(string userinput, int minChoice, int maxChoice, Player player, out string validatedUserInput) 
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
                    case "M":
                        if (player.canIAdvertise == true) {/*DISPLAY MARKETING MENU AND VALIDATE INPUT*/ }
                        else { Console.WriteLine("You Dont have access to marketing features yet"); validated = false; }
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
        public static int DecideWhatToDisplayFromMainMenu(string userinput, Player player, List<Day> week) 
        {
            int user = 0;
            if (userinput == "1") {user = Convert.ToInt32(userinput); }//See stnds
            else if (userinput == "2") { user = Convert.ToInt32(userinput); }//See Forecast
            else if (userinput == "3") { user = Convert.ToInt32(userinput); }//PNL
            else if (userinput == "4") { user = Convert.ToInt32(userinput); }//Bank Balance
            else if (userinput == "5") { user = Convert.ToInt32(userinput); }//Open New Location
            else if (userinput == "6") { user = Convert.ToInt32(userinput); }//Recipe Creation
            else if (userinput == "7") { user = Convert.ToInt32(userinput); }//Change Player Name
            else if (userinput == "8") { user = Convert.ToInt32(userinput); }//End Game
            else if (userinput == "M") { user = 50; }//Marketing Menu
            else if (userinput == "s") { user = 51; }//Access the Store
            else if (userinput == "d") { user = 52; }//Start a new Day
            else if (userinput == "e") { user = 53; }//Possible Events in Game

            return user;
        }
        public static bool GenericValidationTool(string userin, int minChoice, int maxChoice, out int validatedoutput) 
        {
            bool hasvalidated = false;
            validatedoutput = 0;
            try { validatedoutput = Convert.ToInt32(userin); }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter a value on the screen");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please Enter A Positive Integer");
            }
            if ((hasvalidated != true) && ((validatedoutput < minChoice) || (validatedoutput > maxChoice)))
            {
                Console.WriteLine("Please Enter A Choice within the range of options");
            }
            else { hasvalidated = true;}

            return hasvalidated;
        }
        public static int StoreMenu() 
        {
            int playerchoice = 0;
            bool val = false;
            Console.Clear();
            Console.Title = "Store Main Menu";

            Console.WriteLine("Hello There! Welcome to the General Store");
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine(" ");
            Console.WriteLine("1. Pitchers");
            Console.WriteLine("2. Lemons");
            Console.WriteLine("3. Sugar Cubes");
            Console.WriteLine("4. Cups");
            Console.WriteLine("5. Ice");

            while ((!val) && (playerchoice == 0)) 
            {
                val = GenericValidationTool(Console.ReadLine(), 1, 5, out playerchoice);
            }

            return playerchoice;

        }
        public static int GetAndSendLemonadeStand(string userchoice, Player player) 
        {
            bool hasvalidated = false;
            int indexOfStore = -1;
            while ((!hasvalidated) && (indexOfStore == -1)) 
            {
                hasvalidated = GenericValidationTool(userchoice, 0, player.myFranchiseofStands.Count, out indexOfStore);
                userchoice = Console.ReadLine();
            }
            return indexOfStore;
        }
        public static string DisplayPlayerLemonadeStands(Player player) 
        {

            Console.Clear();
            Console.Beep();
            Console.Title = "Your Lemonade Franchise";
            int counter = 0;
            foreach (LemmonadeStand stand in player.myFranchiseofStands)
            {
                Console.WriteLine($"{counter}.{stand.standname}");
                counter++;
            }
            string userin = Console.ReadLine();
            return userin;
        }
        public static int DisplayStandSpecificMenu(Player player, int iOFLemonadeStand) 
        {
            int playerchoice = 0;
            bool val = false;
            Console.Clear();
            Console.Title = $"Menu For {player.myFranchiseofStands[iOFLemonadeStand].standname}";
            Console.WriteLine("1. Change Stand Name");
            Console.WriteLine("2. Buy Inventory for this Stand");
            Console.WriteLine("3. Transfer Inventory FROM this stand to a DIFFERENT stand");
            Console.WriteLine("4. Check Inventory Levels of This Stand");
            Console.WriteLine("5. Add A Pitcher of Lemonade");
            Console.WriteLine("6. Edit A Pitcher ");
            Console.WriteLine("6. Close this stand");

            while (!val) 
            {
                val = GenericValidationTool(Console.ReadLine(), 1, 6, out playerchoice);
            }

            return playerchoice;
        }
        public static void DisplayStandInventoryLevels(LemmonadeStand Stand) 
        {
            Console.WriteLine("Cups | Lemons | Ice Cubes | Sugar Cubes | Pitchers");
            Console.WriteLine($"{Stand.inventoryOfthisStand.cups.Count} | {Stand.inventoryOfthisStand.lemons.Count} | " +
                $"{Stand.inventoryOfthisStand.iceCubes.Count} | {Stand.inventoryOfthisStand.sugarCubes.Count} | {Stand.listOfPitchers.Count}");
        }
        
        public static void RecipeCreationMenu(Player player) 
        {
            Console.Clear();
            Console.Title = $"{player.name}'s Recipe Book";
            Console.WriteLine("1. Create A Recipe");
            Console.WriteLine("2. Delete A Recipe");
            Console.WriteLine("3. Modify A Recipe");
        }
        public static void RecipeBookAction() { }
    }
}
