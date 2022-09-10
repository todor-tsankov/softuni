using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();

            this.OrderProducts = new HashSet<OrderProduct>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public virtual User User { get; set; }

        public decimal TotalPrice => OrderProducts.Sum(x => x.Product.Price);

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
