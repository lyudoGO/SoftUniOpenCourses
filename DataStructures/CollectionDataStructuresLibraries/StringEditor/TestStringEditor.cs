namespace StringEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class TestStringEditor
    {
        private static BigList<char> result = new BigList<char>();

        static void Main()
        {
            ParseParameters();
            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var symbol in result)
            {
                Console.Write(symbol);
            }
        }

        private static void ParseParameters()
        {
            string[] parameters = Console.ReadLine().Split(' ');
            string command = parameters[0].Trim();
            while (command != "PRINT")
            {
                ProcessCommands(parameters, result);
 
                parameters = Console.ReadLine().Split(' ');
                command = parameters[0].Trim();
            }
        }

        private static void ProcessCommands(string[] parameters, BigList<char> result)
        {
            string command = parameters[0].Trim();
            string text = string.Empty;
            switch (command)
            {
                case "INSERT":
                    ProcessInsertCommand(parameters, result, text);
                    break;
                case "APPEND":
                    ProcessAppendCommand(parameters, result, text);
                    break;
                case "DELETE":
                    ProcessDeleteCommand(parameters, result);
                    break;
                case "REPLACE":
                    ProcessReplaceCommand(parameters, result, text);
                    break;
                default: Console.WriteLine("WRONG COMMAND");
                    break;
            }
        }

        private static void ProcessReplaceCommand(string[] parameters, BigList<char> result, string text)
        {
            try
            {
                int startIndex = int.Parse(parameters[1].Trim());
                int count = int.Parse(parameters[2].Trim());
                text = parameters[3].Trim();
                result.RemoveRange(startIndex, count);
                foreach (var symbol in text)
                {
                    result.Insert(startIndex, symbol);
                    startIndex++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }

        private static void ProcessDeleteCommand(string[] parameters, BigList<char> result)
        {
            try
            {
                int startIndex = int.Parse(parameters[1].Trim());
                int count = int.Parse(parameters[2].Trim());
                result.RemoveRange(startIndex, count);
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }

        private static void ProcessAppendCommand(string[] parameters, BigList<char> result, string text)
        {
            try
            {
                text = parameters[1].Trim();
                foreach (var symbol in text)
                {
                    result.Add(symbol);
                }
                result.Add(' ');
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }

        private static void ProcessInsertCommand(string[] parameters, BigList<char> result, string text)
        {
            try
            {
                text = parameters[1].Trim();
                int position = int.Parse(parameters[2].Trim());
                for (int i = 0; i < text.Length; i++)
                {
                    result.Insert(position, text[i]);
                    position++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }
    }
}
