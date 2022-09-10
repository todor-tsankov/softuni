namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int DefaultBulletsPerBarrel = 10;
        private const int DefaultTotalBullets = 100;
        private const int FireBulletsCount = 1;

        public Pistol(string name)
            : base(name, DefaultBulletsPerBarrel, DefaultTotalBullets)
        {
        }

        public override int Fire()
        {
            var bulletsShot = 0;

            if (this.BulletsPerBarrel == 0)
            {
                if (this.TotalBullets >= DefaultBulletsPerBarrel)
                {
                    this.BulletsPerBarrel = DefaultBulletsPerBarrel;
                    this.TotalBullets -= DefaultBulletsPerBarrel;
                }
                else
                {
                    this.BulletsPerBarrel += this.TotalBullets;
                    this.TotalBullets = 0;
                }
            }

            if (this.BulletsPerBarrel >= FireBulletsCount)
            {
                bulletsShot += FireBulletsCount;
                this.BulletsPerBarrel -= FireBulletsCount;
            }
            else
            {
                bulletsShot += this.BulletsPerBarrel;
                this.BulletsPerBarrel = 0;
            }

            return bulletsShot;
        }
    }
}
