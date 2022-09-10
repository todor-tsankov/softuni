using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();

            this.OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        public string Id { get; set; }

        [Required, StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required]
        public virtual ProductType ProductType { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
