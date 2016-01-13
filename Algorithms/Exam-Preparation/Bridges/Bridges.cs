namespace Bridges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Bridges
    {
        static void Main()
        {
            int[] northNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] southNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] bridges = new int[northNumbers.Length, southNumbers.Length];
            for (int nPos = 0; nPos < northNumbers.Length; nPos++)
            {
                for (int sPos = 0; sPos < southNumbers.Length; sPos++)
                {
                    bridges[nPos, sPos] = -1;
                }
            }

            int max = CalculateBridges(bridges, northNumbers, southNumbers, northNumbers.Length - 1, southNumbers.Length - 1);
            Console.WriteLine(max);
        }

        private static int CalculateBridges(int[,] brigdes, int[] northNumbers, int[] southNumbers, int northPos, int southPos)
        {
            if (northPos < 0 || southPos < 0)
            {
                return 0;
            }

            if (brigdes[northPos, southPos] != -1)
            {
                return brigdes[northPos, southPos];
            }

            int northLeftPos = CalculateBridges(brigdes, northNumbers, southNumbers, northPos - 1, southPos);
            int southLeftPos = CalculateBridges(brigdes, northNumbers, southNumbers, northPos, southPos - 1);
            if (northNumbers[northPos] == southNumbers[southPos])
            {
                brigdes[northPos, southPos] = 1 + Math.Max(northLeftPos, southLeftPos);
            }
            else
            {
                brigdes[northPos, southPos] = Math.Max(northLeftPos, southLeftPos);
            }

            return brigdes[northPos, southPos];
        }
    }
}
