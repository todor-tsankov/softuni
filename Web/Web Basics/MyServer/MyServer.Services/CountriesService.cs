using MyServer.Data;
using MyServer.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyServer.Services
{
    public class CountriesService : ICountriesService
    {
        private ApplicationDbContext db;

        public CountriesService(ApplicationDbContext database)
        {
            this.db = database;
        }

        public IEnumerable<CountryViewModel> GetCountriesAlphabetically()
        {
            return this.db.Countries
                .Select(x => new CountryViewModel
                {
                    CountryName = x.Name,
                    CountryCode = x.CountryCode
                })
                .OrderBy(x => x.CountryName)
                .ToList();
        }

        public CountryViewModel GetCountryByCode(string code)
        {
            var country = this.db.Countries.FirstOrDefault(x => x.CountryCode == code);

            if (country == null)
            {
                return null;
            }

            return new CountryViewModel
            {
                CountryName = country.Name,
                CountryCode = country.CountryCode
            };
        }

        public CountryViewModel GetCountryByName(string name)
        {
            var country = this.db.Countries.FirstOrDefault(x => x.Name == name);

            if (country == null)
            {
                return null;
            }

            return new CountryViewModel
            {
                CountryName = country.Name,
                CountryCode = country.CountryCode
            };
        }
    }
}
