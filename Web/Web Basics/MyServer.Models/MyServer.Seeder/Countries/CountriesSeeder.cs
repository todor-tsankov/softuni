using MyServer.Data;
using MyServer.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyServer.Seeder.Countries
{
    public class CountriesSeeder : ISeeder
    {
        private const string FileName = @"Countries\CountriesWithCode.json";

        public void Seed(ApplicationDbContext db)
        {
            var json = File.ReadAllText(FileName);
            var countries = JsonConvert.DeserializeObject<List<CountryDTO>>(json)
                .Select(x => new Country 
                {
                    Name = x.Name,
                    CountryCode = x.Code
                })
                .ToList();

            db.Countries.AddRange(countries);
            db.SaveChanges();
        }
    }
}
