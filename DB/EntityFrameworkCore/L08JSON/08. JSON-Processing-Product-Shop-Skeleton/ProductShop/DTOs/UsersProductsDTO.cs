using Newtonsoft.Json;
using ProductShop.Models;
using System.Collections.Generic;

namespace ProductShop.DTOs
{
    public class UsersProductsDTO
    {
        public UsersProductsDTO()
        {
            this.Users = new List<UserDTO>();
        }

        [JsonProperty("usersCount")]
        public int UsersCount => this.Users.Count;

        [JsonProperty("users")]
        public ICollection<UserDTO> Users { get; set; }
    }
}
