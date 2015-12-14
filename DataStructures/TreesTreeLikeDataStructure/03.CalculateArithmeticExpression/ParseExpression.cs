namespace _03.CalculateArithmeticExpression
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ParseExpression
    {
        private static readonly List<char> operators = new List<char> { '+', '-', '/', '*', '%', '^', '=' };
        private static readonly List<char> brakets = new List<char> { '(', ')' };
        private static readonly List<string> functionTwoSymbols = new List<string> { "ln" };
        private static readonly List<string> functionThreeSymbols = new List<string> { "cos", "sin", "pow" };
        private static readonly List<string> functionFourSymbols = new List<string> { "sqrt" };

        public static List<string> SeparateTokenExpression(string expression)
        {
            string trimedExpression = expression.Trim()
                                                .Replace(" ", string.Empty)
                                                .ToLower();
            StringBuilder number = new StringBuilder();
            List<string> result = new List<string>();
      
            for (int i = 0; i < trimedExpression.Length; i++)
            {
                if (trimedExpression[i] == '-' && (i == 0 || trimedExpression[i - 1] == ',' || trimedExpression[i - 1] == '('
                    || trimedExpression[i - 1] == '^'))
                {
                    number.Append('-');
                }
                else if (char.IsDigit(trimedExpression[i]) || trimedExpression[i] == '.')
                {
                    number.Append(trimedExpression[i]);
                }
                else if (!char.IsDigit(trimedExpression[i]) && trimedExpression[i] != '.' && number.Length != 0)
                {
                    result.Add(number.ToString());
                    number.Clear();
                    i--;
                }
                else if (brakets.Contains(trimedExpression[i]))
                {
                    result.Add(trimedExpression[i].ToString());
                }
                else if (operators.Contains(trimedExpression[i]))
                {
                    result.Add(trimedExpression[i].ToString());
                }
                else if (trimedExpression[i] == ',')
                {
                    result.Add(",");
                }
                else if (i + 1 < trimedExpression.Length && functionTwoSymbols.Contains(trimedExpression.Substring(i, 2)))
                {
                    result.Add(trimedExpression.Substring(i, 2));
                    i++;
                }
                else if (i + 2 < trimedExpression.Length && functionThreeSymbols.Contains(trimedExpression.Substring(i, 3)))
                {
                    result.Add(trimedExpression.Substring(i, 3));
                    i += 2;
                }
                else if (i + 3 < trimedExpression.Length && functionFourSymbols.Contains(trimedExpression.Substring(i, 4)))
                {
                    result.Add(trimedExpression.Substring(i, 4));
                    i += 3;
                }
                else
                {
                    throw new ArgumentException("Cannot parse input!Invalid expression!");
                }
            }

            if (number.Length != 0)
            {
                result.Add(number.ToString());
            }

            return result;
        }
    }
}
