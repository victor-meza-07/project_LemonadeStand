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
            while (true) 
            {
                UserInterface.DisplayMainMenu(player);
                UserInterface.DisplaySupplimentalMenu(player);
                string checker;
                UserInterface.ValidateMainMenuInput(CollectUserInput(), 1, 5, player, out checker);
                int userChoice;
                userChoice = UserInterface.DecideWhatToDisplayFromMainMenu(checker, player, week);
                DecideWhatInterfacetoSendTo(userChoice);

            }
            //Loop End


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
            week.Add(new Day(random) { name = "Monday"});
            week.Add(new Day(random) { name = "Tuesday"});
            week.Add(new Day(random) { name = "Wednesday"});
            week.Add(new Day(random) { name = "Thursday"});
            week.Add(new Day(random) { name = "Friday"});
            week.Add(new Day(random) { name = "Saturday"});
            week.Add(new Day(random) { name = "Sunday"});
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
            else if (userchoice == 2) { UserInterface.DisplayForecast(week); }//See Forecast
            else if (userchoice == 3) { Console.WriteLine($"you chose {userchoice}"); }//PNL
            else if (userchoice == 4) { Console.WriteLine($"you chose {userchoice}"); }//Bank Balance
            else if (userchoice == 5) { Console.WriteLine($"you chose {userchoice}"); }//Open New Location
            else if (userchoice == 6) { UserInterface.RecipeBookAction(); }//Recipe Creation
            else if (userchoice == 7) { Console.WriteLine($"you chose {userchoice}"); }//Change Player Name
            else if (userchoice == 8) { Console.WriteLine($"you chose {userchoice}"); }//End Game
            else if (userchoice == 50) { Console.WriteLine($"you chose {userchoice}"); }//Supplimental - M
            else if (userchoice == 51) { Console.WriteLine($"you chose {userchoice}"); }//Supplimental - s
            else if (userchoice == 52) { Console.WriteLine($"you chose {userchoice}"); }//Supplimental - d
            else if (userchoice == 53) { Console.WriteLine($"you chose {userchoice}"); }//Supplimental - e
        }
        private void LemonadeStandLogicSender(string subMenuChoice) 
        {
            int indexofStand = UserInterface.GetAndSendLemonadeStand(subMenuChoice, player);
            int actionRequested = UserInterface.DisplayStandSpecificMenu(player, indexofStand);


            if (actionRequested == 1) { chnageStandName(indexofStand); } // change stand name
            else if (actionRequested == 2) { buyStandInventory(indexofStand); }//buy inventory for this stand
            else if (actionRequested == 3) { }//Transfer
            else if (actionRequested == 4) { UserInterface.DisplayStandInventoryLevels(player.myFranchiseofStands[indexofStand]); Console.ReadLine(); }//Check
            else if (actionRequested == 5) { }//transefer inventory
            else if (actionRequested == 6) { }//transefer inventory

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
    }
}
