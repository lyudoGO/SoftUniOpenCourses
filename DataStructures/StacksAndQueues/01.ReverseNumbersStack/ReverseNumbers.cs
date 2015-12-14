namespace _01.ReverseNumbersStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReverseNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a sequence of int numbers separate with space:");
            List<int> input = Console.ReadLine()
                                     .Split(' ')
                                     .Select(n => Int32.Parse(n))
                                     .ToList();

            Stack<int> numbers = new Stack<int>(input);

            while (numbers.Count > 0)
            {
                int number = numbers.Pop();
                Console.Write(number + " ");
            }
        }
    }
}
