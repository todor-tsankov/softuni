using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Orders = new HashSet<Order>();
        }

        [Key]
        public string Id { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}