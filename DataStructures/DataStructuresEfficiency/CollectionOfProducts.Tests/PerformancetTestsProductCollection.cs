namespace CollectionOfProducts.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CollectionOfProducts;

    [TestClass]
    public class PerformancetTestsProductCollection
    {
        private ProductCollection products;

        [TestInitialize]
        public void TestInitialize()
        {
            this.products = new ProductCollection();
        }

        private void AddProduct(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.products.Add(title : "Product" + (i % 100),
                                  supplier : "Supplier" + (i % 100),
                                  price: (i % 100) + 0.5M);
            }
        }

        [TestMethod]
        [Timeout(200)]
        public void TestPerformance_AddProduct()
        {
            // Act
            AddProduct(5000);
            Assert.AreEqual(5000, this.products.Count);
        }

        [TestMethod]
        [Timeout(200)]
        public void TestPerformance_FindProductByTitle()
        {
            // Arrange
            AddProduct(5000);

            // Act
            for (int i = 0; i < 10000; i++)
            {
                var existingProducts = this.products.Find("Product10").ToList();
                Assert.AreEqual(50, existingProducts.Count);
                var notExistingProducts = this.products.Find("Empty product").ToList();
                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(200)]
        public void TestPerformance_FindProductByTitleAndPrice()
        {
            // Arrange
            AddProduct(5000);

            // Act
            for (int i = 0; i < 10000; i++)
            {
                var existingProducts = this.products.Find("Product10", 10.5M).ToList();
                Assert.AreEqual(50, existingProducts.Count);
                var notExistingProducts = this.products.Find("Empty product", 10.5M).ToList();
                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(200)]
        public void TestPerformance_FindProductBySupplierAndPrice()
        {
            // Arrange
            AddProduct(5000);

            // Act
            for (int i = 0; i < 10000; i++)
            {
                var existingProducts = this.products.Find("Supplier5", 5.5M).ToList();
                Assert.AreEqual(50, existingProducts.Count);
                var notExistingProducts = this.products.Find("Empty Supplier", 5.5M).ToList();
                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(300)]
        public void TestPerformance_FindProductByPriceRnage()
        {
            // Arrange
            AddProduct(5000);

            // Act
            for (int i = 0; i < 2000; i++)
            {
                var existingProducts = this.products.Find(7.5M, 8.5M).ToList();
                Assert.AreEqual(100, existingProducts.Count);
                var notExistingProducts = this.products.Find(-7.5M, -8.5M).ToList();
                Assert.AreEqual(0, notExistingProducts.Count);
            }
        }

        [TestMethod]
        [Timeout(300)]
        public void TestPerformance_FindProductByTitleAndPriceRnage()
        {
            // Arrange
            AddProduct(5000);

            // Act
            for (int i = 0; i < 5000; i++)
            {
                var existingProducts = this.products.Find("Product10", 7.5M, 10.5M).ToList();
                Assert.AreEqual(50, existingProducts.Count);
                var notExistingPriceRange = this.products.Find("Product10", -7.5M, -10.5M).ToList();
                Assert.AreEqual(0, notExistingPriceRange.Count);
                var notExistingPoductTitle = this.products.Find("Product empty", 7.5M, 10.5M).ToList();
                Assert.AreEqual(0, notExistingPoductTitle.Count);
            }
        }

        [TestMethod]
        [Timeout(300)]
        public void TestPerformance_FindProductBySupplierAndPriceRnage()
        {
            // Arrange
            AddProduct(5000);

            // Act
            for (int i = 0; i < 5000; i++)
            {
                var existingProducts = this.products.Find("Supplier5", 5.5M, 8.5M).ToList();
                Assert.AreEqual(50, existingProducts.Count);
                var notExistingPriceRange = this.products.Find("Supplier5", -5.5M, -8.5M).ToList();
                Assert.AreEqual(0, notExistingPriceRange.Count);
                var notExistingPoductSupplier = this.products.Find("Supplier empty", 5.5M, 8.5M).ToList();
                Assert.AreEqual(0, notExistingPoductSupplier.Count);
            }
        }

    }
}
