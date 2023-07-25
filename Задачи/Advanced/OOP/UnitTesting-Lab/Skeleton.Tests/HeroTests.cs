using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsExpWhenKillingTarget()
    {
        var hero = new Hero("Toshko", new FakeWeapon(10));
        var target = new FakeTarget();

        hero.Attack(target);

        Assert.That(hero.Experience, Is.EqualTo(10));
    }
}