namespace SumLimitedAmountCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SumLimitedAmountCoins
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
            //subArraySum(coins, coins.Length, sum);
        }

        static int CountCoints(int[] coins, int sum)
        {
            int count = 0;
            for (int i = 1; i < coins.Length; i++)
            {
                var currentSum = 0;
                for (int j = i; j < coins.Length; j++)
                {
                    currentSum += coins[j - 1];
                    if (currentSum == sum)
                    {
                        count++;
                        break;
                    }
                    if (currentSum > sum)
                    {
                        currentSum -= coins[j - 1];
                    }

                }
            }

            return count;
        }

        static void subArraySum(int[] arr, int n, int sum)
        {
            int curr_sum = arr[0], start = 0, i, count = 0;

            for (i = 1; i <= n; i++)
            {
                while (curr_sum > sum && start < i-1)
                {
                    if (arr[start] != -1)
                    {
                        curr_sum = curr_sum - arr[start];
                        start++;
                    }
                }

                if (curr_sum == sum)
                {
                    Console.WriteLine("Sum found between indexes {0} and {1}\n", start, i-1);
                    int j;
                    for (j = start; j <= i - 1; j++)
                    {
                        arr[j] = -1;
                    }
                    count++;
                    return;
                }

                if (i < n)
                    curr_sum = curr_sum + arr[i];
            }

            subArraySum(arr, n, sum);
            Console.WriteLine("No subarray found");

            return;
        }
    }
}
