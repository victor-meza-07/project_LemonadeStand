using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Recipe
    {
        public int amountOfLemons { get; set; }
        public int amountOfSugarCubes { get; set; }
        public int amountOfIceCubes { get; set; }
        public int amountOfWater { get; set; }
        public double pricePerCup { get; set; }
        public double AcridLevels { get { return acridLevels; } }//Should only be Gotten never set;
        private double acridLevels;
        public double SweetnessLevels { get { return sweetnessLevels; } }
        private double sweetnessLevels;

        public double CoolingFactor { get { return coolingFactor; } }
        private double coolingFactor;
        
        public double CostPerCup;
        public Recipe()
        {

        }

        public void AddLemmonstoRecipe(int NumberOfLemonsToAdd) 
        {
            this.amountOfLemons = NumberOfLemonsToAdd;
        }
        public void AddSugarCubestoRecipe(int NumberofCubestoAdd) 
        {
            this.amountOfSugarCubes = NumberofCubestoAdd;
        }
        public void AddIceCubes(int NumberofIceCubesToAdd) 
        {
            this.amountOfIceCubes = NumberofIceCubesToAdd;
        }
        public void AddWatertoRecipe(int waterInmLToAdd) 
        {
            this.amountOfWater = waterInmLToAdd;
        }
        public void SetpricePerCup(double PriceSetPerCup) 
        {
            this.pricePerCup = PriceSetPerCup;
        }
        public void GetCostPerCup(double PricePerLemon, double PricePerSugarCube, double PricePerIceCube, int sizeOfPitcherInCups) 
        {
            this.CostPerCup = ((PricePerLemon * this.amountOfLemons) + (PricePerSugarCube * this.amountOfSugarCubes) + (PricePerIceCube * this.amountOfIceCubes)) / sizeOfPitcherInCups;
        }
        public void SetAcridityLevels() 
        {

            /*TODO
             * Double check your mathe here for the acridity levels it should be 1.44g/ml Lemmon Juice, which would drop if
             * acridity should drop if more grams of sugar are added. 
             
             */
            if ((amountOfLemons > 0) && !(amountOfWater > 0) && !(amountOfSugarCubes > 0))
            { acridLevels = ((amountOfLemons * 14.7) * 1.44); }//ONLY LEMON JUICE ADDED
            else if ((amountOfLemons > 0) && !(amountOfWater > 0) && (amountOfSugarCubes > 0)) 
            { acridLevels = (((amountOfLemons * 14.7) * 1.44)) - (amountOfSugarCubes * 4); }//Lemon J and Sugar Only
            else { }//ALL THREE ADDED
        }

        //Models
    }
}
