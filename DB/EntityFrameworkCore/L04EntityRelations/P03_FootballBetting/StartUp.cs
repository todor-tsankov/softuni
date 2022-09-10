using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new FootballBettingContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
