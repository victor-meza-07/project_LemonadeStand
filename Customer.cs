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
        public string name { get { return Name; } } // formally a property
        private string Name;
        public Customer(Random random)
        {
            
            AddNames();
            SetAName(random);
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

        // I know there must be a way to scan a db programatically and add from there, but i didn;t feel like researching it for this functionality. 
        private string SetAName(Random random) 
        {
            
            string name = "";
            name = names[ random.Next(0, names.Count)];
            return name;
        }
    }
}
