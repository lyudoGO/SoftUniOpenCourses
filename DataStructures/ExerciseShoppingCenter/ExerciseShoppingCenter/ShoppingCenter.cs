namespace ExerciseShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ShoppingCenter
    {
        private readonly Dictionary<string, OrderedBag<Product>> productsByName = new Dictionary<string, OrderedBag<Product>>();
        private readonly Dictionary<string, OrderedBag<Product>> productsByProducer = new Dictionary<string, OrderedBag<Product>>();
        private readonly OrderedDictionary<decimal, OrderedBag<Product>> productsByPrice = new OrderedDictionary<decimal, OrderedBag<Product>>();

        public string Add(string name, string producer, decimal price)
        {
            var product = new Product()
            {
                Name = name,
                Producer = producer,
                Price = price
            };

            this.productsByName.AppendValueToKey(name, product);
            this.productsByProducer.AppendValueToKey(producer, product);
            this.productsByPrice.AppendValueToKey(price, product);

            return "Product added";
        }

        public string Delete(string producer)
        {
            var products = this.productsByProducer.GetValuesForKey(producer);
            int count = 0;
            if (products.Any())
            {
                foreach (var product in products)
                {
                    this.productsByName[product.Name].RemoveAllCopies(product);
                    this.productsByPrice[product.Price].RemoveAllCopies(product);
                    count++;
                }
                this.productsByProducer.Remove(producer);

                return count + " products deleted";
            }

            return "No products found";
        }

        public string Delete(string name, string producer)
        {
            var productsByProducer = this.productsByProducer.GetValuesForKey(producer);
            var productsByName = this.productsByName.GetValuesForKey(name);
            int count = 0;
            if (productsByProducer.Any() || productsByName.Any())
            {
                var deleteByProducer = productsByProducer.Where(p => p.Name == name);
                var deleteByName = productsByName.Where(p => p.Producer == producer);
                var products = new Set<Product>(deleteByProducer);
                products.AddMany(deleteByName);
                foreach (var product in products)
                {
                    this.productsByName[product.Name].RemoveAllCopies(product);
                    this.productsByProducer[product.Producer].RemoveAllCopies(product);
                    this.productsByPrice[product.Price].RemoveAllCopies(product);
                    count++;
                }

                return count + " products deleted";
            }

            return "No products found";
        }

        public string FindByProducer(string producer)
        {
            var products = this.productsByProducer.GetValuesForKey(producer);

            return PrintProducts(products);
        }

        public string FindByName(string name)
        {
            var products = this.productsByName.GetValuesForKey(name);

            return PrintProducts(products);
        }

        public string Find(decimal start, decimal end)
        {
            var productsInRange = this.productsByPrice.Range(start, true, end, true).Values;
            var products = new OrderedBag<Product>();
            foreach (var productByPrice in productsInRange)
            {
                products.AddMany(productByPrice);
            }

            return PrintProducts(products);
        }

        private string PrintProducts(IEnumerable<Product> products)
        {
            if (!products.Any())
            {
                return "No products found";
            }

            var result = new StringBuilder();
            foreach (var product in products)
            {
                result.AppendLine(product.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
