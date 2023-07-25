namespace INStock.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using INStock.Contracts;

    [TestFixture]
    public class ProductStockTests
    {
        private const string Label = "Label";
        private const decimal Price = 5.5m;
        private const int Quantity = 11;

        private IProduct testProduct;
        private IProductStock productStock;

        [SetUp]
        public void SetUp()
        {
            this.testProduct = new Product(Label, Price, Quantity);
            this.productStock = new ProductStock
            {
                this.testProduct
            };
        }

        [Test]
        public void AddAddsTheProduct()
        {
            Assert.AreEqual(this.testProduct, this.productStock[0]);
        }

        [Test]
        public void AddThrowsExceptionIfTheProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.productStock.Add(null);
            });
        }

        [Test]
        public void AddThrowsExceptionIfAProductWIthTheSameLabelAlreadyExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.productStock.Add(new Product(Label, Price + 1, Quantity + 1));
            });
        }

        [Test]
        public void ContainsReturnsThatTheProductIsInStock()
        {
            var product = new Product(Label, Price, Quantity);

            var exists = this.productStock.Contains(product);

            Assert.IsTrue(exists);
        }

        [Test]
        public void ContainsReturnsThatTheProductIsNotInStock()
        {
            var unexistentLabel = "notExistingLabel";
            var product = new Product(unexistentLabel, Price, Quantity);

            var exists = this.productStock.Contains(product);

            Assert.IsFalse(exists);
        }

        [Test]
        public void ContainsThrowsExceptionIfTheProductIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.productStock.Contains(null);
            });
        }

        [Test]
        public void CountReturnsTheCountOfProductsInStock()
        {
            var expected = 1;

            Assert.AreEqual(expected, this.productStock.Count);
        }

        [Test]
        public void CountReturnZeroWhenTheStockIsEmpty()
        {
            var productStock = new ProductStock();
            var expected = 0;

            Assert.AreEqual(expected, productStock.Count);
        }

        [Test]
        public void FindFindsTheItemAtTheIndex()
        {
            var foundProduct = this.productStock.Find(0);

            Assert.AreEqual(this.testProduct, foundProduct);
        }

        [Test]
        public void FindThrowsExceptionIfTheIndexIsNegative()
        {
            var negativeIndex = -1;

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock.Find(negativeIndex);
            });
        }

        [Test]
        public void FindThrowsExceptionIfTheIndexIsGreaterThanTheNumberOfProducts()
        {
            var tooBigIndex = 1;

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock.Find(tooBigIndex);
            });
        }

        [Test]
        public void FindByLabelReturnsThePRoductWithThatLabel()
        {
            var foundProduct = this.productStock.FindByLabel(Label);

            Assert.AreEqual(this.testProduct, foundProduct);
        }

        [Test]
        public void FindByLabelThrowsExceptionIfTheLabelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.productStock.FindByLabel(null);
            });
        }

        [Test]
        public void FindByLabelThrowsExceptionIfTheProductIsNotFound()
        {
            var notExistingLabel = "norExistiongLabel";

            Assert.Throws<ArgumentException>(() =>
            {
                this.productStock.FindByLabel(notExistingLabel);
            });
        }

        [Test]
        public void FindAllInRangeReturnsAllTheProductsInTheRange()
        {
            this.AddTestRangeProducts();

            var foundProducts = this.productStock.FindAllInRange(3, 5)
                                                 .ToArray();

            Assert.AreEqual("4", foundProducts[0].Label);
            Assert.AreEqual("2", foundProducts[1].Label);
            Assert.AreEqual("3", foundProducts[2].Label);
        }

        [Test]
        public void FindAllInRangeReturnsEmptyCollectionWhenNoMatches()
        {
            var productsFound = this.productStock.FindAllInRange(100, 101);

            Assert.IsEmpty(productsFound);
        }

        [Test]
        public void FindAllByPriceReturnsTheProductsWithExactlyThatPrice()
        {
            this.AddTestRangeProducts();

            var price = 6;
            var productsFound = this.productStock.FindAllByPrice(price)
                                                 .ToArray();

            Assert.AreEqual("5", productsFound[0].Label);
            Assert.AreEqual("6", productsFound[1].Label);
            Assert.AreEqual("8", productsFound[2].Label);
        }

        [Test]
        public void FindAllByPriceReturnsEmptyCollectionIfNoMatches()
        {
            var foundProducts = this.productStock.FindAllByPrice(100);

            Assert.IsEmpty(foundProducts);
        }

        [Test]
        public void FindTheMostExpensiveProduct()
        {
            this.AddTestRangeProducts();

            var foundProduct = this.productStock.FindMostExpensiveProduct();

            Assert.AreEqual("7", foundProduct.Label);
        }

        [Test]
        public void FindTheMostExpensiveThrowsExceptionOnEmpyCollection()
        {
            var emptyStock = new ProductStock();

            Assert.Throws<InvalidOperationException>(() =>
            {
                emptyStock.FindMostExpensiveProduct();
            });
        }

        [Test]
        public void FindAllByQuantityReturnsTheProductsWithThatQuantity()
        {
            this.AddTestRangeProducts();

            var quantity = 2;
            var foundProducts = this.productStock.FindAllByQuantity(quantity)
                                                 .ToArray();

            Assert.AreEqual("2", foundProducts[0].Label);
            Assert.AreEqual("8", foundProducts[1].Label);
        }

        [Test]
        public void FindAllByQuanityReturnEmptyCollectionIfNoMatchesAreFound()
        {
            var foundProducts = this.productStock.FindAllByQuantity(0);

            Assert.IsEmpty(foundProducts);
        }

        [Test]
        public void RemoveRemovesTheItemSuccessFully()
        {
            var success = this.productStock.Remove(new Product(Label, Price, Quantity));

            Assert.IsTrue(success);
        }

        [Test]
        public void RemoveItemNotsuccessfully()
        {
            var notExistingProduct = new Product("Notexisting", 0, 0);

            var success = this.productStock.Remove(notExistingProduct);

            Assert.IsFalse(success);
        }

        [Test]
        public void RemoveThrowsExceptionIfProductIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.productStock.Remove(null);
            });
        }

        [Test]
        public void GetEnumeratorReturnsAllPRoductsInStock()
        {
            this.AddTestRangeProducts();

            var counter = 0;

            foreach (var item in this.productStock)
            {
                if (counter != 0)
                {
                    Assert.AreEqual(counter.ToString(), item.Label);
                }
            }
        }

        public void IndexerReturnsCorrectProducts()
        {
            this.AddTestRangeProducts();

            Assert.AreEqual(Label, this.productStock[0].Label);
            Assert.AreEqual("1", this.productStock[1].Label);
            Assert.AreEqual("2", this.productStock[2].Label);
            Assert.AreEqual("3", this.productStock[3].Label);
            Assert.AreEqual("4", this.productStock[4].Label);
            Assert.AreEqual("5", this.productStock[5].Label);
            Assert.AreEqual("6", this.productStock[6].Label);
            Assert.AreEqual("7", this.productStock[7].Label);
            Assert.AreEqual("8", this.productStock[8].Label);
        }

        private void AddTestRangeProducts()
        {
            this.productStock = new ProductStock
            {
                new Product("1", 2, 1),
                new Product("2", 4, 2),
                new Product("3", 3, 1),
                new Product("4", 5, 1),
                new Product("5", 6, 1),
                new Product("6", 6, 1),
                new Product("7", 10, 1),
                new Product("8", 6, 2)
            };
        }
    }
}
