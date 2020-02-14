using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Inventory
    {
        // member variables (HAS A)
        public List<Item> lemons;
        public List<Item> sugarCubes;
        public List<Item> iceCubes;
        public List<Item> cups;

        // constructor (SPAWNER)
        public Inventory()
        {
            lemons = new List<Item>();
            sugarCubes = new List<Item>();
            iceCubes = new List<Item>();
            cups = new List<Item>();
        }

        // member methods (CAN DO)
        public void AddLemonsToInventory(int numberOfLemons)
        {
            for(int i = 0; i < numberOfLemons; i++)
            {
                Lemon lemon = new Lemon();
                lemons.Add(lemon);
            }
        }

        public void AddSugarCubesToInventory(int numberOfSugarCubes)
        {
            for(int i = 0; i < numberOfSugarCubes; i++)
            {
                SugarCube sugarCube = new SugarCube();
                sugarCubes.Add(sugarCube);
            }
        }

        public void AddIceCubesToInventory(int numberOfIceCubes)
        {
            for(int i = 0; i < numberOfIceCubes; i++)
            {
                IceCube iceCube = new IceCube();
                iceCubes.Add(iceCube);
            }
        }

        public void AddCupsToInventory(int numberOfCups)
        {
            for(int i = 0; i < numberOfCups; i++)
            {
                Cup cup = new Cup();
                cups.Add(cup);
            }
        }

        /// <summary>
        /// Will return bool and itemquantity ready to send if item to be sub is less than or = itemAvailable
        /// </summary>
        /// <param name="itemToBeSubtracted"></param>
        /// <param name="itemamount"></param>
        /// <param name="itemSent"></param>
        /// <returns></returns>
        public bool SubtractItemsFromInventory(List<Item> listOfitemToBeSubtracted, int itemQuantityToBeSubtracted, out Int32 itemSent) 
        {
            bool canTheySend = false;
            itemSent = 0;
            if (listOfitemToBeSubtracted.Count < itemQuantityToBeSubtracted) { canTheySend = false; }
            else { canTheySend = true;itemSent = itemQuantityToBeSubtracted; }
            return canTheySend;
        }
    }
}
