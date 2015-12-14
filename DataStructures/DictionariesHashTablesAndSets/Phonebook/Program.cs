namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static Dictionary.Dictionary<string, string> phonebook = new Dictionary.Dictionary<string, string>();

        static void Main()
        {
            FillPhonebook();

            var listOfNames = new List<string>();

            InputNames(listOfNames);

            foreach (var name in listOfNames)
            {
                if (phonebook.ContainsKey(name))
                {
                    Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", name);
                }
            }
        }

        private static void InputNames(List<string> listOfNames)
        {
            Console.WriteLine("Please, enter number of names to search.");
            int numberOfNames = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter {0} names each on new line.", numberOfNames);
            for (int i = 0; i < numberOfNames; i++)
            {
                string name = Console.ReadLine();
                listOfNames.Add(name);
            }
            Console.WriteLine();
        }

        private static void FillPhonebook()
        {
            Console.WriteLine("Please, enter name and phone number on one line.\nFor the end enter 'search'.");
            string input = Console.ReadLine();

            while (input != "search")
            {
                string[] elements = input.Split(new char[] { ' ', '-', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string name = elements[0].Trim();
                string phone = elements[1].Trim();

                if (!phonebook.ContainsKey(name))
                {
                    phonebook[name] = phone;
                }
                else
                {
                    Console.WriteLine("{0} already exists!", name);
                }

                input = Console.ReadLine();
            }
        }
    }
}
