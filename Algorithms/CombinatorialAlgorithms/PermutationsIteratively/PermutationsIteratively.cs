using System;
using System.Linq;


namespace PermutationsIteratively
{
    class PermutationsIteratively
    {
        private static int countOfPermutations = 0;

        static void Main()
        {
            Console.Write("Please, enter a positive integer number: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = Enumerable.Range(1, n).ToArray();
            int[] loops = new int[n];

            int index = 1;
            Print(array);
            countOfPermutations++;

            while (index < n)
	        {
	            if (loops[index] < index)
                {
                    int j = ((index % 2) == 0) ? 0 : loops[index];
 
                    Swap(ref array[index], ref array[j]);
                    Print(array);
                    countOfPermutations++;
                    loops[index]++;
                    index = 1;
                }
                else
                {
                    loops[index] = 0;
                    index++; 
                }
	        }

            Console.WriteLine("Total permutations: {0}", countOfPermutations);
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
