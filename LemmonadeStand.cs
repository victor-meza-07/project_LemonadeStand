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
        public Inventory inventoryOfthisStand;

        public LemmonadeStand()
        {
            listOfPitchers = new List<Pitcher>();
            inventoryOfthisStand = new Inventory();
        }
        public void addToMyListOfPitchers(string pitcherName, Recipe recipeThePitcherWillHold, int SizeOfPitcherInCups) 
        {

            listOfPitchers.Add(new Pitcher { PitcherName = pitcherName, theRecepieIContain = recipeThePitcherWillHold, cupsLeftInPitcher = SizeOfPitcherInCups});
        }
        public void SendInventorytoAdifferentLocation(LemmonadeStand receivingLocation, Item itemtype, int itemcount) 
        {
            
        }

    }
}
