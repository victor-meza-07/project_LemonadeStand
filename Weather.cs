using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        private int conditionID {get;set;}
        public string condition { get; set; }
        public int temperature { get; set; }
        List<WeatheCondition> weatherConditions;
        Random random;
        public Weather(Random random)
        {
            this.random = random;
            weatherConditions = new List<WeatheCondition>();
            AddWeatherConditions();
            SetWeatherCondition();
            SetTemparature();
            
        }
        private void AddWeatherConditions() 
        {
            weatherConditions.Add(new WeatheCondition { ConditionTyppe = "Sunny", Id = 0}); //Combined Weight of 6
            weatherConditions.Add(new WeatheCondition { ConditionTyppe = "Oven Mockingly Hot", Id = 1 });//Combined Weight of 6
            weatherConditions.Add(new WeatheCondition { ConditionTyppe = "Sauna", Id = 2 });//Combined Weight of 6
            weatherConditions.Add(new WeatheCondition { ConditionTyppe = "Overcast", Id = 3 });//Combined Weight of 3
            weatherConditions.Add(new WeatheCondition { ConditionTyppe = "Brisker than Expected", Id = 4 });//Combined Weight of 3
            weatherConditions.Add(new WeatheCondition { ConditionTyppe = "I think I see some green coming from the trees again", Id = 5 });//Combined Weight of 3
            weatherConditions.Add(new WeatheCondition { ConditionTyppe = "Colder than that Refrigeration contraption you've been braggin' 'bout", Id = 6 });//Combined Weight of 1
            weatherConditions.Add(new WeatheCondition { ConditionTyppe = "THE NATIONAL WEATHER SERVICE HAS ISSUED A COLD WEATHER WARNING FOR YOUR AREA; TEMPERATURES OF -50 DEGREES ARE EXPECTED", Id = 7 });//Combined Weight of 1
            weatherConditions.Add(new WeatheCondition { ConditionTyppe = "Idk the groundhog said we'd only be having these days for a little while longer", Id = 8 });//Combined Weight of 1
            
        }
        private void SetWeatherCondition() 
        {
            int IntialWeightDistribution = random.Next(0, 10000);
            int ChosenWeatherType = 0;
            if ((IntialWeightDistribution < 2000) && (IntialWeightDistribution < 6000))
            {
                ChosenWeatherType = random.Next(0, 2);
            }
            else if ((IntialWeightDistribution >= 6000) && (IntialWeightDistribution < 9000))
            {
                ChosenWeatherType = random.Next(3, 5);
            }
            else if ((IntialWeightDistribution >= 9000) && (IntialWeightDistribution <= 10000)) 
            {
                ChosenWeatherType = random.Next(6, 8);
            }

            condition = weatherConditions[ChosenWeatherType].ConditionTyppe;
            conditionID = weatherConditions[ChosenWeatherType].Id;
        }
        private void SetTemparature() 
        {
            int temperature = 0;
            if ((conditionID >= 0) && (conditionID <= 2))
            {
                temperature = random.Next(74, 110);
            }
            else if ((conditionID >= 3) && (conditionID <= 5))
            {
                temperature = random.Next(50, 74);
            }
            else if ((conditionID == 6) || (conditionID == 8))
            {
                temperature = random.Next(32, 50);
            }
            if (conditionID == 7) 
            {
                temperature = random.Next(-50, 10);
            }

            this.temperature = temperature;
        }
    }
}
