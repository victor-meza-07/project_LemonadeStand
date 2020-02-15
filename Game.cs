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
        public Game()
        {
            player = new Player();
            random = new Random();
            week = new List<Day>();
            AddWeekDays();
        }
        public void Start() 
        {
            FlushValues();
            UserInterface.DisplayIntro();
            SetDifficulty();
            setPlayerName();
            MainLoop();
        }



        private void MainLoop() 
        {
            AddFirstPlayerStore();
            SetStoreName(0);
            UserInterface.DisplayMainMenu(player);
            UserInterface.DisplaySupplimentalMenu(player);
            string checker;
            UserInterface.ValidateMainMenuInput(CollectUserInput(), 1, 5, player, out checker);
            UserInterface.DecideWhatToDisplayFromMainMenu(checker, player);
            Console.Read();
        }
        private void MediumLogic() 
        {
            
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
    }
}
