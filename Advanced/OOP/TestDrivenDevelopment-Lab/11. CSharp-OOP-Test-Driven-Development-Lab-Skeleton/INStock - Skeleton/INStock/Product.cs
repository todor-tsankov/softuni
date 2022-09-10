using INStock.Contracts;
using System;

namespace INStock
{
    public class Product : IProduct
    {
        private const string InvalidLabelMessage = "Label cannot be null, empty or whitespace!";
        private const string InvalidPriceMessage = "Price cannot be less than zero!";
        private const string InvalidQuantityMessage = "Quantity cannot be less than zero!";

        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label 
        {
            get
            {
                return this.label;
            }
            private set
            {
                this.ValidateLabel(value);

                this.label = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.ValidatePrice(value);

                this.price = value;
            }
        }

        public int Quantity 
        {
            get
            {
                return this.quantity;
            }
            private set
            {
                this.ValidatePrice(value);

                this.quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            var result = this.Price.CompareTo(other.Price);

            return result;
        }

        private void ValidateLabel(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(InvalidLabelMessage);
            }
        }

        private void ValidatePrice(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException(InvalidPriceMessage);
            }
        }

        private void ValidateQuantity(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException(InvalidQuantityMessage);
            }
        }
    }
}
