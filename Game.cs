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
            random = new Random();
            week = new List<Day>();
            AddWeekDays();
        }
        private void Start() 
        {
            FlushValues();
            SetDifficulty();
            setPlayerName();
            AddFirstPlayerStore();
            SetStoreName(0);
        }

        private void DecideWhatGameToLaunch() 
        {
            if (GameDifficulty == 1) { }//RunEasy
            else if (GameDifficulty == 2) { }//RunMed
            else if (GameDifficulty == 3) { }//RunHard
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
            player.AddToMyFranchises();
        }
    }
}
