using Newtonsoft.Json;

namespace MyServer.Seeder.Countries
{
    public class CountryDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }
    }
}
