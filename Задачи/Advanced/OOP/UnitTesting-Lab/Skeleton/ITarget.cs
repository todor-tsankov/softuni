namespace Skeleton
{
    public interface ITarget
    {
        int Health { get; }

        bool IsDead();

        void TakeAttack(int attackPoints);

        int GiveExperience();
    }
}
