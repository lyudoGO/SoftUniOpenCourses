using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestZigzagSubsequence
{
    class LongestZigzagSubsequence
    {
        static void Main()
        {
            var sequence = Console.ReadLine().Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries ).Select(int.Parse).ToArray();
            var longestSeq = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine("Longest Zigzag Subsequence");
            Console.WriteLine("  Length: {0}", longestSeq.Length);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
        {
            int[] len = new int[sequence.Length];
            int[] prev = new int[sequence.Length];
            int[] sings = new int[sequence.Length];
            int maxLen = 0;
            int lastIndex = -1;

            for (int x = 0; x < sequence.Length; x++)
            {
                len[x] = 1;
                prev[x] = -1;
                sings[x] = 0;
                for (int i = 0; i < x; i++)
                {
                    if (sings[i] == 0 ||
                        (sings[i] > 0 && (sequence[x] - sequence[i]) < 0 && len[i] >= len[x]) ||
                        (sings[i] < 0 && (sequence[x] - sequence[i]) > 0 && len[i] >= len[x]))
                    {
                        len[x] = len[x] + len[i];
                        prev[x] = i;
                        sings[x] = sequence[x] - sequence[i];
                    }
                }

                if (len[x] > maxLen)
                {
                    maxLen = len[x];
                    lastIndex = x;
                }
            }

            var longestSeq = new List<int>();
            while (lastIndex != -1)
            {
                longestSeq.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSeq.Reverse();

            return longestSeq.ToArray();
        }
    }
}
