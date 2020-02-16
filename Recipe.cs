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
        public double AcridLevels { get { } }//Should only be Gotten never set;
        public double SweetnessLevels { get { } }

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

        //Models
    }
}
