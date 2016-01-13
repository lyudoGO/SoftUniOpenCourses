namespace Words
{
    using System;

    class Words
    {
        private static int count = 0;
        private static string input;
        private static char[] symbols;

        static void Main()
        {
            input = Console.ReadLine();
            FillSymbolsArray();

            Array.Sort(symbols);

            Permutate(0, symbols.Length - 1);
            Console.WriteLine(count);
        }

        private static void FillSymbolsArray()
        {
            symbols = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                symbols[i] = input[i];
            }
        }

        private static void Permutate(int start, int end)
        {
            if (FindSolution())
            {
                //PrintResult();
                count++;
            }

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (symbols[left] != symbols[right])
                    {
                        Swap(left, right);
                        Permutate(left + 1, end);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = symbols[left];
                for (int i = left; i <= end - 1; i++)
                {
                    symbols[i] = symbols[i + 1];
                }
                symbols[end] = firstElement;
            }
        }

        private static bool FindSolution()
        {
            for (int i = 0; i < symbols.Length - 1; i++)
            {
                if (symbols[i] == symbols[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Swap(int i, int j)
        {
            char temp = symbols[i];
            symbols[i] = symbols[j];
            symbols[j] = temp;
        }

        private static void PrintResult()
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                Console.Write(symbols[i]);
            }

            Console.WriteLine();
        }
    }
}
