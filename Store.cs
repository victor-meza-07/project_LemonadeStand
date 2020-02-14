using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Store
    {
        // member variables (HAS A)
        public double pricePerLemon { get; set; }
        public double pricePerSugarCube { get; set; }
        public double pricePerIceCube { get; set; }
        public double pricePerCup { get; set; }
        

        // constructor (SPAWNER)
        public Store()
        {
            
            pricePerLemon = .5;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }

        // member methods (CAN DO)
        public void SellLemons(Player player, LemmonadeStand FranchiseToAddInventoryTo)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems(new Lemon());
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                for (int i = 0; i < lemonsToPurchase; i++)
                {
                    FranchiseToAddInventoryTo.inventoryOfthisStand.lemons.Add(new Lemon());
                }
                
            }
        }

        public void SellSugarCubes(Player player, LemmonadeStand FranchiseToAddInventoryTo)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems(new SugarCube());
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                for (int i = 0; i < sugarToPurchase; i++)
                {
                    FranchiseToAddInventoryTo.inventoryOfthisStand.lemons.Add(new SugarCube());
                }
            }
        }

        public void SellIceCubes(Player player, LemmonadeStand FranchiseToAddInventoryTo)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems(new IceCube());
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                for (int i = 0; i < iceCubesToPurchase; i++)
                {
                    FranchiseToAddInventoryTo.inventoryOfthisStand.lemons.Add(new IceCube());
                }
                
            }
        }

        public void SellCups(Player player, LemmonadeStand FranchiseToAddInventoryTo)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems(new Cup());
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                for (int i = 0; i < cupsToPurchase; i++)
                {
                    FranchiseToAddInventoryTo.inventoryOfthisStand.lemons.Add(new Cup());
                }
            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }
    }
}
