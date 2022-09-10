namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        // Valid Labels
        private const string ValidLabel = "ValidLabel";

        //Invalid Labels 
        private const string NullLabel = null;
        private const string EmptyLabel = "";
        private const string WhitespaceLabel = "  ";

        //Valid prices
        private const decimal ValidPriceZero = 0.0m;
        private const decimal ValidPriceNormal = 5.5m;

        //Invalid Prices
        private const decimal NegativePrice = -1.0m;

        //Valid Quantities
        private const int ValidQuantityZero = 0;
        private const int ValidQuantityNormal = 15;

        //Invalid Quantities
        private const int NegativeQuantity = -1;


        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ConstructorSetsTheCorrectValues()
        {
            //Act
            var product = new Product(ValidLabel, ValidPriceNormal, ValidQuantityNormal);

            //Assert
            Assert.AreEqual(ValidLabel, product.Label);
            Assert.AreEqual(ValidPriceNormal, product.Price);
            Assert.AreEqual(ValidQuantityNormal, product.Quantity);
        }

        [Test]
        public void ConstructorSetsTheCorrectValuesEdgeCase()
        {
            //Act
            var product = new Product(ValidLabel, ValidPriceZero, ValidQuantityZero);

            //Assert
            Assert.AreEqual(ValidLabel, product.Label);
            Assert.AreEqual(ValidPriceZero, product.Price);
            Assert.AreEqual(ValidQuantityZero, product.Quantity);
        }

        [Test]
        public void LebelSetterThrowsExceptionIfValueIsNull()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _ = new Product(NullLabel, ValidPriceNormal, ValidQuantityNormal);
            });
        }

        [Test]
        public void LabelSetterThrowsExceptionIfValueIsEmpty()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _ = new Product(EmptyLabel, ValidPriceNormal, ValidQuantityNormal);
            });
        }

        [Test]
        public void LabelSetterThrowsExceptionIfValueIsWhitespace()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _ = new Product(WhitespaceLabel, ValidPriceNormal, ValidQuantityNormal);
            });
        }

        [Test]
        public void PriceSetterThrowsExceptionIfValueIsNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _ = new Product(ValidLabel, NegativePrice, ValidQuantityNormal);
            });
        }

        [Test]
        public void QuantitySetterThrowsExceptionIfValueIsNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _ = new Product(ValidLabel, ValidPriceNormal, NegativeQuantity);
            });
        }

        [Test]
        public void CompareEqualElements()
        {
            var expected = 0;

            //Arange
            var firstProduct = new Product(ValidLabel, ValidPriceNormal, ValidQuantityZero);
            var secondProduct = new Product(ValidLabel, ValidPriceNormal, ValidQuantityNormal);

            //Act
            var result = firstProduct.CompareTo(secondProduct);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CompareSmallerToALargerElement()
        {
            var expected = -1;

            //Arange
            var smaller = new Product(ValidLabel, ValidPriceZero, ValidQuantityNormal);
            var larger = new Product(ValidLabel, ValidPriceNormal, ValidQuantityNormal);
            
            //Act
            var result = smaller.CompareTo(larger);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CompareLargerToASmallerElement()
        {
            var expected = 1;

            //Arange
            var larger = new Product(ValidLabel, ValidQuantityNormal, ValidQuantityNormal);
            var smaller = new Product(ValidLabel, ValidQuantityZero, ValidQuantityNormal);

            //Act
            var result = larger.CompareTo(smaller);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
