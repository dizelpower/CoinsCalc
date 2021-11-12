using System.Collections.Generic;

namespace CoinsCalc
{
    class CashDrawer
    {
        CoinsCount coinsCount = new CoinsCount();

        /// <summary>
        /// Start of the Day . Add some coins in to drawer  
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="count"> </param>
        /// <returns></returns>
        public void AddCoins(Coins coins, int count)
        {
            switch (coins)
            {
                case Coins.Coin1:
                    coinsCount.CoinsCount_1cnt += count;
                    coinsCount.TotalAmount += count;
                    break;

                case Coins.Coin2:
                    coinsCount.CoinsCount_2cnt += count;
                    coinsCount.TotalAmount += count * 2;
                    break;

                case Coins.Coin5:
                    coinsCount.CoinsCount_5cnt += count;
                    coinsCount.TotalAmount += count * 5;
                    break;

                case Coins.Coin10:
                    coinsCount.CoinsCount_10cnt += count;
                    coinsCount.TotalAmount += count * 10;
                    break;

                case Coins.Coin20:
                    coinsCount.CoinsCount_20cnt += count;
                    coinsCount.TotalAmount += count * 20;
                    break;

                case Coins.Coin50:
                    coinsCount.CoinsCount_50cnt += count;
                    coinsCount.TotalAmount += count * 50;
                    break;

                default:
                    break;
            }

        }
        /// <summary>
        /// Start of the Day . Add some coins in to drawer 
        /// </summary>
        /// <param name="CoinsProvided"> Coins , count</param>
        public void AddCoins(Dictionary<Coins, int> CoinsProvided)
        {
            foreach (var item in CoinsProvided)
            {
                AddCoins(item.Key, item.Value);
            }
        }
        /// <summary>
        /// seling operation by provided coins
        /// </summary>
        /// <param name="CoinsProvided"></param>
        /// <param name="ItemCost"></param>
        /// <returns>Returns info : coin count and total amount for return </returns>
        public Results ReleaseCoins(Dictionary<Coins, int> CoinsProvided, decimal ItemCost)
        {
            Results results = new Results();

            decimal CashForItem = AmountOfCoins(CoinsProvided);
            decimal  AmountReturn = CashForItem - ItemCost;
            decimal _amountReturn = AmountReturn;

            if (CashForItem < ItemCost)
            {
                results.TextMessage = "not enougt cash provided";
                results.Error = true;
                return results;
            }

            if (CashForItem == ItemCost)
            {
                results.TextMessage = "Zero cash return.";
                results.Error = true;
                return results;
            }

            if (coinsCount.TotalAmount < AmountReturn)
            {

                results.TextMessage = "Coins are not enough for return";
                results.Error = true;
                return results;
            }

            
            decimal _amountInMachine = coinsCount.TotalAmount;

            CoinsCount _coinsInMachine = coinsCount;
            CoinsCount _coinsForReturn = new CoinsCount();


            while (AmountReturn > 0)
            {

                if (AmountReturn >= 50 && MachineHasCoin(Coins.Coin50))
                {
                    AmountReturn -= 50;
                    _coinsForReturn.CoinsCount_50cnt += 1;
                    _coinsInMachine.CoinsCount_50cnt -= 1;      //atimti viena 50
                }

                else if (AmountReturn >= 20 && MachineHasCoin(Coins.Coin20))
                {
                    AmountReturn -= 20;
                    _coinsForReturn.CoinsCount_20cnt += 1;
                    _coinsInMachine.CoinsCount_20cnt -= 1; //atimti viena 20
                }
                else if (AmountReturn >= 10 && MachineHasCoin(Coins.Coin10))
                {
                    AmountReturn -= 10;
                    _coinsForReturn.CoinsCount_10cnt += 1;
                    _coinsInMachine.CoinsCount_10cnt -= 1; //atimti viena 10
                }
                else if (AmountReturn >= 5 && MachineHasCoin(Coins.Coin5))
                {
                    AmountReturn -= 5;
                    _coinsForReturn.CoinsCount_5cnt += 1;
                    _coinsInMachine.CoinsCount_5cnt -= 1; //atimti viena 5
                }
                else if (AmountReturn >= 2 && MachineHasCoin(Coins.Coin2))
                {
                    AmountReturn -= 2;
                    _coinsForReturn.CoinsCount_2cnt += 1;
                    _coinsInMachine.CoinsCount_2cnt -= 1; //atimti viena 5
                }
                else if (AmountReturn >= 1 && MachineHasCoin(Coins.Coin1))
                {
                    AmountReturn -= 1;
                    _coinsForReturn.CoinsCount_1cnt += 1;
                    _coinsInMachine.CoinsCount_1cnt -= 1;//atimti viena 1
                }
                else
                {
                    results.TextMessage = "Operation not posible";
                    results.Error = true;
                    return results;
                }
            }

            coinsCount = _coinsInMachine;
            AddCoins(CoinsProvided);

            results.CoinsCount = _coinsForReturn;
            results.CoinsCount.TotalAmount = _amountReturn;
            results.TextMessage = "Operation successful";
            results.Error = false;
            return results;
        }
        private decimal AmountOfCoins(Dictionary<Coins, int> CoinsProvided)
        {
            decimal total = 0;

            foreach (var item in CoinsProvided)
            {
                switch (item.Key)
                {
                    case Coins.Coin1:
                        total += item.Value;
                        break;
                    case Coins.Coin2:
                        total += item.Value * 2;
                        break;
                    case Coins.Coin5:
                        total += item.Value * 5;
                        break;
                    case Coins.Coin10:
                        total += item.Value * 10;
                        break;
                    case Coins.Coin20:
                        total += item.Value * 20;
                        break;
                    case Coins.Coin50:
                        total += item.Value * 50;
                        break;
                    default:
                        break;
                }
            }
            return total;
        }

        private bool MachineHasCoin(Coins coins)
        {
            switch (coins)
            {
                case Coins.Coin1:
                    if (coinsCount.CoinsCount_1cnt > 0)
                    {
                        return true;
                    }
                    break;
                case Coins.Coin2:
                    if (coinsCount.CoinsCount_2cnt > 0)
                    {
                        return true;
                    }

                    break;
                case Coins.Coin5:
                    if (coinsCount.CoinsCount_5cnt > 0)
                    {
                        return true;
                    }
                    break;
                case Coins.Coin10:
                    if (coinsCount.CoinsCount_10cnt > 0)
                    {
                        return true;
                    }
                    break;
                case Coins.Coin20:
                    if (coinsCount.CoinsCount_20cnt > 0)
                    {
                        return true;
                    }
                    break;
                case Coins.Coin50:
                    if (coinsCount.CoinsCount_50cnt > 0)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        /// <summary>
        /// total coin count
        /// </summary>
        /// <returns></returns>
        public CoinsCount TotalCount()
        {
            return coinsCount;
        }



    }
}
