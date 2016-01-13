namespace GroupPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GroupPermutations 
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<char, int> letters = new Dictionary<char, int>();
            CountLetters(input, letters);

            string[] array = BuildGroupLetters(letters);

            GeneratePermutations(array, 0);
        }

        private static void CountLetters(string input, Dictionary<char, int> letters)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                if (!letters.ContainsKey(letter))
                {
                    letters.Add(letter, 0);
                }
                letters[letter]++;
            }
        }

        private static string[] BuildGroupLetters(Dictionary<char, int> letters)
        {
            string[] array = new string[letters.Keys.Count];
            int index = 0;
            foreach (var letter in letters)
            {
                array[index++] = new string(letter.Key, letter.Value);
            }
            return array;
        }

        private static void GeneratePermutations<T>(T[] array, int k)
        {
            if (k >= array.Length)
            {
                Print(array);
            }
            else
            {
                //GeneratePermutations(arr, k + 1);
                for (int i = k; i < array.Length; i++)
                {
                    Swap(ref array[k], ref array[i]);
                    GeneratePermutations(array, k + 1);
                    Swap(ref array[k], ref array[i]);
                }
            }
        }

        private static void Print<T>(T[] array)
        {
            Console.WriteLine(string.Join("", array));
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
