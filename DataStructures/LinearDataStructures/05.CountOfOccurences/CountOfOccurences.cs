//Problem 5.Count of Occurences
//Write a program that finds in given array of integers how many times each of 
//them occurs. The input sequence holds numbers in range [0…1000]. 
//The output should hold all numbers that occur at least once along with their 
//number of occurrences. 


namespace _05.CountOfOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class CountOfOccurences
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a sequence of integer numbers in range [0...1000]:");
            int[] sequence = Console.ReadLine()
                                 .Split(' ')
                                 .Select(n => Int32.Parse(n))
                                 .ToArray();

            Array.Sort(sequence);

            int currentNumber = 0;
            int count = 1;

            for (int i = 1; i <= sequence.Length; i++)
            {
                currentNumber = sequence[i - 1];
                if (i == sequence.Length)
                {
                    Console.WriteLine("{0} -> {1} times", currentNumber, count);
                    break;
                }

                if (currentNumber == sequence[i])
                {
                    count++;
                }
                else
                {
                    Console.WriteLine("{0} -> {1} times", currentNumber, count);
                    count = 1;
                }
            }
        }
    }
}
