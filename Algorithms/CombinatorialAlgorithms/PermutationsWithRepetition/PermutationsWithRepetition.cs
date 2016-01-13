using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationsWithRepetition
{
    class PermutationsWithRepetition
    {
        private static int[] array;
        private static int count = 0;

        static void Main()
        {
            Console.WriteLine("Please, enter integer numbers separate with space: ");
            array = Console.ReadLine().Split().Select(e => int.Parse(e)).ToArray();
            //array = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

            Array.Sort(array);
            Permute(0, array.Length - 1);
            Console.WriteLine(count);
        }

        static void Permute(int start, int end)
        {
            if (FindSolution())
            {
                //Print();
                count++;
            }
            

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (!array[left].Equals(array[right]))
                    {
                        Swap(ref array[left], ref array[right]);
                        Permute(left + 1, end);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = array[left];
                for (int i = left; i <= end - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[end] = firstElement;
            }
        }

        static void Print()
        {
            Console.WriteLine("{" + string.Join(", ", array) + "}");
        }

        static void Swap(ref int first, ref int second)
        {
            int oldFirst = first;
            first = second;
            second = oldFirst;
        }
        private static bool FindSolution()
        {
            bool isSolve = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != array[i + 1])
                {
                    isSolve = true;
                }
                else
                {
                    return false;
                }
            }

            return isSolve;
        }
    }
}
