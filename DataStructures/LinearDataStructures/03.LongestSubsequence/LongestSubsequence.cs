//Problem 3.Longest Subsequence
//Write a method that finds the longest subsequence of equal numbers in given 
//List<int> and returns the result as new List<int>. 
//If several sequences has the same longest length, return the leftmost of them. 
//Write a program to test whether the method works correctly. 


namespace _03.LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LongestSubsequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a sequence of integer numbers:");
            List<int> sequence = Console.ReadLine()
                                 .Split(' ')
                                 .Select(n => Int32.Parse(n))
                                 .ToList();

            List<int> subSequence = FindLongestSubsequence(sequence);
            Console.WriteLine(string.Join(", ", subSequence));
        }

        private static List<int> FindLongestSubsequence(List<int> sequence)
        {
            int number = 0;
            int count = 1;
            int maxCount = 0;
            List<int> subSequence = new List<int>();

            if (sequence.Count == 1)
            {
                subSequence.Add(sequence[0]);
                return subSequence;
            }

            for (int i = 0; i < sequence.Count - 1; i++)
            {
                if (sequence[i] == sequence[i + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    number = sequence[i];
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                subSequence.Add(number);
            }

            return subSequence;
        }
    }
}
