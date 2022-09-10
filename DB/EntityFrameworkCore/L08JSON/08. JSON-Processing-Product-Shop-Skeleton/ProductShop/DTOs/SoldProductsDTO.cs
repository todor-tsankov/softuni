using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ProductShop.DTOs
{
    public class SoldProductsDTO
    {
        [JsonProperty("count")]
        public int Count => this.Products.Count;

        [JsonProperty("products")]
        public ICollection<ProductDTO> Products { get; set; }
    }
}
