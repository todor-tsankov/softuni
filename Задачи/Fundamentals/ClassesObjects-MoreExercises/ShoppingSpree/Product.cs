using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    class Product
    {
        public Product(string productInfo)
        {
            string[] productInfoParts = productInfo.Split('=');
            Name = productInfoParts[0];
            Cost = double.Parse(productInfoParts[1]);
        }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
