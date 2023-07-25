using NUnit.Framework;
using System;
using System.Linq;

namespace FightingArena.Tests
{
    public class ArenaTests
    {
        private const string FirstWarriorName = "Toshko";
        private const string SecondWarriorName = "Dani";

        private const int ValidDamage = 50;
        private const int ValidHp = 50;

        private Warrior firstWarrior;
        private Warrior secondWarrior;

        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.firstWarrior = new Warrior(FirstWarriorName, ValidDamage, ValidHp);
            this.secondWarrior = new Warrior(SecondWarriorName, ValidDamage, ValidHp);

            this.arena = new Arena();
        }

        [Test]
        public void WarriorsShouldBeInstantialized()
        {
            Assert.NotNull(this.arena);
        }

        [Test]
        public void WarriorsReturnsTheEnrolledWarriors()
        {
            this.arena.Enroll(this.firstWarrior);
            this.arena.Enroll(this.secondWarrior);

            var warriors = this.arena.Warriors.ToList();

            Assert.AreEqual(this.firstWarrior, warriors[0]);
            Assert.AreEqual(this.secondWarrior, warriors[1]);
        }

        [Test]
        public void CountGivesTheNumberOfFightersEnrolled()
        {
            Assert.AreEqual(0, this.arena.Count);

            this.arena.Enroll(this.firstWarrior);
            Assert.AreEqual(1, this.arena.Count);

            this.arena.Enroll(this.secondWarrior);
            Assert.AreEqual(2, this.arena.Count);
        }

        [Test]
        public void CannotEnrollOneWarriorTwice()
        {
            this.arena.Enroll(this.firstWarrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(this.firstWarrior));
        }

        [Test]
        public void CannotFightIfBothWarriorsAreNotEnrolled()
        {
            this.arena.Enroll(this.firstWarrior);
            this.arena.Enroll(this.secondWarrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("toko", "boko"));
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("toko", SecondWarriorName));
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(FirstWarriorName, "boko"));

            Assert.DoesNotThrow(() => this.arena.Fight(FirstWarriorName, SecondWarriorName));
            Assert.AreNotEqual(ValidHp, this.firstWarrior.HP);
            Assert.AreNotEqual(ValidHp, this.secondWarrior.HP);
        }

        [Test]
        public void FightOccurs()
        {
            this.arena.Enroll(this.firstWarrior);
            this.arena.Enroll(this.secondWarrior);

            Assert.DoesNotThrow(() => this.arena.Fight(FirstWarriorName, SecondWarriorName));

            Assert.AreNotEqual(ValidHp, this.firstWarrior.HP);
            Assert.AreNotEqual(ValidHp, this.secondWarrior.HP);
        }
    }
}
