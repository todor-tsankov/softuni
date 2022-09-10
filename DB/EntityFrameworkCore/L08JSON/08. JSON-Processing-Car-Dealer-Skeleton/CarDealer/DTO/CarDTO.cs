using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarDTO
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        [JsonProperty("partsId")]
        public ICollection<int> PartsIds { get; set; }
    }
}
