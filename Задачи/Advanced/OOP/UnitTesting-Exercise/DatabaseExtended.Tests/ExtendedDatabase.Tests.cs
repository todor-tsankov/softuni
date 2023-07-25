using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private const int DatabaseCapacity = 16;

        private const long FirstTestId = 123456789;
        private const string FirstTestUsername = "testUsername123";

        private const long SecondtTestId = 987654321;
        private const string SecondTestUsername = "testUsername321";

        private const long NotExistingId = 000000000;
        private const string NotExistingUsername = "idontexist";

        private Person firstTestPerson;
        private Person secondTestPerson;
        private Person addedPerson;

        private ExtendedDatabase onePersonDatabase;
        private ExtendedDatabase fullDatabase;

        [SetUp]
        public void Setup()
        {
            this.firstTestPerson = new Person(FirstTestId, FirstTestUsername);
            this.secondTestPerson = new Person(SecondtTestId, SecondTestUsername);

            this.addedPerson = new Person(FirstTestId, SecondTestUsername);
            this.onePersonDatabase = new ExtendedDatabase(this.addedPerson);

            var personArr = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                personArr[i] = new Person(i, i.ToString());
            }

            this.fullDatabase = new ExtendedDatabase(personArr);
        }

        [Test]
        public void CountIsEqualToTheNumberOfAddedElements()
        {
            var count = this.onePersonDatabase.Count;
            var fullCount = this.fullDatabase.Count;

            Assert.AreEqual(1, count);
            Assert.AreEqual(DatabaseCapacity, fullCount);
        }

        [Test]
        public void ConstructorThrowsExceptionIfTheCountOfInitialelemntsIsGreaterThanTheDefaultSize()
        {
            Assert.Throws<ArgumentException>(() => 
                                 new ExtendedDatabase(new Person[DatabaseCapacity + 1]));
        }

        [Test]
        public void FindByUsername()
        {
            var person = this.onePersonDatabase.FindByUsername(SecondTestUsername);

            Assert.AreEqual(this.addedPerson, person);
        }

        [Test]
        public void AddThrowsExceptionOnFullDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => this.fullDatabase.Add(this.firstTestPerson));
        }

        [Test]
        public void AddThrowsExceptionIfThereIsAUserWithTheSameIdOrUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.onePersonDatabase.Add(this.firstTestPerson));
            Assert.Throws<InvalidOperationException>(() => this.onePersonDatabase.Add(this.secondTestPerson));
        }

        [Test]
        public void RemoveThrowsExceptionOnEmptyDatabase()
        {
            Assert.DoesNotThrow(() => this.onePersonDatabase.Remove());
            Assert.Throws<InvalidOperationException>(() => this.onePersonDatabase.Remove());
        }

        [Test]
        public void FindById()
        {
            var person = this.onePersonDatabase.FindById(FirstTestId);

            Assert.AreEqual(this.addedPerson, person);
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfTheresNoSuchUserOrArgumentIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.onePersonDatabase.FindByUsername(NotExistingUsername));
            Assert.Throws<InvalidOperationException>(() => this.onePersonDatabase.FindByUsername(SecondTestUsername.ToLower()));
            Assert.Throws<ArgumentNullException>(() => this.onePersonDatabase.FindByUsername(null));
        }

        [Test]
        public void FindByIdThrowsExceptionIfTheresNoSuchUserOrIdIsInvalis()
        {
            Assert.Throws<InvalidOperationException>(() => this.onePersonDatabase.FindById(NotExistingId));
            Assert.Throws<ArgumentOutOfRangeException>(() => this.onePersonDatabase.FindById(-1));
        }
    }
}