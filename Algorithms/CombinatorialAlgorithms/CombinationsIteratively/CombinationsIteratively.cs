using System;
using System.Collections.Generic;


namespace CombinationsIteratively
{
    class CombinationsIteratively
    {
        static void Main()
        {
            Console.Write("Please, enter a number N for set of elements: ");
            int numberN = int.Parse(Console.ReadLine());

            Console.Write("Please, enter number K <= N for elements: ");
            int numberK = int.Parse(Console.ReadLine());

            int[] result = new int[numberK];
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= numberN)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == numberK)
                    {
                        Print(result);
                        break;
                    }
                }
            }
        }
        
        private static void Print(int[] result)
        {
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
