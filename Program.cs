﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            UserInterface.DisplayWeekInformation(game.week);
            Console.Read();
        }
    }
}
