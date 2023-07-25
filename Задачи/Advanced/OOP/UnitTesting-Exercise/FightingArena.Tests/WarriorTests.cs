using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    public class WarriorTests
    {
        private const string ValidName = "Toshko";

        private const string InvalidNameNull = null;
        private const string InvalidNameEmpty = "";
        private const string InvalidNameWhitespace = " ";

        private const int ValidDamage = 1;
        private const int ValidDamageForbattle = 50;

        private const int InvalidDamageZero = 0;
        private const int InvalidDamageNeg = -1;

        private const int ValidHP = 0;
        private const int ValidHPforBattle = 50;

        private const int InvalidHP = -1;

        private Warrior validWarrior;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GettersReturnCorrectValues()
        {
            this.validWarrior = new Warrior(ValidName, ValidDamage, ValidHP);

            Assert.AreEqual(ValidName, this.validWarrior.Name);
            Assert.AreEqual(ValidDamage, this.validWarrior.Damage);
            Assert.AreEqual(ValidHP, this.validWarrior.HP);
        }

        [Test]
        public void NameSetterThrowsExceptionToInvalidName()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(InvalidNameNull, ValidDamageForbattle, ValidHP));
            Assert.Throws<ArgumentException>(() => new Warrior(InvalidNameEmpty, ValidDamageForbattle, ValidHP));
            Assert.Throws<ArgumentException>(() => new Warrior(InvalidNameWhitespace, ValidDamageForbattle, ValidHP));
        }

        [Test]
        public void DamageSetterThrowsExceptionToInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(ValidName, InvalidDamageZero, ValidHP));
            Assert.Throws<ArgumentException>(() => new Warrior(ValidName, InvalidDamageNeg, ValidHP));
        }

        [Test]
        public void HPSetterThrowsExceptionToInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(ValidName, ValidDamageForbattle, InvalidHP));
            Assert.Throws<ArgumentException>(() => new Warrior(ValidName, ValidDamageForbattle, InvalidHP - 5));
        }

        [Test]
        public void AttackThrowsExceptionIfThisWarriorsHPIsInvalid()
        {
            var warrior = new Warrior(ValidName, ValidDamageForbattle, ValidHP);
            var warrior2 = new Warrior(ValidName, ValidDamageForbattle, 30);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(null));
            Assert.Throws<InvalidOperationException>(() => warrior2.Attack(null));
        }

        [Test]
        public void AttackThrowsExceptionIfOtherWarriorsHPIsInvalid()
        {
            var currentWarrior = new Warrior(ValidName, ValidDamageForbattle, ValidHPforBattle);

            var warrior = new Warrior(ValidName, ValidDamageForbattle, ValidHP);
            var warrior2 = new Warrior(ValidName, ValidDamageForbattle, 30);

            Assert.Throws<InvalidOperationException>(() => currentWarrior.Attack(warrior));
            Assert.Throws<InvalidOperationException>(() => currentWarrior.Attack(warrior2));
        }

        [Test]
        public void AttackThrowsExceptionIfYoutryToAttackAStrongerWarrior()
        {
            var currentWarrior = new Warrior(ValidName, ValidDamageForbattle, ValidHPforBattle);
            var attackedWarrior = new Warrior(ValidName, ValidDamageForbattle + 1, ValidHPforBattle);

            Assert.Throws<InvalidOperationException>(() => currentWarrior.Attack(attackedWarrior));
        }

        [Test]
        public void AttackValidWarriorsFirstCase()
        {
            var currentWarrior = new Warrior(ValidName, ValidDamageForbattle, ValidHPforBattle);
            var attackedWarrior = new Warrior(ValidName, ValidDamageForbattle - 5, ValidHPforBattle);

            currentWarrior.Attack(attackedWarrior);

            Assert.AreEqual(ValidHPforBattle - (ValidDamageForbattle - 5), currentWarrior.HP);
            Assert.AreEqual(ValidHPforBattle - ValidDamageForbattle, attackedWarrior.HP);
        }

        [Test]
        public void AttackValidWarriorsSecondCase()
        {
            var currentWarrior = new Warrior(ValidName, ValidDamageForbattle + 5, ValidHPforBattle);
            var attackedWarrior = new Warrior(ValidName, ValidDamageForbattle - 5, ValidHPforBattle);

            currentWarrior.Attack(attackedWarrior);

            Assert.AreEqual(ValidHPforBattle - ValidDamageForbattle + 5, currentWarrior.HP);
            Assert.AreEqual(0, attackedWarrior.HP);
        }
    }
}