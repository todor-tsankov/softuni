using System;
using System.Collections.Generic;

namespace PetStore.Models
{
    public class OrderProduct
    {
        public OrderProduct()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
