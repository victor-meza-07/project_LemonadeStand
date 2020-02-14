using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class LemmonadeStand
    {
        public string standname { get; set; }
        public List<Pitcher> listOfPitchers;
        public LemmonadeStand()
        {
            listOfPitchers = new List<Pitcher>();
        }
        public void addToMyListOfPitchers(string pitcherName, Recipe recipeThePitcherWillHold, int SizeOfPitcherInCups) 
        {

            listOfPitchers.Add(new Pitcher { PitcherName = pitcherName, theRecepieIContain = recipeThePitcherWillHold, cupsLeftInPitcher = SizeOfPitcherInCups});
        }

    }
}
