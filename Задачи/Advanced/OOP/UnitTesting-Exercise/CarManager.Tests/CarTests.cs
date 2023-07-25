using System;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private const string ValidMake = "VW";
        private const string InvalidMake = "";

        private const string ValidModel = "Golf";
        private const string InvalidModel = "";

        private const double ValidFuelConsumption = 1;
        private const double InvalidFuelConsumption = 0;

        private const double ValidFuelAmount = 0;
        private const double InvalidFuelAmount = -1;

        private const double ValidFuelCapacity = 10;
        private const double InvalidFuelCapacity = 0;

        private Car validCar;

        [SetUp]
        public void Setup()
        {
            this.validCar = new Car(ValidMake, ValidModel, ValidFuelConsumption, ValidFuelCapacity);
        }

        [Test]
        public void CarGettersReturnCorrectValues()
        {
            Assert.AreEqual(ValidMake, this.validCar.Make);
            Assert.AreEqual(ValidModel, this.validCar.Model);
            Assert.AreEqual(ValidFuelConsumption, this.validCar.FuelConsumption);
            Assert.AreEqual(ValidFuelAmount, this.validCar.FuelAmount);
            Assert.AreEqual(ValidFuelCapacity, this.validCar.FuelCapacity);
        }

        [Test]
        public void MakeSetterThrowsExceptionToInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => new Car(InvalidMake, ValidModel, ValidFuelConsumption, ValidFuelCapacity));
            Assert.Throws<ArgumentException>(() => new Car(null, ValidModel, ValidFuelConsumption, ValidFuelCapacity));
        }

        [Test]
        public void ModelSetterThrowsExceptionToInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => new Car(ValidMake, InvalidModel, ValidFuelConsumption, ValidFuelCapacity));
            Assert.Throws<ArgumentException>(() => new Car(ValidMake, null, ValidFuelConsumption, ValidFuelCapacity));
        }

        [Test]
        public void FuelConsumptionSetterThrowsExceptionToInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => new Car(ValidMake, ValidModel, InvalidFuelConsumption, ValidFuelCapacity));
            Assert.Throws<ArgumentException>(() => new Car(ValidMake, ValidModel, InvalidFuelConsumption - 1, ValidFuelCapacity));
        }

        [Test]
        public void FuelCapacitySetterThrowsExceptionToInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => new Car(ValidMake, ValidModel, ValidFuelConsumption, InvalidFuelCapacity));
            Assert.Throws<ArgumentException>(() => new Car(ValidMake, ValidModel, ValidFuelConsumption, InvalidFuelCapacity - 1));
        }

        [Test]
        public void RefuelThrowsExceptionToInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => this.validCar.Refuel(InvalidFuelCapacity));
            Assert.Throws<ArgumentException>(() => this.validCar.Refuel(InvalidFuelCapacity - 1));
        }

        [Test]
        public void RefuelRefuelsTheCar()
        {
            var amount = 5;
            this.validCar.Refuel(amount);

            Assert.AreEqual(amount, this.validCar.FuelAmount);
        }

        [Test]
        public void RefuelMoreThanTheCapacityFillsTheTankToMax()
        {
            this.validCar.Refuel(ValidFuelCapacity + 1);

            Assert.AreEqual(ValidFuelCapacity, this.validCar.FuelAmount);
        }

        [Test]
        public void DriveIfTheCarHasEnoughFuelFuelAmountIsReudced()
        {
            var distance = 100;

            this.validCar.Refuel(ValidFuelCapacity);
            this.validCar.Drive(distance);

            Assert.AreEqual(ValidFuelCapacity - 1, this.validCar.FuelAmount);
        }

        [Test]
        public void DriveIfTheCarHasNotEnoughFuelExceptionIsthrown()
        {
            var distance = 0.1;

            Assert.Throws<InvalidOperationException>(() => this.validCar.Drive(distance));
        }
    }
}