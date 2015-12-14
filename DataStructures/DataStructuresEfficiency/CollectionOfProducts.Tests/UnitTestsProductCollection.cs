namespace CollectionOfProducts.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTestsProductCollection
    {
        private ProductCollection products;

        [TestInitialize]
        public void TestInitialize()
        {
            this.products = new ProductCollection();
        }

        [TestMethod]
        public void AddProduct_ShouldWorkCorrectly()
        {
            // Arrange

            // Act
            this.products.Add("Laptop", "Asus", 1150M);

            // Assert
            Assert.AreEqual(1, this.products.Count);
        }


        [TestMethod]
        public void AddProduct_DuplicatedId_ShouldWorkCorrectly()
        {
            // Arrange

            // Act
            this.products.Add("Laptop", "Asus", 1150M);
            this.products.Add("Laptop", "DELL", 1550M, 1);

            // Assert
            Assert.AreEqual(1, this.products.Count);
            var suppliers = this.products.Find("Laptop").ToList();
            Assert.AreEqual("DELL", suppliers[0].Supplier);
        }

        [TestMethod]
        public void FindProduct_ExistingProduct_ShouldReturnProduct()
        {
            // Arrange
            this.products.Add("BMW 325i", "BMW", 12500M);

            // Act
            var product = this.products.Find("BMW 325i");

            // Assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void FindProduct_NotExistingProduct_ShouldReturnNothing()
        {
            // Arrange
            this.products.Add("BMW 325i", "BMW", 12500M);

            // Act
            var product = this.products.Find("BMW 755d").ToList();

            // Assert
            Assert.AreEqual(0, product.Count);
        }

        [TestMethod]
        public void RemoveProduct_ShouldWorkCorrectly()
        {
            // Arrange
            this.products.Add("BMW 325i", "BMW", 12500M);

            // Act
            var isDeletedExisting =
                this.products.Remove(1);
            var isDeletedNonExisting =
                this.products.Remove(1);

            // Assert
            Assert.IsTrue(isDeletedExisting);
            Assert.IsFalse(isDeletedNonExisting);
            Assert.AreEqual(0, products.Count);
        }

        [TestMethod]
        public void FindProductsByTitle_ShouldReturnMatchingProducts()
        {
            // Arrange
            this.products.Add("Laptop 1", "ASUS", 999M);
            this.products.Add("Laptop 2", "DELL", 1199M);
            this.products.Add("Laptop 3", "HP", 1099M);

            // Act
            var productsOne = this.products.Find("Laptop 1");
            var productsTwo = this.products.Find("Laptop 2");
            var productsNothing = this.products.Find("Laptop 333");

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "Laptop 1" },
                productsOne.Select(p => p.Title).ToList());
            CollectionAssert.AreEqual(
                new string[] { "Laptop 2" },
                productsTwo.Select(p => p.Title).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                productsNothing.Select(p => p.Title).ToList());
        }

        [TestMethod]
        public void FindProductsByTitleAndPrice_ShouldReturnMatchingProducts()
        {
            // Arrange
            this.products.Add("Laptop 1", "ASUS", 999M);
            this.products.Add("Laptop 2", "DELL", 1199M);
            this.products.Add("Laptop 1", "DELL", 999M);
            this.products.Add("Laptop 4", "HP", 1099M);

            // Act
            var productsOne = this.products.Find("Laptop 1", 999M);
            var productsTwo = this.products.Find("Laptop 2", 1199M);
            var productsThree = this.products.Find("Laptop 1", 999M);
            var productsNothing = this.products.Find("Laptop 333", 333M);

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "Laptop 1", "Laptop 1" },
                productsOne.Select(p => p.Title).ToList());
            CollectionAssert.AreEqual(
                new string[] { "Laptop 2" },
                productsTwo.Select(p => p.Title).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                productsNothing.Select(p => p.Title).ToList());
        }

        [TestMethod]
        public void FindProductsBySupplierAndPrice_ShouldReturnMatchingProducts()
        {
            // Arrange
            this.products.Add("Laptop 1", "ASUS", 999M);
            this.products.Add("Laptop 2", "DELL", 1199M);
            this.products.Add("Laptop 3", "DELL", 1199M);
            this.products.Add("Laptop 4", "HP", 1099M);

            // Act
            var productsOne = this.products.Find("DELL", 1199M);
            var productsTwo = this.products.Find("ASUS", 999M);
            var productsThree = this.products.Find("HP", 1099M);
            var productsNothing = this.products.Find("Linuxino", 333M);

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "DELL", "DELL" },
                productsOne.Select(p => p.Supplier).ToList());
            CollectionAssert.AreEqual(
                new string[] { "ASUS" },
                productsTwo.Select(p => p.Supplier).ToList());
            CollectionAssert.AreEqual(
                new string[] { "HP" },
                productsThree.Select(p => p.Supplier).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                productsNothing.Select(p => p.Supplier).ToList());
        }

        [TestMethod]
        public void FindProductsByPriceRange_ShouldReturnMatchingProducts()
        {
            // Arrange
            this.products.Add("Laptop 1", "ASUS", 999M);
            this.products.Add("Laptop 2", "LENOVO", 1199M);
            this.products.Add("Laptop 3", "DELL", 799M);
            this.products.Add("Laptop 4", "HP", 1099M);

            // Act
            var productsOne = this.products.Find(500M, 1200M);
            var productsTwo = this.products.Find(799M, 999M);
            var productsNothing = this.products.Find(100M, 333M);

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "ASUS", "LENOVO", "DELL", "HP" },
                productsOne.Select(p => p.Supplier).ToList());
            CollectionAssert.AreEqual(
                new string[] { "ASUS", "DELL" },
                productsTwo.Select(p => p.Supplier).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                productsNothing.Select(p => p.Supplier).ToList());
        }

        [TestMethod]
        public void FindProductsByPriceRangeAndName_ShouldReturnMatchingProducts()
        {
            // Arrange
            this.products.Add("Laptop 1", "ASUS", 999M);
            this.products.Add("Laptop 2", "LENOVO", 1199M);
            this.products.Add("Laptop 3", "DELL", 799M);
            this.products.Add("Laptop 4", "HP", 1099M);
            this.products.Add("Laptop 5", "ASUS", 899M);

            // Act
            var productsOne = this.products.Find("ASUS", 500M, 1200M);
            var productsTwo = this.products.Find("DELL", 799M, 999M);
            var productsNothing = this.products.Find("NoName", 799M, 1199M);

            // Assert
            CollectionAssert.AreEqual(
                new string[] { "ASUS", "ASUS" },
                productsOne.Select(p => p.Supplier).ToList());
            CollectionAssert.AreEqual(
                new string[] { "DELL" },
                productsTwo.Select(p => p.Supplier).ToList());
            CollectionAssert.AreEqual(
                new string[] { },
                productsNothing.Select(p => p.Supplier).ToList());
        }

        [TestMethod]
        public void FindRemovedProducts_ShouldReturnEmptyCollection()
        {
            // Arrange
            this.products.Add("Laptop 1", "ASUS", 999M);
            this.products.Add("Laptop 2", "LENOVO", 1199M);
            this.products.Add("Laptop 3", "DELL", 799M);
            this.products.Add("Laptop 4", "HP", 1099M);
            this.products.Add("Laptop 5", "ASUS", 899M);

            this.products.Remove(1);
            this.products.Remove(2);
            this.products.Remove(3);
            this.products.Remove(4);
            this.products.Remove(5);
 

            // Act
            var productsOne = this.products.Find("Laptop 1");
            var productsLenovo = this.products.Find("LENOVO", 1199M);
            var productsInAllRange = this.products.Find(799M, 1199M);
            var productsByTitleAndRange = this.products.Find("Laptop 2", 799M, 1199M);
            var productsBySupplierAndRange = this.products.Find("HP", 799M, 1199M);

            // Assert
            Assert.AreEqual(0, productsOne.Count());
            Assert.AreEqual(0, productsLenovo.Count());
            Assert.AreEqual(0, productsInAllRange.Count());
            Assert.AreEqual(0, productsByTitleAndRange.Count());
            Assert.AreEqual(0, productsBySupplierAndRange.Count());
        }
    }
}
