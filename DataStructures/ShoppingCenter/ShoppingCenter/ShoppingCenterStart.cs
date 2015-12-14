namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShoppingCenterStart
    {
        private static ShoppingCenterFast shoppingCenter = new ShoppingCenterFast();

        static void Main()
        {
            int numberOfCommand = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommand; i++)
            {
                string commandLine = Console.ReadLine();

                ProcessCommand(commandLine);
            }
        }

        private static void ProcessCommand(string commandLine)
        {
            int endOfCommand = commandLine.IndexOf(' ');
            string command = commandLine.Substring(0, endOfCommand);
            string parametersStr = commandLine.Substring(endOfCommand + 1);
            string[] parameters = parametersStr.Split(';');

            switch (command)
            {
                case "AddProduct":
                    string result = AddProductToShoppingCenter(parameters);
                    Console.WriteLine(result);
                    break;
                case "DeleteProducts":
                    result = DeleteProductsFromShoppingCenter(parameters);
                    Console.WriteLine(result);
                    break;
                case "FindProductsByName":
                    result = FindProductsFromShoppingCenterByName(parameters);
                    Console.WriteLine(result);
                    break;
                case "FindProductsByProducer":
                    result = FindProductsFromShoppingCenterByProducer(parameters);
                    Console.WriteLine(result);
                    break;
                case "FindProductsByPriceRange":
                    result = FindProductsFromShoppingCenterByPriceRange(parameters);
                    Console.WriteLine(result);
                    break;
                default:
                    Console.WriteLine("Incorect command");
                    break;
            }
        }

        private static string FindProductsFromShoppingCenterByPriceRange(string[] parameters)
        {
            decimal start = decimal.Parse(parameters[0]);
            decimal end = decimal.Parse(parameters[1]);
            return shoppingCenter.FindProductsByPriceRange(start, end);
        }

        private static string FindProductsFromShoppingCenterByName(string[] parameters)
        {
            return shoppingCenter.FindProductsByName(parameters[0]);
        }

        private static string FindProductsFromShoppingCenterByProducer(string[] parameters)
        {
            return shoppingCenter.FindProductsByProducer(parameters[0]);
        }

        private static string DeleteProductsFromShoppingCenter(string[] parameters)
        {
            if (parameters.Length == 1)
            {
                return shoppingCenter.Delete(parameters[0], null);
            }

            return shoppingCenter.Delete(parameters[1], parameters[0]);
        }

        private static string AddProductToShoppingCenter(string[] parameters)
        {
            string name = parameters[0];
            string producer = parameters[2];
            decimal price = decimal.Parse(parameters[1]);

            return shoppingCenter.Add(name, producer, price);
        }
    }
}
