﻿
using Newtonsoft.Json;

namespace ProductShop.DTOs
{
    public class UserDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("soldProducts")]
        public SoldProductsDTO SoldProducts { get; set; }
    }
}
