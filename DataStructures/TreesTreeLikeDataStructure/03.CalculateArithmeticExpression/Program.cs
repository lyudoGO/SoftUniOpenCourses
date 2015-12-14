namespace _03.CalculateArithmeticExpression
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;

    public class Program
    {
        static void Main()
        {
            PutInvariantCulture();

            BeginCalculation();
        }

        private static void BeginCalculation()
        {
            try
            {
                Console.WriteLine("Please, enter a expression to calculate: ");
                string expression = Console.ReadLine();

                //string expression = "3 +4 * 2 / ( 1 - 5 ) ^ 2 ^ 3 =";
                List<string> tokens = ParseExpression.SeparateTokenExpression(expression);

                PosfixTransformation transformedTokens = new PosfixTransformation();
                Queue<string> rpn = transformedTokens.ConvertToReversePolishNotation(tokens);
                double finalResult = transformedTokens.CalculateRPN(rpn);

                Console.WriteLine("Expression: {0}", expression);
                Console.WriteLine("Result: {0}", finalResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void PutInvariantCulture()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }
    }
}
