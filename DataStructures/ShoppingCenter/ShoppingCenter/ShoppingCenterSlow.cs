namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ShoppingCenterSlow : IShoppingCenter
    {
        private const string AddedProduct = "Product added";
        private const string NoProductsFound = "No products found";
        private const string XProductsDeleted = " products deleted";

        private List<Product> products = new List<Product>();

        public string Add(string name, string producer, decimal price)
        {
            var product = new Product()
            {
                Name = name,
                Producer = producer,
                Price = price
            };

            this.products.Add(product);

            return AddedProduct;
        }

        public string Delete(string producer, string name)
        {
            int deletedProducts = 0;
            if (name != null)
            {
                deletedProducts = this.products.RemoveAll(p => p.Producer == producer && p.Name == name);
                if (deletedProducts == 0)
                {
                    return NoProductsFound;
                }
                return deletedProducts + XProductsDeleted;
            }

            deletedProducts = this.products.RemoveAll(p => p.Producer == producer);
            if (deletedProducts == 0)
            {
                return NoProductsFound;
            }

            return deletedProducts + XProductsDeleted;
        }

        public string FindProductsByName(string name)
        {
            var products = this.products.FindAll(p => p.Name == name).OrderBy(p => p);

            return PrintProducts(products);
        }

        public string FindProductsByProducer(string producer)
        {
            var products = this.products.Where(p => p.Producer == producer).OrderBy(p => p);

            return PrintProducts(products);
        }

        public string FindProductsByPriceRange(decimal start, decimal end)
        {
            var products = this.products.FindAll(p => p.Price >= start && p.Price <= end).OrderBy(p => p);

            return PrintProducts(products);
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
