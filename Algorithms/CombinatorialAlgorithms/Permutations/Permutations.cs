using System;
using System.Linq;
using System.Text;

namespace Permutations
{
    class Permutations
    {
        private static int countOfPermutations = 0;

        static void Main()
        {
            Console.Write("Please, enter a positive integer number: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = Enumerable.Range(1, n).ToArray();

            Permutate(array);

            Console.WriteLine("Total permutations: {0}", countOfPermutations);
        }

        private static void Permutate(int[] array, int startIndex = 0)
        {
            if (startIndex >= array.Length)
            {
                Print(array);
                countOfPermutations++;
            }
            else
            {
                for (int i = startIndex ; i < array.Length; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    Permutate(array, startIndex + 1);
                    Swap(ref array[startIndex], ref array[i]);
                }
            }
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i == j)
	        {
		         return;
	        }
            i = i ^ j;
            j = j ^ i;
            i = i ^ j;
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
