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
    }
}
