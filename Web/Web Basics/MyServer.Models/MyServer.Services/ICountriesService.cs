using MyServer.Services.Models;
using System.Collections.Generic;

namespace MyServer.Services
{
    public interface ICountriesService
    {
        CountryViewModel GetCountryByCode(string code);
        CountryViewModel GetCountryByName(string name);

        IEnumerable<CountryViewModel> GetCountriesAlphabetically();
    }
}
