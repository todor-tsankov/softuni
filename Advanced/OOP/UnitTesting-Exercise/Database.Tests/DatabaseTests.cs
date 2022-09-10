using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private const int DatabaseCapacity = 16;
        private const int TestElement = 15;
        
        private int[] testArray;

        private Database emptyDatabase;
        private Database fullDataBase;

        [SetUp]
        public void Setup()
        {
            this.testArray = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            this.emptyDatabase = new Database();
            this.fullDataBase = new Database(this.testArray);
        }

        [Test]
        public void DatabaseCapacityMustBeExactlySixteen()
        {
            Assert.AreEqual(DatabaseCapacity, this.fullDataBase.Count);
        }

        [Test]
        public void AddOperationThrowsExceptionIfTheDatabaseIsFull()
        {
            Assert.Throws<InvalidOperationException>(() => this.fullDataBase.Add(TestElement));
        }

        [Test]
        public void AddOperationAddsTheElementInTheFirstFreeCell()
        {
            this.emptyDatabase.Add(TestElement);

            var element = this.emptyDatabase.Fetch()[0];

            Assert.AreEqual(TestElement, element);
        }

        [Test]
        public void RemoveOperationThrowsExceptionIfTheDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.emptyDatabase.Remove());
        }

        [Test]
        public void RemoveOperationRemovesTheLastElement()
        {
            this.fullDataBase.Remove();

            var lastElement = this.fullDataBase.Fetch()
                                               .ToList()
                                               .Last();

            Assert.AreEqual(TestElement, lastElement);
        }

        [Test]
        public void FetchReturnsTheElementsOfTheArray()
        {
            var fetchedElements = this.fullDataBase.Fetch();

            for (int i = 1; i < 16; i++)
            {
                Assert.AreEqual(i, fetchedElements[i - 1]);
            }
        }
    }
}