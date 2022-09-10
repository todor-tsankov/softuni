using Skeleton;

public class FakeWeapon : IWeapon
{
    private int points;

    public FakeWeapon(int points)
    {
        this.points = points;
    }

    public int AttackPoints => points;

    public int DurabilityPoints => points;

    public void Attack(ITarget target)
    {
        target.TakeAttack(this.AttackPoints);
    }
}
