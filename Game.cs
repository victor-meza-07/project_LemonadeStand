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
        public Game()
        {
            
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
            week.Add(new Day { name = "Monday", ID = 0});
            week.Add(new Day { name = "Tuesday", ID = 1 });
            week.Add(new Day { name = "Wednesday", ID = 2 });
            week.Add(new Day { name = "Thursday", ID = 3 });
            week.Add(new Day { name = "Friday", ID = 4 });
            week.Add(new Day { name = "Saturday", ID = 5 });
            week.Add(new Day { name = "Sunday", ID = 6 });
        }
    }
}
