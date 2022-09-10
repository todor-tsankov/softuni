using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private const string ValidName = "Toshko";
    private const int ValidLevel = 10;

    private Hero hero;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        this.hero = new Hero(ValidName, ValidLevel);
        this.heroRepository = new HeroRepository();
    }

    [Test]
    public void HeroContructorSetsTheRightProperties()
    {
        Assert.AreEqual(ValidName, this.hero.Name);
        Assert.AreEqual(ValidLevel, this.hero.Level);
    }

    [Test]
    public void HeroRepositoryConstructorSetsTheCollection()
    {
        var heroes = this.heroRepository.Heroes;

        Assert.IsNotNull(heroes);
        Assert.IsEmpty(heroes);
    }

    [Test]
    public void CreateNullHeroThrows()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Create(null);
        });
    }

    [Test]
    public void CreateHeroTwiceThrows()
    {
        this.heroRepository.Create(this.hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            this.heroRepository.Create(this.hero);
        });
    }

    [Test]
    public void CreateHeroTwiceWithTheSmaeNameThrows()
    {
        var sameHero = new Hero(ValidName, ValidLevel);
        this.heroRepository.Create(this.hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            this.heroRepository.Create(sameHero);
        });
    }

    [Test]
    public void CreateHeroAddsToTheCollection()
    {
        this.heroRepository.Create(this.hero);

        var hero = this.heroRepository.Heroes.First();
        Assert.AreEqual(this.hero.Name, hero.Name);
        Assert.AreEqual(this.hero.Level, hero.Level);
    }

    [Test]
    public void CreateHEroReturnsCorrectMessage()
    {
        var message = this.heroRepository.Create(this.hero);
        Assert.AreEqual($"Successfully added hero {this.hero.Name} with level {this.hero.Level}", message);
    }

    [Test]
    public void RemoveNullThrows()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Remove(null);
        });
    }

    [Test]
    public void RemoveEmptyThrows()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Remove(string.Empty);
        });
    }

    [Test]
    public void RemoveWhitespaceThrows()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            this.heroRepository.Remove("   ");
        });
    }

    [Test]
    public void RemoveReturnsFalse()
    {
        var success = this.heroRepository.Remove("Pesho");

        Assert.IsFalse(success);
    }

    [Test]
    public void RemoveReturnsFalse2()
    {
        this.heroRepository.Create(this.hero);
        var success = this.heroRepository.Remove("Pesho");

        Assert.IsFalse(success);
        Assert.IsNotEmpty(this.heroRepository.Heroes);
    }

    [Test]
    public void RemoveSuccess()
    {
        this.heroRepository.Create(this.hero);
        var success = this.heroRepository.Remove(this.hero.Name);

        Assert.IsTrue(success);
        Assert.IsEmpty(this.heroRepository.Heroes);
    }

    [Test]
    public void GetHighHero()
    {
        var highestHero = new Hero("toshko", 11);
        var lowHero = new Hero("dani", 9);
        this.heroRepository.Create(this.hero);
        this.heroRepository.Create(highestHero);
        this.heroRepository.Create(lowHero);

        var result = this.heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(highestHero.Name, result.Name);
        Assert.AreEqual(highestHero.Level, result.Level);
    }

    [Test]
    public void GetHeroReturnsNull()
    {
        var hero = this.heroRepository.GetHero("inexistentNAme");

        Assert.IsNull(hero);
    }

    [Test]
    public void GetHeroReturnsTheHEro()
    {
        var highestHero = new Hero("toshko", 11);
        var lowHero = new Hero("dani", 9);
        this.heroRepository.Create(this.hero);
        this.heroRepository.Create(highestHero);
        this.heroRepository.Create(lowHero);

        var result = this.heroRepository.GetHero(this.hero.Name);

        Assert.AreEqual(this.hero.Name, result.Name);
        Assert.AreEqual(this.hero.Level, result.Level);
    }
}