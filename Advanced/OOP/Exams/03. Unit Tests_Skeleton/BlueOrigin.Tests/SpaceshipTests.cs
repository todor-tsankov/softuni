namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        private const string AstronautName = "Toshko";
        private const double AstronautPercentage = 15.5;

        private const string SpaceshipName = "Kaoraba maika";
        private const int Capacity = 2;

        private Astronaut astronaut;
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.astronaut = new Astronaut(AstronautName, AstronautPercentage);
            this.spaceship = new Spaceship(SpaceshipName, Capacity);
        }

        [Test]
        public void AstronautConstructorSetsTheRightProperties()
        {
            Assert.AreEqual(AstronautName, this.astronaut.Name);
            Assert.AreEqual(AstronautPercentage, this.astronaut.OxygenInPercentage);
        }

        [Test]
        public void Spaceship()
        {
            new Spaceship(SpaceshipName, Capacity);
        }

        [Test]
        public void SpaceshipconstructorInitializesTheColection()
        {
            Assert.AreEqual(0, this.spaceship.Count);
        }

        [Test]
        public void SpaceshipConstructorSetsProperties()
        {
            Assert.AreEqual(SpaceshipName, this.spaceship.Name);
            Assert.AreEqual(Capacity, this.spaceship.Capacity);
        }

        [Test]
        public void SpaceshipthrowsToNullName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Spaceship(null, Capacity);
            });
        }

        [Test]
        public void SpaceshipthrowsToEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new Spaceship(string.Empty, Capacity);
            });
        }

        [Test]
        public void SpaceshipthrowsToNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Spaceship(SpaceshipName, -1);
            });
        }

        [Test]
        public void SpaceshipthrowsToNegativeCapacity2()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Spaceship(SpaceshipName, -5);
            });
        }

        [Test]
        public void AddThrowsExceptionIfFull()
        {
            this.spaceship.Add(this.astronaut);
            this.spaceship.Add(new Astronaut("toshko2", 5));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(new Astronaut("toshko3", 6));
            });
        }

        [Test]
        public void AddThrowsIfAsttronautAlreadyAddded()
        {
            this.spaceship.Add(this.astronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.spaceship.Add(new Astronaut(AstronautName, 6));
            });
        }

        [Test]
        public void AddSuccess()
        {
            this.spaceship.Add(this.astronaut);

            Assert.AreEqual(1, this.spaceship.Count);
        }

        [Test]
        public void RemoveSuccess()
        {
            this.spaceship.Add(this.astronaut);

            var success = this.spaceship.Remove(AstronautName);

            Assert.AreEqual(0, this.spaceship.Count);
            Assert.IsTrue(success);
        }

        [Test]
        public void RemoveNotFound()
        {
            var success = this.spaceship.Remove(AstronautName);

            Assert.AreEqual(0, this.spaceship.Count);
            Assert.False(success);
        }
    }
}