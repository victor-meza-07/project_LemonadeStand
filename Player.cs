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
        public Wallet wallet;
        public List<LemmonadeStand> myFranchiseofStands;
        public List<Recipe> myReceipeBook;
        public string name { get; set; }
        public bool canIAdvertise { get; set; }

        // constructor (SPAWNER)
        public Player()
        {
            
            wallet = new Wallet();
            myFranchiseofStands = new List<LemmonadeStand>();
            myReceipeBook = new List<Recipe>();
           
        }

        // member methods (CAN DO)
        public void ClearMyValues() 
        {
            wallet = new Wallet();
            myFranchiseofStands.Clear();
            myReceipeBook.Clear();
            name = null;
            canIAdvertise = false;
        }
    }
}
