using System.Text.Json.Serialization;

namespace TestApp.Data.Countries
{
    public class CountriesViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
