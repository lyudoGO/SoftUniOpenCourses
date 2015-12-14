namespace CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Please, enter some text:");
            string input = Console.ReadLine();

            Dictionary.Dictionary<char, int> symbols = new Dictionary.Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                if (!symbols.ContainsKey(currentSymbol))
                {
                    symbols[currentSymbol] = 0;
                }

                symbols[currentSymbol]++;
            }

            PrintSymbols(symbols);
        }

        private static void PrintSymbols(Dictionary.Dictionary<char, int> symbols)
        {
            var keyList = symbols.Keys.ToList();
            keyList.Sort();

            foreach (var key in keyList)
            {
                Console.WriteLine("{0}: {1} time/s", key, symbols[key]);
            }
        }
    }
}
