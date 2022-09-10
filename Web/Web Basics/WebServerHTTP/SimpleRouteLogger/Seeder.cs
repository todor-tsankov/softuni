using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace SimpleRouteLogger
{
    public class Seeder
    {
        public void Seed(RouteLogDbContext db)
        {
            db.Routes.Add(new Route { Name = "Sungurlarski Misket", Grade = "7c+"});
            db.Routes.Add(new Route { Name = "Sungurlarski Misket-first part", Grade = "6c+"});
            db.Routes.Add(new Route { Name = "Mecho Buh", Grade = "7a"});
            db.Routes.Add(new Route { Name = "Maznyana", Grade = "7b"});
            db.Routes.Add(new Route { Name = "Altius", Grade = "8a"});
            db.Routes.Add(new Route { Name = "Levitation", Grade = "7c+"});
            db.Routes.Add(new Route { Name = "Mr Proper", Grade = "8b"});
            db.Routes.Add(new Route { Name = "Jackpot", Grade = "8b"});
            db.Routes.Add(new Route { Name = "Nepobedim", Grade = "8b"});
            db.Routes.Add(new Route { Name = "Napred i nagore", Grade = "9a"});
            db.Routes.Add(new Route { Name = "Biographie", Grade = "9a+"});
            db.Routes.Add(new Route { Name = "Izmislen", Grade = "5a"});

            db.SaveChanges();
        }
    }
}
