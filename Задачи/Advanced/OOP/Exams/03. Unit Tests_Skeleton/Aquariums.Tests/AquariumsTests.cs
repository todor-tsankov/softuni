namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        private const string ValidName = "toshko";
        private const string NullName = null;
        private const string EmptyName = "";

        private const int ValidCapacity = 5;
        private const int ZeroCapacity = 0;
        private const int NegativeCapacity = -1;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void FishConstructorSetsTheRightProperties()
        {
            var fish = new Fish(ValidName);

            Assert.AreEqual(ValidName, fish.Name);
            Assert.IsTrue(fish.Available);
        }

        [Test]
        public void FishNameSetterSetsTheName()
        {
            var fish = new Fish(ValidName);
            var newName = "toshko2";

            fish.Name = newName;

            Assert.AreEqual(newName, fish.Name);
            Assert.IsTrue(fish.Available);
        }

        [Test]
        public void FishAvaibleSetterSetsTheAvlialble()
        {
            var fish = new Fish(ValidName);

            fish.Available = false;

            Assert.IsFalse(fish.Available);
        }

        [Test]
        public void AquariumConstructorSetTheRightProperties()
        {
            var capacity = 5;

            var aquarium = new Aquarium(ValidName, capacity);

            Assert.AreEqual(ValidName, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void NameSetterThrowsExceptionIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Aquarium(NullName, ValidCapacity);
            });
        }

        [Test]
        public void NameSetterThrowsExceptionIfNAmeIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Aquarium(EmptyName, ValidCapacity);
            });
        }

        [Test]
        public void CapacitySetterThrowsExceptionIfTheCapacityIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Aquarium(ValidName, NegativeCapacity);
            });
        }

        [Test]
        public void AddThrowsExceptionIfTheCountIsEqaulToTheCapacity()
        {
            var aquarium = new Aquarium(ValidName, ZeroCapacity);
            var fish = new Fish(ValidName);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });
        }

        [Test]
        public void AddAddsTheFishToTheCollection()
        {
            var aquarium = new Aquarium(ValidName, ValidCapacity);
            var fish = new Fish(ValidName);

            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void RemoveThrowsExceptionIfTheFishDoesntExist()
        {
            var aquarium = new Aquarium(ValidName, ValidCapacity);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(ValidName);
            });
        }

        [Test]
        public void RemoveRemovesTheFishFromTheCollection()
        {
            var aquarium = new Aquarium(ValidName, ValidCapacity);
            var fish = new Fish(ValidName);
            aquarium.Add(fish);

            aquarium.RemoveFish(ValidName);

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void SellFishThrowsExceptionIfTheFishDoesntExist()
        {
            var aquarium = new Aquarium(ValidName, ValidCapacity);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish(ValidName);
            });
        }

        [Test]
        public void SellFishSellsTheFishWithThatName()
        {
            var aquarium = new Aquarium(ValidName, ValidCapacity);
            var fish = new Fish(ValidName);
            aquarium.Add(fish);

            aquarium.SellFish(ValidName);

            Assert.IsFalse(fish.Available);
        }

        [Test]
        public void SellFishReturnsTheRequestedFish()
        {
            var aquarium = new Aquarium(ValidName, ValidCapacity);
            var fish = new Fish(ValidName);
            aquarium.Add(fish);

            var requestedFish = aquarium.SellFish(ValidName);

            Assert.AreEqual(fish, requestedFish);
        }

        [Test]
        public void ReportWorks()
        {
            var fish = new Fish(ValidName);
            var aquarium = new Aquarium(ValidName, ValidCapacity);
            aquarium.Add(fish);
            var reportExpected = $"Fish available at {ValidName}: {ValidName}";

            var reportActual = aquarium.Report();

            Assert.AreEqual(reportExpected, reportActual);
        }

        [Test]
        public void ReportWithMultipleFish()
        {
            var name = "Toshko2";
            var fish = new Fish(ValidName);
            var fish2 = new Fish(name);
            var aquarium = new Aquarium(ValidName, ValidCapacity);
            aquarium.Add(fish);
            aquarium.Add(fish2);

            var reportActual = aquarium.Report();

            var reportExpected = $"Fish available at {ValidName}: {fish.Name}, {fish2.Name}";
            Assert.AreEqual(reportExpected, reportActual);
        }
    }
}
