using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{

    class Customer
    {
        List<string> names;
        public int SpendingPower { get { return spendingPower; } }
        private int spendingPower;
        public string name { get { return Name; } } // formally a property
        private string Name;
        public double ProbabilityOfPurchase { get { return probabilityOfPurchase; } }
        private double probabilityOfPurchase;
        public double AffinityToSugar { get { return affinityToSugar; } }
        private double affinityToSugar;

        public double AffinityToAcridness { get { return affinityToAcridness; } }
        private double affinityToAcridness;

        public double AffinityToAequous { get { return affinityToAequous; } }
        private double affinityToAequous;

        public double AffinityToCoolingFactor { get { return affinityToCoolingFactor; } }
        private double affinityToCoolingFactor;
        public Customer(Random random)
        {
            names = new List<string>();
            AddNames();
            SetAName(random);
            SetAspendingPower(random);
        }

        private void AddNames() 
        {
            names.Add("James");
            names.Add("John");
            names.Add("Robert");
            names.Add("Michael");
            names.Add("William");
            names.Add("David");
            names.Add("Richard");
            names.Add("Joseph");
            names.Add("Thomas");
            names.Add("Mary");
            names.Add("Patricia");
            names.Add("Jennifer");
            names.Add("Linda");
            names.Add("Elizabeth");
            names.Add("Barbara");
            names.Add("Susan");
            names.Add("Jessica");
            names.Add("Betty");
            names.Add("Michelle");
            names.Add("Pamela");
        }
        private void SetAName(Random random) 
        {
            Name = names[ random.Next(0, names.Count)];

        }
        private void SetAspendingPower(Random random) 
        {
            int chance = random.Next(0, 100);
            if ((chance >= 0) && (chance <= 20)) { this.spendingPower = random.Next(0, 25000); }
            else if ((chance >= 21) && (chance <= 40)) { this.spendingPower = random.Next(26000, 50000); }
            else if ((chance >= 41) && (chance <= 60)) { this.spendingPower = random.Next(50000, 79526); }
            else if ((chance >= 61) && (chance <= 80)) { this.spendingPower = random.Next(79526, 130000); }
            else if ((chance >= 81) && (chance <= 99)) { this.spendingPower = random.Next(130000, 475116); }
            else if (chance == 100) { this.spendingPower = random.Next(475000, 1000000000); }
        }
        private void SetAffinityToSugar(Random random) { }
        private void SetAffinityToAcridity(Random random) { }
        private void SetAffinityToAequousLevels(Random random) { }
        private void SetAffinityToCoolingFactor(Random random, Day dayIamSpawnedIn) { }
        private void SetProbabilityOfSpending(Recipe RecepieCustomerInteractsWith) 
        {
            //Here is where we should manipulate chances of spend with regards to
            //78k -4.39%(3424.2) on food away from home, lets assume our visits are slightly lower than that of Starbucks
            //For an average SB customer; they receive 6 visits per month/ 72 visits a year, so we will take one of those visits / Month
            //at these numbers a total wallet of 285.00/month @ average 3.25/Item * 6, so If this price is matched, the game should model
            //an average willingness to spend 1.14% monthly food spend on our Lemmonade stand.
            //or an average of ((3.25*6)/4- (or a visit a week))/(78000) = .00625% || .0000625 of TOTAL INCOME PER CUSTOMER;
            //Anything Higher/Lower and demand levels should deviate with accordance to price elasticity of Consumer Drinks in this category
            //That IS accounting for a similar recipe, deviations of the recipe, like adding more sugar will dpend on the customer affinity levels
            //EACH CUSTOMER SHOULD HAVE AFFINITY LEVELS SET AT NORMAL DISTRIBUTION TO THOSE IN THE US;
            //FOR: SUGAR, ACRIDNESS, AQUEOUS LEVELS (How watery or close to water something is) and Cooling Factors (Dependant on Weather)
            //OUR RECIPE SHOULD HAVE A MODEL THAT MEASURES THE ACCRIDNESS & SUGAR CONCENTRATIONS OF ITSELF WHEN IN WATER;
            // OUR RECIPE SHOULD HAVE A MODEL THAT EASURES COOLING FACTOR BASED ON ICE ADDED
            //OUR RECIPE SHOULD HAVE A MODEL THAT MEASURES WATER DILLUTION WHEN WATER SUGAR AND LEMONS ARE ADDED
            //Our Recipe will asume ice-melt is negligeable because we are keeping our lemonade in a cooler somewhere.
        }
    }
}
