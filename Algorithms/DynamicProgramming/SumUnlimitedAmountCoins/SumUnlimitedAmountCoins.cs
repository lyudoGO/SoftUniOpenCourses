using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumUnlimitedAmountCoins
{
    class SumUnlimitedAmountCoins
    {
        static void Main()
        {
            Console.Write("Please, enter a sum: ");
            var sum = int.Parse(Console.ReadLine());
            Console.WriteLine("Please, enter a sequence of coins:");
            var coins = Console.ReadLine()
                                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int count = CountCoints(coins, sum);

            Console.WriteLine("Count: {0}", count);
        }

        static int CountCoints(int[] coins, int sum)
        {
            var coinsSum = new int[sum + 1];
            coinsSum[0] = 1;
            for (int i = 0; i < coins.Length; i++)
            {
                var currentValue = coins[i];
                for (int j = currentValue; j <= sum; j++)
                {
                    coinsSum[j] += coinsSum[j - currentValue];
                }
            }

            return coinsSum[sum];
        }
    }
}
