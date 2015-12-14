namespace CollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class ProductCollection : CollectionOfProducts.IProductCollection
    {
        private uint id;
        private Dictionary<uint, Product> productsById;
        private OrderedDictionary<decimal, SortedSet<Product>> productsByPrice;
        private Dictionary<string, SortedSet<Product>> productsByDescription;
        private Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>> productsByDescriptionAndPriceRange;

        public ProductCollection()
        {
            this.productsById = new Dictionary<uint, Product>();
            this.productsByPrice = new OrderedDictionary<decimal, SortedSet<Product>>();
            this.productsByDescription = new Dictionary<string, SortedSet<Product>>();
            this.productsByDescriptionAndPriceRange = new Dictionary<string, OrderedDictionary<decimal, SortedSet<Product>>>();
            this.id = 0;
        }

        public int Count 
        {
            get { return this.productsById.Count; } 
        }

        public void Add(string title, string supplier, decimal price, uint? id = null)
        {
            Product product = new Product(title, supplier, price, id);
            if (product.Id != null)
            {
                uint currentId = (uint)product.Id;
                if (this.productsById.ContainsKey(currentId))
                {
                    var productToReplace = this.productsById[currentId];
                    this.productsById[currentId] = product;
                    this.productsByPrice[productToReplace.Price].Remove(productToReplace);
                    AddProductByPrice(product, product.Price);
                    ReplaceProductByDescription(product, productToReplace);
                    ReplaceProductByDesciptionAndPriceRange(product, productToReplace);
                }
                else
                {
                    product.Id = ++this.id;
                    this.productsById.Add(this.id, product); // Add product by Id
                    AddProductByPrice(product, product.Price); // Add product by price
                    AddProductByDescription(product, product.Title, null); // Add product by title
                    AddProductByDescription(product, product.Title, product.Price); // Add product by title + price
                    AddProductByDescription(product, product.Supplier, product.Price); // Add product by supplier + price
                    AddProductByDescriptionAndPriceRange(product, product.Title, product.Price); // Add product by title + price range
                    AddProductByDescriptionAndPriceRange(product, product.Supplier, product.Price); // Add product by supplier + price range
                }
            }
            else
            {
                product.Id = ++this.id;
                this.productsById.Add(this.id, product);
                AddProductByPrice(product, product.Price);
                AddProductByDescription(product, product.Title, null);
                AddProductByDescription(product, product.Title, product.Price);
                AddProductByDescription(product, product.Supplier, product.Price);
                AddProductByDescriptionAndPriceRange(product, product.Title, product.Price);
                AddProductByDescriptionAndPriceRange(product, product.Supplier, product.Price);
            }
        }

        public bool Remove(uint id)
        {
            if (this.productsById.ContainsKey(id))
            {
                var productToRemove = this.productsById[id];
                this.productsById.Remove(id);
                this.productsByPrice[productToRemove.Price].Remove(productToRemove);
                RemoveProductFromProductsByDescription(productToRemove);
 
                return true;
            }

            return false;
        }

        public IEnumerable<Product> Find(string title)
        {
            var result = new SortedSet<Product>();
            if (this.productsByDescription.ContainsKey(title))
            {
                result = this.productsByDescription[title];
            }
            
            return result;
        }

        public IEnumerable<Product> Find(string name, decimal price)
        {
            string keyName = ExtractName(name, price);
            var result = new SortedSet<Product>();
            if (this.productsByDescription.ContainsKey(keyName))
            {
                result = this.productsByDescription[keyName];
            }

            return result;
        }

        public IEnumerable<Product> Find(decimal start, decimal end)
        {
            var result = new SortedSet<Product>();
            var productsInRange = this.productsByPrice.Range(start, true, end, true);
            foreach (var productByPrice in productsInRange)
            {
                foreach (var product in productByPrice.Value)
                {
                    result.Add(product);
                }
            }

            return result;
        }

        public IEnumerable<Product> Find(string name, decimal start, decimal end)
        {
            var dic = new OrderedDictionary<decimal, SortedSet<Product>>();
            var result = new SortedSet<Product>();
            if (this.productsByDescriptionAndPriceRange.ContainsKey(name))
            {
                dic = this.productsByDescriptionAndPriceRange[name];
                var productsInRange = dic.Range(start, true, end, true);
                foreach (var productByName in productsInRange)
                {
                    foreach (var product in productByName.Value)
                    {
                        result.Add(product);
                    }
                }
            }

            return result;
        }

        private void AddProductByPrice(Product product, decimal price)
        {

            SortedSet<Product> products;
            if (!this.productsByPrice.TryGetValue(price, out products))
            {
                this.productsByPrice.Add(price, products = new SortedSet<Product>());
            }
            products.Add(product);
        }

        private void AddProductByDescription(Product product, string name, decimal? price = null)
        {
            if (price != null)
            {
                name = name + "#" + price;
            }

            SortedSet<Product> products;
            if (!this.productsByDescription.TryGetValue(name, out products))
            {
                this.productsByDescription.Add(name, products = new SortedSet<Product>());
            }
            products.Add(product);
        }

        private void AddProductByDescriptionAndPriceRange(Product product, string name, decimal price)
        {
            OrderedDictionary<decimal, SortedSet<Product>> productsByPrice;

            if (!this.productsByDescriptionAndPriceRange.ContainsKey(name))
            {
                this.productsByDescriptionAndPriceRange.Add(name, productsByPrice = new OrderedDictionary<decimal, SortedSet<Product>>());
            }

            SortedSet<Product> products;
            if (!this.productsByDescriptionAndPriceRange[name].TryGetValue(price, out products))
            {
                this.productsByDescriptionAndPriceRange[name].Add(price, products = new SortedSet<Product>());
            }
            products.Add(product);
        }

        private void RemoveProductFromProductsByDescription(Product productToRemove)
        {
            // Remove product from products by title, title/supplier + price
            string titleAndPrice = ExtractName(productToRemove.Title, productToRemove.Price);
            string supplierAndPrice = ExtractName(productToRemove.Supplier, productToRemove.Price); 
            foreach (var pair in this.productsByDescription)
            {
                if (pair.Key == productToRemove.Title || pair.Key == titleAndPrice ||
                    pair.Key == supplierAndPrice)
                {
                    this.productsByDescription[pair.Key].Remove(productToRemove);
                }
            }

            // Remove product from products by title/supplier + price range
            foreach (var pair in this.productsByDescriptionAndPriceRange)
            {
                if (pair.Key == productToRemove.Title || pair.Key == productToRemove.Supplier)
                {
                    foreach (var otherPair in pair.Value)
                    {
                        if (otherPair.Key == productToRemove.Price)
                        {
                            this.productsByDescriptionAndPriceRange[pair.Key][otherPair.Key].Remove(productToRemove);
                        }
                    }
                }
            }
        }

        private void ReplaceProductByDesciptionAndPriceRange(Product product, Product productToReplace)
        {
            string title = productToReplace.Title;
            string supplier = productToReplace.Supplier;
            decimal price = productToReplace.Price;
            foreach (var pair in productsByDescriptionAndPriceRange)
            {
                if (pair.Key == title || pair.Key == supplier)
                {
                    this.productsByDescriptionAndPriceRange[pair.Key][price].Remove(productToReplace);
                }
            }
            AddProductByDescriptionAndPriceRange(product, product.Title, product.Price);
            AddProductByDescriptionAndPriceRange(product, product.Supplier, product.Price);
        }

        private void ReplaceProductByDescription(Product product, Product productToReplace)
        {
            string title = productToReplace.Title;
            string supplier = productToReplace.Supplier;
            string titleAndPrice = ExtractName(productToReplace.Title, productToReplace.Price);
            string supplierAndPrice = ExtractName(productToReplace.Supplier, productToReplace.Price);
            foreach (var pair in productsByDescription)
            {
                if (pair.Key == title || pair.Key == supplier || pair.Key == titleAndPrice || pair.Key == supplierAndPrice)
                {
                    this.productsByDescription[pair.Key].Remove(productToReplace);
                }
            }
            AddProductByDescription(product, product.Title);
            AddProductByDescription(product, product.Title, product.Price);
            AddProductByDescription(product, product.Supplier, product.Price);
        }

        private string ExtractName(string name, decimal price)
        {
            return name + "#" + price;
        }
    }
}