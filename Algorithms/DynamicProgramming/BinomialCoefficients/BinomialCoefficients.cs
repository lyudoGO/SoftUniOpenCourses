using System;

namespace BinomialCoefficients
{
    class BinomialCoefficients
    {
        static void Main()
        {
            Console.Write("Please, enter a non-negative integer for N: ");
            int numN = int.Parse(Console.ReadLine());
            Console.Write("Please, enter a non-negative integer for K: ");
            int numK = int.Parse(Console.ReadLine());

            if (CheckInputNumbers(numN, numK))
            {
                decimal result = CalculateBinomialCoefficient(numN, numK);
                Console.WriteLine(result);
            }
        }

        private static decimal CalculateBinomialCoefficient(int numN, int numK)
        {
            decimal result = 1;
            for (int i = 1; i <= numK; i++)
            {
                result = result * (numN - (numK - i));
                result = result / i;
            }

            return result;
        }

        private static bool CheckInputNumbers(int numN, int numK)
        {
            bool isCorrect = true;
            if (numN < 1)
            {
                isCorrect = false;
                Console.WriteLine("Number N should be positive!");
            }

            if (numK > numN - 1 || 0 > numK)
            {
                isCorrect = false;
                Console.WriteLine("Number K should be in range (1 ... N - 1)!");
            }

            return isCorrect;
        }
    }
}
