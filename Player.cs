using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public List<Pitcher> listofPitchers;
        public LemmonadeStand mylemmonadeStand;
        public string name { get; set; }

        // constructor (SPAWNER)
        public Player()
        {
            listofPitchers = new List<Pitcher>();
            inventory = new Inventory();
            wallet = new Wallet();
            mylemmonadeStand = new LemmonadeStand();
        }

        // member methods (CAN DO)
    }
}
