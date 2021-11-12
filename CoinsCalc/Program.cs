using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinsCalc
{
    class Program
    {
        static void Main(string[] args)
        {

            // Add coins to vending machine

            CashDrawer cashDrawer = new CashDrawer();
            cashDrawer.AddCoins(Coins.Coin20, 5);
            cashDrawer.AddCoins(Coins.Coin10, 5);
            cashDrawer.AddCoins(Coins.Coin5, 5);
            cashDrawer.AddCoins(Coins.Coin2, 10);
            cashDrawer.AddCoins(Coins.Coin1, 20);


            // prepare for sale op.
            Dictionary<Coins, int> CoinsProvided = new Dictionary<Coins, int>();
            CoinsProvided.Add(Coins.Coin20, 1);
            CoinsProvided.Add(Coins.Coin10, 1);


            // calc. Output data in ouputFormMachine value.
            var ouputFormMachine = cashDrawer.ReleaseCoins(CoinsProvided, 22);
        }
    }
}
