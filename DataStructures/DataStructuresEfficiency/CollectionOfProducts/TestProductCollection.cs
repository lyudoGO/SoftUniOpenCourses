namespace CollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TestProductCollection
    {
        static void Main()
        {
            var products = new ProductCollection();
            products.Add("Apple", "Bulgarplod", 1.55M);
            products.Add("Apple", "T-Market", 1.30M);
            products.Add("Green Apple", "T-Market", 1.45M);
            products.Add("Yogurt", "Kaufland", 1.55M);
            products.Add("Yogurt", "T-Market", 1.55M);
            products.Add("Yogurt 2", "Kaufland", 1.55M, 4);
            products.Add("Bread", "T-Market", 1.15M);
            products.Add("Apple", "Lidl", 2.30M);
            products.Add("Cucumber", "Kaufland", 1.99M);
            products.Add("Tomato", "Lidl", 2.09M, 1000);

            var resultByTitle = products.Find("Apple");
            var resultByTitlePrice = products.Find("Bread", 1.15M);
            var resultBySupplierPrice = products.Find("Kaufland", 1.55M);
            var resultByPriceRange = products.Find(1M, 1.3M);
            var resultByTitlePriceRange = products.Find("Apple", 1.0M, 3.0M);
            var resultBySupplierPriceRange = products.Find("Kaufland", 1.0M, 3.0M);
            Console.WriteLine(products.Remove(1));
        }
    }
}
