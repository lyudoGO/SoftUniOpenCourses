using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetsOfStringArray
{
    class SubsetsOfStringArray
    {
        private static int numberK;
        private static int[] loops;
        private static string[] input;

        static void Main()
        {
            //Console.WriteLine("Please, enter some words separate with space: ");
            //input = Console.ReadLine().Split();
            input = new string[] { "test", "rock", "fun" };

            Console.Write("Please, enter number K <= numbers of words: ");
            numberK = int.Parse(Console.ReadLine());

            loops = new int[numberK];

            GetCombinations(0, 0);
        }
        private static void GetCombinations(int currentLoop, int start)
        {
            if (currentLoop == numberK)
            {
                Print();
                return;
            }

            for (int counter = start; counter < input.Length; counter++)
            {
                loops[currentLoop] = counter;
                GetCombinations(currentLoop + 1, counter + 1);
            }
        }

        private static void Print()
        {
            Console.Write("(");
            for (int i = 0; i < loops.Length; i++)
            {
                if (i == loops.Length - 1)
                {
                    Console.Write(input[loops[i]]);
                }
                else
                {
                    Console.Write(input[loops[i]] + " ");
                }
            }
            Console.WriteLine(")");
        }
    }
}
