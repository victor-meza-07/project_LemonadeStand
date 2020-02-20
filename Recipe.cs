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
        public double amountOfWater { get; set; }
        
        public double pricePerCup { get; set; }
        public double AcridLevels { get { return acridLevels; } }//Should only be Gotten never set;
        private double acridLevels;
        public double SweetnessLevels { get { return sweetnessLevels; } }
        private double sweetnessLevels;
        public double LemonadeContentLevels { get { return lemonadeContentLevels; } }
        private double lemonadeContentLevels;
        public double CoolingFactor { get { return coolingFactor; } }
        private double coolingFactor;

        public string Name { get; set; }

        public double CostPerCup;
        public Recipe()
        {
            amountOfLemons = 0;
            amountOfSugarCubes = 0;
            amountOfWater = 0;
            amountOfIceCubes = 0;
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
            this.amountOfWater = (waterInmLToAdd / 237); // takes ml converts to cups;
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
            if (!(amountOfWater > 0))
            {
                acridLevels = ((amountOfLemons * 14.7) * 1.44);
            }//Concentration of citric acid per 14.7ml of lemon juice
            else if (amountOfWater > 0)
            {
                acridLevels = (((amountOfLemons * 14.7) + amountOfWater) * 1.44);
            }//concentration of citric acid per lemmon juice ml + water ml * 1.44;
        }
        public void SetSugarLevels()
        {
            sweetnessLevels = amountOfSugarCubes * 4;
        }
        public void SetCoolingFactor(Day CurrentDay) 
        {
            //Rate of change of Temperature / 1hr = Temperature of Lemonade (Temperature of day (for the liquid) 
            //Q = mcT Q is rate of of change, m is mass of substance, c is the temperature required to change one kg by 1.0c and T is the change in Temp
            //Water has a density of 1kg / L or 1g/ml  
            double InitialtempInCelcius = ((CurrentDay.weather.temperature) - 32) * (5.0/9.0);
            // So First we calculate how much mass is in the pitcher (14.7ml of juice out of one lemon).
            double mlInPitcher = amountOfWater + (amountOfLemons * 14.7);
            //the mass of the ice in g
            double massOfIce = (amountOfIceCubes * 29.0);
            //The Calculation for final temperature is the following
            //Hf = 334J; (heat cap of water) = 4.184J/gc;//-Q2/(Q1mc + Q3mc) = DeltaInC
            double temperatureChangeinCelcius = (massOfIce * 334) / ((mlInPitcher * 4.184) + (massOfIce * 4.184));
            double finalTempinPitcher = InitialtempInCelcius - temperatureChangeinCelcius;
            //next we need to calculate how much cooling effect that water will have on a human
            double averageMassofHumaning = 8070;
            double CofHuman = 3.5;//3.5J/gc
            double averagecomfortableEnvironmentTempinC = 24.44;
            double abstemperatureDifferenceExperienced = Math.Abs(InitialtempInCelcius - averagecomfortableEnvironmentTempinC);
            double normalTempDiffExperienced = (InitialtempInCelcius - averagecomfortableEnvironmentTempinC);
            //actual cooling factor = Delta in c of current human temperature when the difference between outside temperature and lemonade is taken
            //something like
            // | Actual Temp - Comfortable Temp | = temp difference expirienced by human or goal to reach equilibrium;
            //
            //Calculating the ml to cool a human down to the level desired, then we have to divide one degree C by that result to achieve a FINAL cooling factor
            double mlOfLemonadeNeeded =  ((Math.Abs(averageMassofHumaning * CofHuman * normalTempDiffExperienced)) / (4.184 * normalTempDiffExperienced));
            double coolingFactorInc = normalTempDiffExperienced / mlOfLemonadeNeeded; // yields cooling factor of c/ml of lemonade;
            double coolingfactorInf = ((coolingFactorInc * (9.0 / 5.0)) + 32);//yields cooling factor in f/ml
            coolingFactor = coolingfactorInf * 237;//yields the cooling factor/cup in farenheit. 
        }
        public void SetLemonadeContentLevels() 
        {
            lemonadeContentLevels = ((amountOfLemons * 14.7) / 237) + amountOfWater; 
        }

        //Models
    }
}
