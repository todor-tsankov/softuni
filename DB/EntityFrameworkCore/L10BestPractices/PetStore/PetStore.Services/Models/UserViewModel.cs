using System.Collections.Generic;

using PetStore.Models;

namespace PetStore.Services.Models
{
    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
