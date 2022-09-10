using MyServer.Data;
using MyServer.Seeder.Countries;
using System;
using System.Collections.Generic;

namespace MyServer.Seeder
{
    public class Program
    {
        public static void Main()
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureCreated();

            var seeders = new List<ISeeder>();
            var countriesSeeder = new CountriesSeeder();

            seeders.Add(countriesSeeder);
            seeders.ForEach(x => x.Seed(db));
        }
    }
}
