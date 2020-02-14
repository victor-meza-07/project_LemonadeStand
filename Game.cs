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
        List<Day> week;//formally known as days
        int currentDay;
        Random random;
        public Game()
        {
            random = new Random();
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
            week.Add(new Day(random) { name = "Monday", ID = 0});
            week.Add(new Day(random) { name = "Tuesday", ID = 1 });
            week.Add(new Day(random) { name = "Wednesday", ID = 2 });
            week.Add(new Day(random) { name = "Thursday", ID = 3 });
            week.Add(new Day(random) { name = "Friday", ID = 4 });
            week.Add(new Day(random) { name = "Saturday", ID = 5 });
            week.Add(new Day(random) { name = "Sunday", ID = 6 });
        }
    }
}
