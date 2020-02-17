using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Pitcher : Item
    {
        public int cupsLeftInPitcher { get; set; }
        public string PitcherName { get; set; }
        public Recipe theRecepieIContain { get; set; }
        public int CapacityofPitcherInCups { get; set; }
        public Pitcher()
        {
            name = "Pitcher";
            CapacityofPitcherInCups = 32;
        }
    }
}
