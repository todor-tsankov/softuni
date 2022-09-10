using System;
using System.Collections.Generic;

namespace P03ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        private Person()
        {
            this.bagOfProducts = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                CommonValidator.ValidateName(value, nameof(this.Name));

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                CommonValidator.ValidateMoney(value, nameof(this.Money));

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts
        {
            get
            {
                return this.bagOfProducts.AsReadOnly();
            }
        }

        public bool BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return false;
            }

            bagOfProducts.Add(product);
            this.Money -= product.Cost;

            return true;
        }
    }
}
