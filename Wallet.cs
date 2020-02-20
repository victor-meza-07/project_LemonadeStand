using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Wallet
    {

        // property - TBD
        public double Money{ get { return money; } }
        double money;

        public Wallet()
        {
            money = 20.00;
        }

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;  
        }
        public void AddFromTodaysEarnings(double moneyEarned) 
        {
            money += moneyEarned;
        }
    }
}
