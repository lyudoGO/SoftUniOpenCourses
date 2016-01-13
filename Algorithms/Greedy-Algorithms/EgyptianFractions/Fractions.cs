namespace EgyptianFractions
{
    using System;

    class Fractions
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] parameters = input.Split('/');
            int numerator = int.Parse(parameters[0]);
            int denominator = int.Parse(parameters[1]);

            if (numerator == 0 || denominator == 0 || numerator > denominator)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.Write("{0} = ", input);
                PrintEgyptianFractions(numerator, denominator);
                Console.WriteLine();
            }
        }

        static void PrintEgyptianFractions(int numerator, int denominator)
        {
            if (denominator % numerator == 0)
            {
                Console.Write("1/{0}", denominator / numerator);
                return;
            }

            if (numerator % denominator == 0)
            {
                Console.Write(numerator / denominator); 
                return;
            }

            int num = denominator / numerator + 1;
            Console.Write("1/{0} + ", num);

            PrintEgyptianFractions(numerator * num - denominator, denominator * num);
        }
    }
}