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
        Random random;
        public Game()
        {
            random = new Random();
            week = new List<Day>();
            AddWeekDays();
        }

        public void amethodthatdoesstuff() 
        {
            //DO THINGS!
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
    }
}
