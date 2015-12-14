namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ShoppingCenterFast : IShoppingCenter
    {
        private const string AddedProduct = "Product added";
        private const string NoProductsFound = "No products found";
        private const string XProductsDeleted = " products deleted";

        //private readonly MultiDictionary<string, OrderedBag<Product>> productsByName = new MultiDictionary<string, OrderedBag<Product>>(true);
        //private readonly MultiDictionary<string, OrderedBag<Product>> productsByProducer = new MultiDictionary<string, OrderedBag<Product>>(true);
        //private readonly MultiDictionary<decimal, OrderedBag<Product>> productsByPriceRange = new MultiDictionary<decimal, OrderedBag<Product>>(true);
        private readonly Dictionary<string, OrderedBag<Product>> productsByName = new Dictionary<string, OrderedBag<Product>>();
        private readonly Dictionary<string, OrderedBag<Product>> productsByProducer = new Dictionary<string, OrderedBag<Product>>();
        private readonly OrderedDictionary<decimal, OrderedBag<Product>> productsByPriceRange = new OrderedDictionary<decimal, OrderedBag<Product>>();
        
        public string Add(string name, string producer, decimal price)
        {
            var product = new Product()
            {
                Name = name,
                Producer = producer,
                Price = price
            };
            
            // Add product to products by name
            this.productsByName.AppendValueToKey(name, product);
            // Add product to products by producer
            this.productsByProducer.AppendValueToKey(producer, product);
            // Add product to products by price
            this.productsByPriceRange.AppendValueToKey(price, product);

            return AddedProduct;
        }

        public string Delete(string producer, string name)
        {
            int countProducts = 0;
            if (name != null)
            {
                var deleteByName = this.productsByName.GetValuesForKey(name);
                deleteByName = deleteByName.Where(p => p.Producer == producer);
                var deleteByProducer = this.productsByProducer.GetValuesForKey(producer);
                deleteByProducer = deleteByProducer.Where(p => p.Name == name);
                if (deleteByProducer.Any() || deleteByName.Any())
                {
                    var productsToDelete = new Set<Product>(deleteByName);
                    productsToDelete.AddMany(deleteByProducer);
                    foreach (var product in productsToDelete)
                    {
                        this.productsByProducer[product.Producer].RemoveAllCopies(product);
                        this.productsByPriceRange[product.Price].RemoveAllCopies(product);
                        this.productsByName[product.Name].RemoveAllCopies(product);
                        countProducts++;
                    }
  
                    return countProducts + XProductsDeleted;
                }
            }
            else
            {
                var productsToDelete = this.productsByProducer.GetValuesForKey(producer);
                if (productsToDelete.Any())
                {
                    foreach (var product in productsToDelete)
                    {
                        this.productsByName[product.Name].RemoveAllCopies(product);
                        this.productsByPriceRange[product.Price].RemoveAllCopies(product);
                        countProducts++;
                    }
                    this.productsByProducer.Remove(producer);

                    return countProducts + XProductsDeleted;
                }
            }

            return NoProductsFound;
        }

        public string FindProductsByName(string name)
        {
            var products = this.productsByName.GetValuesForKey(name);

            return PrintProducts(products);
        }

        public string FindProductsByProducer(string producer)
        {
            var products = this.productsByProducer.GetValuesForKey(producer);

            return PrintProducts(products);
        }

        public string FindProductsByPriceRange(decimal start, decimal end)
        {
            var products = new List<Product>();
            var productsGroup = this.productsByPriceRange.Range(start, true, end, true).Values;
            foreach (var productsByPrice in productsGroup)
            {
                products.AddRange(productsByPrice);
            }
            if (products.Any())
            {
                products.Sort();
                return PrintProducts(products);
            }

            return NoProductsFound;
        }

        private static string PrintProducts(IEnumerable<Product> products)
        {
            if (products.Any())
            {
                StringBuilder result = new StringBuilder();
                foreach (var product in products)
                {
                    result.AppendLine(product.ToString());
                }

                return result.ToString().TrimEnd();
            }

            return NoProductsFound;
        }
    }
}