namespace ProductsInPriceRange
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Globalization;
    using Wintellect.PowerCollections;

    public class ProductsInRange
    {
        static void Main()
        {
            try
            {
                OrderedMultiDictionary<decimal, string> products = new OrderedMultiDictionary<decimal, string>(true);
                
                Console.Write("Please, enter start price: ");
                decimal startPrice = decimal.Parse(Console.ReadLine().Replace(',', '.'));
                Console.Write("Please, enter end price: ");
                decimal endPrice = decimal.Parse(Console.ReadLine().Replace(',', '.'));

                string inputFile = @"..\..\products.txt";
                StreamReader inputReader = new StreamReader(inputFile);

                using (inputReader)
                {
                    string currentLine = inputReader.ReadLine();
                    while (currentLine != null)
                    {
                        string[] items = currentLine.Split('#');
                        decimal price = decimal.Parse(items[1].Trim());
                        string name = items[0].Trim();

                        products.Add(price, name);

                        currentLine = inputReader.ReadLine();
                    }
                }

                var priceRange = products.Range(startPrice, true, endPrice, true);

                Console.WriteLine("\nPrice    |       Products");
                Console.WriteLine("`````````````````````````");
                foreach (var pair in priceRange)
                {
                    Console.WriteLine("{0} lv. -> {1}", pair.Key, pair.Value);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}
