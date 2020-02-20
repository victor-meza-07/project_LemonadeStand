using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        Player player;
        public List<Day> week;//formally known as days
        int currentDay;
        int GameDifficulty { get; set; }
        Random random;
        Store store;
        public Game()
        {
            player = new Player();
            random = new Random();
            week = new List<Day>();
            store = new Store();
        }
        public void Start() 
        {
            FlushValues();
            AddWeekDays();
            UserInterface.DisplayIntro();
            SetDifficulty();
            setPlayerName();
            MainLoop();
        }



        private void MainLoop() 
        {
            AddFirstPlayerStore();
            SetStoreName(0);

            //Loop Start this is the Main Gameplay Loop
            while (Convert.ToDouble(GetPlayerFranchiceCount()) > 0) 
            {
                UserInterface.DisplayMainMenu(player);
                UserInterface.DisplaySupplimentalMenu(player);
                string checker;
                UserInterface.ValidateMainMenuInput(CollectUserInput(), 1, 8, player, out checker);
                int userChoice;
                userChoice = UserInterface.DecideWhatToDisplayFromMainMenu(checker, player, week);
                DecideWhatInterfacetoSendTo(userChoice);

            }
            //Loop End
            Console.WriteLine("You ran out of stores to manage your career is over");

            Console.Read();
        }



        private void SetDifficulty() 
        {
            this.GameDifficulty = UserInterface.DisplayDifficultyPrompt();
        }
        private void SetStoreName(int LemonadeStandListLocation) 
        {
            player.myFranchiseofStands[LemonadeStandListLocation].standname = UserInterface.DisplayStoreNamePrompt();
        }
        private void setPlayerName() 
        {
            player = new Player();
            player.name = UserInterface.DisplayPlayerNamePrompt();
        }
        private void FlushValues() 
        {
            player.ClearMyValues();
            week.Clear();
            currentDay = 0;
        }
        private void AddWeekDays() 
        {
            week.Add(new Day(random, week) { name = "Monday"});
            week.Add(new Day(random, week) { name = "Tuesday"});
            week.Add(new Day(random, week) { name = "Wednesday"});
            week.Add(new Day(random, week) { name = "Thursday"});
            week.Add(new Day(random, week) { name = "Friday"});
            week.Add(new Day(random, week) { name = "Saturday"});
            week.Add(new Day(random, week) { name = "Sunday"});
        }
        private void AddFirstPlayerStore() 
        {
            AddPlayerStore();
        }
        private void AddPlayerStore() 
        {
            player.myFranchiseofStands.Add(new LemmonadeStand());
        }
        private string CollectUserInput() 
        {
            string userinput = Console.ReadLine();
            return userinput;
        }
        private void DecideWhatInterfacetoSendTo(int userchoice) 
        {
            
            if (userchoice == 1) 
            { 
                string playerchoice = UserInterface.DisplayPlayerLemonadeStands(player);
                LemonadeStandLogicSender(playerchoice);
            }//See stnds
            else if (userchoice == 2) { UserInterface.DisplayForecast(week); Console.Read(); }//See Forecast
            else if (userchoice == 3) { Console.WriteLine($"you chose {userchoice}"); }//PNL
            else if (userchoice == 4) { UserInterface.DisplayBankBalance(player); Console.Read(); }//Bank Balance
            else if (userchoice == 5) 
            {
                bool hasenough = false;
                while (!hasenough) 
                {
                    hasenough = CheckIfPlayerCanOpenNewLocation();
                    Console.Read();
                    break;
                }
            }//Open New Location
            else if (userchoice == 6) 
            {  
                int creationChoice = UserInterface.RecipeCreationMenu(player);

                Console.WriteLine("We need a stand from which to pull inventory from first");
                System.Threading.Thread.Sleep(1500);
                string userchoiceString = UserInterface.DisplayPlayerLemonadeStands(player);
                int IndexOfStand = UserInterface.GetAndSendLemonadeStand(userchoiceString, player);
                CreationLogic(creationChoice,IndexOfStand);
                
            }//Recipe Creation
            else if (userchoice == 7) { player.name = UserInterface.DisplayPlayerNamePrompt(); }//Change Player Name
            else if (userchoice == 8) { Environment.Exit(0); }//End Game
            else if (userchoice == 50) { Console.WriteLine($"you chose {userchoice}"); }//Supplimental - M
            else if (userchoice == 51) { ShoppingLogic(); }//Supplimental - s
            else if (userchoice == 52) { DayLogic(); }//Supplimental - d
            else if (userchoice == 53) { Console.WriteLine($"you chose {userchoice}"); }//Supplimental - e
        }
        private void LemonadeStandLogicSender(string subMenuChoice) 
        {
            int indexofStand = UserInterface.GetAndSendLemonadeStand(subMenuChoice, player);
            int actionRequested = UserInterface.DisplayStandSpecificMenu(player, indexofStand);


            if (actionRequested == 1) { chnageStandName(indexofStand); } // change stand name
            else if (actionRequested == 2) { buyStandInventory(indexofStand); }//buy inventory for this stand
            else if (actionRequested == 3) { }//transfer
            else if (actionRequested == 4) { UserInterface.DisplayStandInventoryLevels(player.myFranchiseofStands[indexofStand]); Console.ReadLine(); }//Check
            else if (actionRequested == 5) { UserInterface.DisplayListOfRecipes(player); }//add pitcher
            else if (actionRequested == 6) { }
            else if (actionRequested == 7) 
            { 
                int choice = UserInterface.CloseStandPormpt(player, indexofStand);
                if (choice == 1) { player.myFranchiseofStands.Remove(player.myFranchiseofStands[indexofStand]); }
            }//Remove A location

        }
        private void chnageStandName(int indexOfStand) 
        {
            string newName = UserInterface.DisplayStoreNamePrompt();
            player.myFranchiseofStands[indexOfStand].standname = newName;
        }
        private void buyStandInventory(int indexOfStand) 
        {
            int userchoice = 0;
            userchoice =  UserInterface.StoreMenu();
            store.GetWhatToSell(userchoice, player, indexOfStand);

        }
        private bool CheckIfPlayerCanOpenNewLocation() 
        {
            bool asEnoughMoney = false;
            if (player.wallet.Money > 1000)
            {
                asEnoughMoney = true;
            }
            else 
            {
                Console.WriteLine("You don't have sufficient funds to open a new location:");
                Console.WriteLine($"Your Funds: {player.wallet.Money}, Funds Required: 1001");
                asEnoughMoney = false; 
            }

            return asEnoughMoney;
        }
        private int GetPlayerFranchiceCount() 
        {
            int count;
            count = player.myFranchiseofStands.Count;
            return count;
        }
        private void CreationLogic(int creationchoice, int indexOfFranchiseWhereRecipeWillBe) 
        {
            if (creationchoice == 1) 
            {
                addARecipeTotheBook();
                int recipeIndex = player.myReceipeBook.Count - 1;
                EditARecipeInBook(recipeIndex, indexOfFranchiseWhereRecipeWillBe);
            }//create a recipe
            else if (creationchoice == 3) 
            {
                if (player.myReceipeBook.Count < 1)
                {
                    addARecipeTotheBook();
                    int recipeIndex = player.myReceipeBook.Count - 1;
                    EditARecipeInBook(recipeIndex, indexOfFranchiseWhereRecipeWillBe);
                }
                else 
                {
                    int indexOfRecipe = UserInterface.GetArecipeIndexFromPLayer(player);
                    EditARecipeInBook(indexOfRecipe, indexOfFranchiseWhereRecipeWillBe);
                }
                
            }//edit a recipe
            else if (creationchoice == 2) 
            {
                int indexOfRecipe = UserInterface.GetArecipeIndexFromPLayer(player);
                DeleteARecipeFromBook(indexOfRecipe);
            }//delete a recipe
        }
        private void addARecipeTotheBook() 
        {
            player.myReceipeBook.Add(new Recipe{ pricePerCup = 5.00});// hardcoded for now;
        }
        private void EditARecipeInBook(int indexOfRecipeToEdit, int indexOfFranchiseWhereRecipeWillBe)
        {

            int whatAreWeEditing = UserInterface.GetWhatToModifyFromRecipe();
            if (whatAreWeEditing == 1) 
            {
                int minLemons = 0 - player.myReceipeBook[indexOfRecipeToEdit].amountOfLemons;
                int maxLemons = player.myFranchiseofStands[indexOfFranchiseWhereRecipeWillBe].inventoryOfthisStand.lemons.Count;
                UserInterface.DisplayCurrentRecipe(player, indexOfRecipeToEdit);
                string userchocie = "";
                int changedLemonAmount = 0;
                bool val = false;
                while (!val) 
                {
                    userchocie = UserInterface.GetUnvalStringFromUser("If we are adding lemons please eneter the amount of lemons to add, \n if subtracting eneter that amount as a negative integer.");
                    val = UserInterface.GenericValidationTool(userchocie, minLemons, maxLemons, out changedLemonAmount);
                }

                player.myReceipeBook[indexOfRecipeToEdit].amountOfLemons = player.myReceipeBook[indexOfRecipeToEdit].amountOfLemons + changedLemonAmount;

            }//Lemon
            else if (whatAreWeEditing == 2) 
            {
                string chnagedItem = "Sugar Cubes";
                int minSugar = 0 - player.myReceipeBook[indexOfRecipeToEdit].amountOfSugarCubes;
                int maxSugar = player.myFranchiseofStands[indexOfFranchiseWhereRecipeWillBe].inventoryOfthisStand.sugarCubes.Count;
                UserInterface.DisplayCurrentRecipe(player, indexOfRecipeToEdit);
                string userchoice = "";
                int changedSugar = 0;
                bool val = false;
                while (!val) 
                {
                    userchoice = UserInterface.GetUnvalStringFromUser($"If we are adding {chnagedItem} please eneter the amount of {chnagedItem} to add, \n if subtracting eneter that amount as a negative integer.");
                    val = UserInterface.GenericValidationTool(userchoice, minSugar, maxSugar, out changedSugar);
                }

                player.myReceipeBook[indexOfRecipeToEdit].amountOfSugarCubes = player.myReceipeBook[indexOfRecipeToEdit].amountOfSugarCubes + changedSugar;
            }//Sugar
            else if (whatAreWeEditing == 3) 
            {
                string chnagedItem = "Water";
                int minAmount = Convert.ToInt32( 0 - player.myReceipeBook[indexOfRecipeToEdit].amountOfWater );
                UserInterface.DisplayCurrentRecipe(player, indexOfRecipeToEdit);
                string userchoice = "";
                int changedWater = 0;
                bool val = false;
                while (!val)
                {
                    userchoice = UserInterface.GetUnvalStringFromUser($"If we are adding {chnagedItem} please eneter the amount of {chnagedItem} to add, \n if subtracting eneter that amount as a negative integer.");
                    val = UserInterface.GenericValidationTool(userchoice, minAmount, 500, out changedWater);
                }

                player.myReceipeBook[indexOfRecipeToEdit].amountOfWater += changedWater;
            }//Water
            else if (whatAreWeEditing == 4) 
            {
                string chnagedItem = "Ice Cubes";
                int minAmount = Convert.ToInt32(0 - player.myReceipeBook[indexOfRecipeToEdit].amountOfWater);
                UserInterface.DisplayCurrentRecipe(player, indexOfRecipeToEdit);
                string userchoice = "";
                int changedItem = 0;
                bool val = false;
                while (!val)
                {
                    userchoice = UserInterface.GetUnvalStringFromUser($"If we are adding {chnagedItem} please eneter the amount of {chnagedItem} to add, \n if subtracting eneter that amount as a negative integer.");
                    val = UserInterface.GenericValidationTool(userchoice, minAmount, 500, out changedItem);
                }

                player.myReceipeBook[indexOfRecipeToEdit].amountOfIceCubes += changedItem;
            }//Ice
            else if (whatAreWeEditing == 5) 
            {
                player.myReceipeBook[indexOfRecipeToEdit].Name = UserInterface.GetUnvalStringFromUser("Please Enter A New Name For Your Recipe");
            }//Name


        }
        private void DeleteARecipeFromBook(int indexOfRecipe) 
        {
            player.myReceipeBook.Remove(player.myReceipeBook[indexOfRecipe]);
        }

        private void ShoppingLogic()
        {
            Console.WriteLine("Please Select Where you'd like yur purchases to be stored");
            System.Threading.Thread.Sleep(2500);
            string standChosen = UserInterface.DisplayPlayerLemonadeStands(player);
            bool val = false;
            int indexOfStand;
            indexOfStand = UserInterface.GetAndSendLemonadeStand(standChosen, player);
            int purchaseChoice = UserInterface.StoreMenu();
            store.GetWhatToSell(purchaseChoice, player, indexOfStand);

        }

        private void DayLogic() 
        {
            foreach (Customer customer in week[currentDay].dailyCustomers) 
            {
                foreach (Customer customer1 in week[currentDay].dailyCustomers) 
                {
                    customer1.SetProbabilityOfSpending(week[currentDay].weather.temperature, player.myReceipeBook[0]); // will hardcode for now
                }
                if (customer.ProbabilityOfPurchase > .60)
                {
                    Console.WriteLine($"{customer.name} purchased from you");
                    player.wallet.AddFromTodaysEarnings(5.00);
                }
                else { Console.WriteLine($"{customer.name} passed on your offer"); }
            }
            Console.ReadLine();
            currentDay++;
        }
    }
}
