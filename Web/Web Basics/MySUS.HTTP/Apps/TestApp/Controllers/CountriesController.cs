using MySUS.HTTP;
using MySUS.MvcFramework;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using TestApp.Data.Countries;

namespace TestApp.Controllers
{
    public class CountriesController : Controller
    {
        public HttpResponse All()
        {
            var json = File.ReadAllText(@"Data/Countries/CountriesInfo.json");
            var countries = JsonSerializer.Deserialize<CountriesViewModel[]>(json);

            return this.View(countries);
        }
    }
}
