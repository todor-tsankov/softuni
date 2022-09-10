using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private readonly IList<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index] 
        {
            get 
            { 
                return this.products[index]; 
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Product cannot be null!");
                }

                if (this.products.Any(p => p.Label == value.Label))
                {
                    throw new ArgumentException("Product with that label already exists!");
                }

                this.products[index] = value;
            }

        }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }

            if (this.products.Any(p => p.Label == product.Label))
            {
                throw new InvalidOperationException("Cannot add product with the same label twice!");
            }

            this.products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null!");
            }

            return this.products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.products.Count)
            {
                throw new IndexOutOfRangeException("Invalid index!");
            }

            return this.products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            var found = this.products.Where(p => p.Price == (decimal)price);

            return found;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            var found = this.products.Where(p => p.Quantity == quantity);

            return found;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            var found = this.products.Where(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi)
                                     .OrderByDescending(p => p.Price);

            return found;
        }

        public IProduct FindByLabel(string label)
        {
            if (label == null)
            {
                throw new ArgumentNullException("Label cannot be null");
            }

            var foundProduct = this.products.FirstOrDefault(p => p.Label == label);

            if (foundProduct == null)
            {
                throw new ArgumentException("Not found!");
            }

            return foundProduct;
        }

        public IProduct FindMostExpensiveProduct()
        {

            var mostExpensive = this.products.OrderByDescending(p => p.Price)
                                             .FirstOrDefault();

            if (mostExpensive == null)
            {
                throw new InvalidOperationException("Produck stock is empty!");
            }

            return mostExpensive;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return this.products.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null!");
            }

            var foundProduct = this.products.FirstOrDefault(p => p.Label == product.Label);

            if (foundProduct == null)
            {
                return false;
            }

            this.products.Remove(foundProduct);

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
