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
            
            double InitialtempInCelcius = (80 - 32) * (5 / 9);
            InitialtempInCelcius = (80 - 32) * (5.0 / 9.0);
            // So First we calculate how much mass is in the pitcher (14.7ml of juice out of one lemon).
            double mlInPitcher = 3600.0 + (0 * 14.7);
            //the mass of the ice in g
            double massOfIce = (30 * 29);
            //The Calculation for final temperature is the following
            //Hf = 334J; (heat cap of water) = 4.184J/gc;
            double temperatureChangeinCelcius = (massOfIce * 334) / ((mlInPitcher * 4.184) + (massOfIce * 4.184));
            double finalTempOfPitcher = InitialtempInCelcius - temperatureChangeinCelcius;
            Console.WriteLine($"{InitialtempInCelcius} {temperatureChangeinCelcius} {finalTempOfPitcher}");
            Console.ReadLine();
            Game game = new Game();
            game.Start();
        }
    }
}
