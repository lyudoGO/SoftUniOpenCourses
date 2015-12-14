namespace ExersiceCollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ProductsCollection
    {
        private int id = 0;
        private readonly Dictionary<int, Product> productsById = new Dictionary<int, Product>();
        private readonly OrderedDictionary<decimal, List<Product>> productsByPrice = new OrderedDictionary<decimal, List<Product>>();
        private readonly Dictionary<string, SortedSet<Product>> productsByTitle = new Dictionary<string, SortedSet<Product>>();
        private readonly Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByDescription = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();

        public bool Add(string title, string supplier, decimal price)
        {
            this.id++;

            var product = new Product()
            {
                Price = price,
                Supplier = supplier,
                Title = title
            };

            while (this.productsById.ContainsKey(this.id))
            {
                this.id++;
            }
            product.Id = this.id;
            this.productsById.Add(product.Id, product); // Add product by id
            this.productsByPrice.AppendValueToKey(product.Price, product); // Add product by price
            this.productsByTitle.AppendValueToKey(product.Title, product); // Add by title
            // Add product by title + price
            this.productsByDescription.EnsureKeyExists(product.Title);
            this.productsByDescription[product.Title].AppendValueToKey(product.Price, product);
            // Add product by supplier + price
            this.productsByDescription.EnsureKeyExists(product.Supplier);
            this.productsByDescription[product.Supplier].AppendValueToKey(product.Price, product);

            return true;
        }

        public bool Add(int id, string title, string supplier, decimal price)
        {
            var product = new Product()
            {
                Id = id,
                Price = price,
                Supplier = supplier,
                Title = title
            };

            this.productsById.EnsureKeyExists(id);
            this.productsById[product.Id] = product;
            this.productsByPrice.AppendValueToKey(product.Price, product);
            this.productsByTitle.AppendValueToKey(product.Title, product);
            this.productsByDescription.EnsureKeyExists(product.Title);
            this.productsByDescription[product.Title].AppendValueToKey(product.Price, product);
            this.productsByDescription.EnsureKeyExists(product.Supplier);
            this.productsByDescription[product.Supplier].AppendValueToKey(product.Price, product);

            return true;
        }

        public bool Remove(int id)
        {
            if (this.productsById.ContainsKey(id))
            {
                var product = this.productsById[id];
                this.productsById.Remove(id);
                this.productsByPrice[product.Price].Remove(product);
                this.productsByTitle[product.Title].Remove(product);
                this.productsByDescription[product.Title][product.Price].Remove(product);
                this.productsByDescription[product.Supplier][product.Price].Remove(product);

                return true;
            }

            return false;
        }

        public ICollection<Product> Find(decimal start, decimal end)
        {
            var productsResult = new SortedSet<Product>();
            var productsFound = this.productsByPrice.Range(start, true, end, true);
            foreach (var productByPrice in productsFound)
            {
                foreach (var product in productByPrice.Value)
                {
                    productsResult.Add(product);
                }
            }

            return productsResult;
        }

        public IEnumerable<Product> Find(string title)
        {
            return this.productsByTitle.GetValuesForKey(title);
        }

        public IEnumerable<Product> Find(string name, decimal price)
        {
            OrderedDictionary<decimal, SortedSet<Product>> productsByTitle;
            SortedSet<Product> result = new SortedSet<Product>();
            if (this.productsByDescription.TryGetValue(name, out productsByTitle))
	        {
                this.productsByDescription[name].TryGetValue(price, out result);
	        }
                       
            return result;
        }

        public IEnumerable<Product> Find(string name, decimal start, decimal end)
        {
            OrderedDictionary<decimal, SortedSet<Product>> productsByTitle;
            SortedSet<Product> result = new SortedSet<Product>();
            if (this.productsByDescription.TryGetValue(name, out productsByTitle))
            {
                var products = this.productsByDescription[name].Range(start, true, end, true);
                foreach (var productsByPrice in products)
                {
                    foreach (var product in productsByPrice.Value)
                    {
                        result.Add(product);
                    }
                }
            }

            return result;
        }

        public int Count 
        {
            get { return this.productsById.Count; }
        }
    }
}
