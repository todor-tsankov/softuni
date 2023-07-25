using Skeleton;

public class FakeTarget : ITarget
{
    private int health = 10;

    public int Health => this.health;

    public int GiveExperience()
    {
        return 10;
    }

    public bool IsDead()
    {
        return this.health <= 0;
    }

    public void TakeAttack(int attackPoints)
    {
        this.health -= attackPoints;
    }
}
