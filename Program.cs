using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LemonadeStand_3DayStarter
{
    class Program
    {
        /*
         * TODO:
         * Wire all the main menu options to the respective finished parts and propper displays
         * Write any game logic to take into account difficulty levels when spawning.
         * Cry
         */
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
