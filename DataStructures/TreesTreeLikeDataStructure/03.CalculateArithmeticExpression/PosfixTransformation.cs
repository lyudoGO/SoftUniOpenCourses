namespace _03.CalculateArithmeticExpression
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System;

    public class PosfixTransformation
    {
        private readonly List<char> operators = new List<char> { '+' , '-', '/', '*', '%', '^', '!', '='};
        private readonly List<char> brakets = new List<char> { '(', ')' };
        private readonly List<string> functions = new List<string> { "ln", "pow", "cos", "sin", "sqrt" };

        public Queue<string> ConvertToReversePolishNotation(List<string> tokens)
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < tokens.Count; i++)
            {
                var currentToken = tokens[i];
                double number;

                if (double.TryParse(currentToken, out number))
                {
                    queue.Enqueue(currentToken);
                }
                else if (functions.Contains(currentToken))
                {
                    stack.Push(currentToken);
                }
                else if (currentToken == ",")
                {
                    if (!stack.Contains("(") || stack.Count == 0)
                    {
                        throw new ArgumentException("Invalid brakets or function separator!");
                    }

                    while (stack.Count != 0 && stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }
                }
                else if (operators.Contains(currentToken[0]))
                {
                    while (stack.Count != 0 && operators.Contains(stack.Peek()[0]))
                    {
                        if (IsLeftAssociative(currentToken) && stack.Count > 0 && (GetPrecedenceFor(currentToken) <= GetPrecedenceFor(stack.Peek()))
                            || (IsRightAssociative(currentToken) && GetPrecedenceFor(currentToken) < GetPrecedenceFor(stack.Peek())))
	                    {
                            string operatorToReturn = stack.Pop();
                            queue.Enqueue(operatorToReturn);
	                    }
                        else
                        {
                            break;
                        }
                    }

                    stack.Push(currentToken);
                }
                else if (currentToken == "(")
                {
                    stack.Push("(");
                }
                else if (currentToken == ")")
                {
                    if (!stack.Contains("("))
                    {
                        throw new ArgumentException("Invalid brakets position!");
                    }

                    while (stack.Count != 0 && stack.Peek() != "(")
                    {
                        queue.Enqueue(stack.Pop());
                    }

                    stack.Pop();

                    if (stack.Count != 0 && functions.Contains(stack.Peek()))
                    {
                        queue.Enqueue(stack.Pop());
                    }
                }
            }

            while (stack.Count != 0)
            {
                if (brakets.Contains(stack.Peek()[0]))
                {
                    throw new ArgumentException("Invalid brakets position!");
                }

                queue.Enqueue(stack.Pop());
            }

            return queue;
        }

        public double CalculateRPN(Queue<string> queue)
        {
            Stack<double> stack = new Stack<double>();

            while (queue.Count != 0)
            {
                string currentToken = queue.Dequeue();
                double number;

                if (double.TryParse(currentToken, out number))
                {
                    stack.Push(number);
                }
                else if (operators.Contains(currentToken[0]) || functions.Contains(currentToken))
                {
                    if (currentToken == "+")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression in addition!");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(firstNumber + secondNumber);
                    }
                    else if (currentToken == "-")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression in subtraction!");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(secondNumber - firstNumber);
                    }
                    else if (currentToken == "*")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression in multiply!");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(secondNumber * firstNumber);
                    }
                    else if (currentToken == "/")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression in division!");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(secondNumber / firstNumber);
                    }
                    else if (currentToken == "%")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression in modulus!");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(secondNumber % firstNumber);
                    }
                    else if (currentToken == "^")
                    {
                        if (stack.Count < 2)
                        {
                            throw new ArgumentException("Invalid expression in power!");
                        }

                        double firstNumber = stack.Pop();
                        double secondNumber = stack.Pop();

                        stack.Push(Math.Pow(secondNumber, firstNumber));                     
                    }
                    else if (functions.Contains(currentToken))
                    {
                        //if (stack.Count < 1 || stack.Count < 2)
                        //{
                        //    throw new ArgumentException("Invalid expression in functions!");
                        //}

                        switch (currentToken)
                        {
                            case "ln": 
                                double result = Math.Log(stack.Pop());
                                stack.Push(result);
                                break;
                            case "cos":
                                result = Math.Cos(stack.Pop());
                                stack.Push(result);
                                break;
                            case "sin":
                                result = Math.Sin(stack.Pop());
                                stack.Push(result);
                                break;
                            case "pow": 
                                double firstNumber = stack.Pop();
                                double secondNumber = stack.Pop(); 
                                result = Math.Pow(secondNumber, firstNumber);
                                stack.Push(result);
                                break;
                            case "sqrt": 
                                result = Math.Sqrt(stack.Pop());
                                stack.Push(result);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (stack.Count == 1)
            {
                return stack.Pop();
            }
            else
            {
                throw new ArgumentException("Cannot calculate invalid expression!");
            }
        }

        private bool IsLeftAssociative(string currentToken)
        {
            if (operators.Contains(currentToken[0]) && operators.IndexOf(currentToken[0]) <= 4)
            {
                return true;
            }

            return false;
        }

        private bool IsRightAssociative(string currentToken)
        {
            if (operators.Contains(currentToken[0]) && operators.IndexOf(currentToken[0]) > 4)
            {
                return true;
            }

            return false;
        }

        private int GetPrecedenceFor(string arithmeticOperator)
        {
            if (arithmeticOperator == "=")
            {
                return 1;
            }
            else if (arithmeticOperator == "+" || arithmeticOperator == "-")
            {
                return 2;
            }
            else if (arithmeticOperator == "*" || arithmeticOperator == "/" || arithmeticOperator == "%")
            {
                return 3;
            }
            else if (arithmeticOperator == "!")
            {
                return 4;
            }
            else if (arithmeticOperator == "^")
            {
                return 5;
            }

            throw new InvalidOperationException(string.Format("{0} is not a valid operator!", arithmeticOperator));
        }
    }
}
