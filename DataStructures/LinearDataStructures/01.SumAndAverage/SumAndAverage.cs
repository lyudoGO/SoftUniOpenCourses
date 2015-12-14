//Problem 1.Sum and Average
//Write a program that reads from the console a sequence of integer numbers 
//(on a single line, separated by a space). Calculate and print the sum and 
//average of the elements of the sequence. Keep the sequence in List<int>.


namespace _01.SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SumAndAverage
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a sequence of integer numbers:");
            string[] input = Console.ReadLine().Split(' ');

            List<int> sequence = input.Select(m => Int32.Parse(m)).ToList();
            long sum = sequence.Sum();
            double average = (double)sum / sequence.Count;

            Console.WriteLine("The sum is: {0}", sum);
            Console.WriteLine("Average is: {0}", average);
        }
    }
}
