namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        private const string ValidMake = "Test123";
        private const string ValidRegistrationNumber = "Ab1234Sv";

        private Car car;
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(ValidMake, ValidRegistrationNumber);
            this.softPark = new SoftPark();
        }

        [Test]
        public void CarConstructorSetsTheRightProperties()
        {
            var car = new Car(ValidMake, ValidRegistrationNumber);

            Assert.AreEqual(ValidMake, car.Make);
            Assert.AreEqual(ValidRegistrationNumber, car.RegistrationNumber);
        }

        [Test]
        public void ParkingcotructorSetsTheParking()
        {
            var parking = new SoftPark();

            var expected = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            CollectionAssert.AreEquivalent(expected, parking.Parking);
            CollectionAssert.AreEqual(expected, parking.Parking);
        }

        [Test]
        public void ParkCarThrowsExceptionIfSpotIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("c4", this.car);
            });
        }

        [Test]
        public void ParkCarThrowsExceptionIfSpotIsTaken()
        {
            this.softPark.ParkCar("C4", this.car);

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("C4", new Car("alalal", "alalal"));
            });
        }

        [Test]
        public void ParkCarThrowIfThaCarIsAlreadyParked()
        {
            this.softPark.ParkCar("C4", this.car);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.softPark.ParkCar("A1", new Car("alalal", ValidRegistrationNumber));
            });
        }

        [Test]
        public void ParkCarSuccess()
        {
            this.softPark.ParkCar("C4", this.car);

            var car = this.softPark.Parking["C4"];

            Assert.AreEqual(this.car, car);
        }

        [Test]
        public void ParkReturnscorrectString()
        {
            var message = this.softPark.ParkCar("C4", this.car);

            Assert.AreEqual($"Car:{this.car.RegistrationNumber} parked successfully!", message);
        }

        [Test]
        public void RemoveCarthrowsToInvalidParkingSpot()
        {
            this.softPark.ParkCar("C4", this.car);

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("sdf", this.car);
            });
        }

        [Test]
        public void RemoveThrowsExceptionIfTheCarIsDifferent()
        {
            this.softPark.ParkCar("C4", this.car);

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("C4", new Car(ValidMake, ValidRegistrationNumber));
            });
        }

        [Test]
        public void RemovesSetsTheSpottoNull()
        {
            this.softPark.ParkCar("C4", this.car);

            this.softPark.RemoveCar("C4", this.car);

            Assert.IsNull(this.softPark.Parking["C4"]);
        }

        [Test]
        public void RemoveReturnsCorrectMessage()
        {
            this.softPark.ParkCar("C4", this.car);

            var message = this.softPark.RemoveCar("C4", this.car);

            Assert.AreEqual($"Remove car:{this.car.RegistrationNumber} successfully!", message);
        }
    }
}