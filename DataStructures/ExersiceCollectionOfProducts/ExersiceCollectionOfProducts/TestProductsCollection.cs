using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExersiceCollectionOfProducts
{
    class TestProductsCollection
    {
        static void Main()
        {
            StreamReader reader = new StreamReader(@"..\..\..\input.txt");
            StreamWriter writer = new StreamWriter(@"..\..\..\output.txt");
            var products = new ProductsCollection();
            using (reader)
            {
                string inputLine = reader.ReadLine();
                while (inputLine != null)
                {
                    string[] parameters = inputLine.Split(';');
                    products.Add(parameters[0], parameters[1], decimal.Parse(parameters[2]));
                    inputLine = reader.ReadLine();
                }
            }

            //using (writer)
            //{
            //    var foundBySupplier = products.Find("Lenovo", 500, 4000);
            //    foreach (var item in foundBySupplier)
            //    {
            //        writer.WriteLine(string.Format("{0};{1};{2}", item.Title, item.Supplier, item.Price.ToString("0.00")));
            //    }
            //}

            using (writer)
            {
                var foundProducts = products.Find(3000, 4000);
                foreach (var item in foundProducts)
                {
                    writer.WriteLine(string.Format("{0};{1};{2}", item.Title, item.Supplier, item.Price.ToString("0.00")));
                }
            }
        }
    }
}
