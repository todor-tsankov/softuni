using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLoosesDurabilityAfterEachAttack()
    {
        var axe = new Axe(10, 10);
        var dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesn't change after attack.");
    }

    [Test]
    public void BrokenAxeCantAttack()
    {
        var axe = new Axe(10, 0);
        var dummy = new Dummy(10, 10);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Cannot attck with broken wepon");
    }
}