using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseShoppingCenter
{
    public class ShoppingCenterMain
    {
        private static ShoppingCenter shoppingCenter = new ShoppingCenter();

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                ProcessCommand(line);
            }
        }

        private static void ProcessCommand(string line)
        {
            int endOfCommand = line.IndexOf(' ');
            string command = line.Substring(0, endOfCommand);
            string parametersStr = line.Substring(endOfCommand + 1);

            switch (command)
            {
                case "AddProduct": AddProduct(parametersStr); break;
                case "DeleteProducts": DeleteProducts(parametersStr); break;
                case "FindProductsByName": FindProductsByName(parametersStr); break;
                case "FindProductsByProducer": FindProductsByProducer(parametersStr); break;
                case "FindProductsByPriceRange": FindProductsByPriceRange(parametersStr); break;
                default: Console.WriteLine("Wrong Command");
                    break;
            }
        }

        private static void DeleteProducts(string parameter)
        {
            string[] parameters = parameter.Split(';');
            string result = string.Empty;
            if (parameters.Length > 1)
            {
                result = shoppingCenter.Delete(parameters[0], parameters[1]); 
            }
            else
            {
                result = shoppingCenter.Delete(parameters[0]); 
            }

            Console.WriteLine(result);
        }

        private static void FindProductsByPriceRange(string parameter)
        {
            string[] parameters = parameter.Split(';');
            var result = shoppingCenter.Find(decimal.Parse(parameters[0]), decimal.Parse(parameters[1]));
            Console.WriteLine(result);
        }

        private static void FindProductsByProducer(string parameter)
        {
            var result = shoppingCenter.FindByProducer(parameter);
            Console.WriteLine(result);
        }

        private static void FindProductsByName(string parameter)
        {
            var result = shoppingCenter.FindByName(parameter);
            Console.WriteLine(result);
        }

        private static void AddProduct(string parameter)
        {
            string[] parameters = parameter.Split(';');

            var result = shoppingCenter.Add(parameters[0], parameters[2], decimal.Parse(parameters[1]));
            Console.WriteLine(result);
        }
    }
}
