using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class ProductType
    {
        public ProductType()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Products = new HashSet<Product>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}