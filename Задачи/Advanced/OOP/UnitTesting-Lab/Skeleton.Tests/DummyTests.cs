using System;
using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthWhenAttacked()
    {
        var dummy = new Dummy(10, 10);

        dummy.TakeAttack(1);

        Assert.That(dummy.Health, Is.EqualTo(9));
    }

    [Test]
    public void DeadDummyCannotBeAttacked()
    {
        var dummy = new Dummy(-1, 10);

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1));
    }
    
    [Test]
    public void DeadDummyCanGiveExp()
    {
        var dummy = new Dummy(-1, 10);

        Assert.DoesNotThrow(() => dummy.GiveExperience());
        Assert.AreEqual(10, dummy.GiveExperience());
    }

    [Test]
    public void AliveDummyCantGiveExp()
    {
        var dummy = new Dummy(10, 10);

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
