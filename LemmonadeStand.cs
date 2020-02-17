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
            inventoryOfthisStand = new Inventory();
        }
        public void addToMyListOfPitchers(string pitcherName, Recipe recipeThePitcherWillHold, int SizeOfPitcherInCups) 
        {

            listOfPitchers.Add(new Pitcher { PitcherName = pitcherName, theRecepieIContain = recipeThePitcherWillHold, cupsLeftInPitcher = SizeOfPitcherInCups});
        }
        public void SendInventorytoAdifferentLocation(LemmonadeStand givingLocation, LemmonadeStand receivingLocation, List<Item> listOfItemsToBeSubbedFrom, int AmountToBeSubbed) 
        {
            //Call to the method in th invetory of the location that is giving the items to check if they can give the amount specified,if not aknowledge and then repromp if yes adjust levels of the
            //lists accordingly. 
            bool cantheyDothis = false;
            while (!cantheyDothis) 
            {
                break;
            }
        }
        
        //Should have 0 refrences until customers start buying
        public double getTotalItemizedProffit(double ItemCost, int QuantityofItemBought, double TotalSales, int numBerOfDaysSinceGameStarted)
        {
            double proffit = 0;

            proffit = TotalSales - (ItemCost * QuantityofItemBought); // get proffit of item as a group
            proffit = (proffit / QuantityofItemBought); // get proffit off each inv item.

            return proffit;

        }
        
    }
}
