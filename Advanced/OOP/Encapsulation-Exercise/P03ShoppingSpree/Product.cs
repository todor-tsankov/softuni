namespace P03ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                CommonValidator.ValidateMoney(value, "Money");
                this.cost = value;
            }
        }
    }
}
