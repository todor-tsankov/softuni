using System;
using System.Linq;
using System.Collections.Generic;

using PetStore.Data;
using PetStore.Models;
using PetStore.Services.Models;

namespace PetStore.Services
{
    public class ProductsService : IProductsService
    {
        private PetStoreDbContext db;

        public ProductsService()
        {
            db = new PetStoreDbContext();
        }

        public void AddProduct(string name, decimal price, string productDescription, string typeName, string typeDescription)
        {
            StringCheck(name, nameof(Product), nameof(name));
            StringCheck(productDescription, nameof(Product), nameof(productDescription));
            StringCheck(typeName, nameof(Product), nameof(typeName));
            StringCheck(typeDescription, nameof(Product), nameof(typeDescription));

            if (price < 0)
            {
                var message = $"{nameof(Product)} {nameof(price)} cannot be negative";

                throw new ArgumentException(message);
            }

            var productType = this.db.ProductTypes
                .FirstOrDefault(x => x.Name == typeName);

            if (productType == null)
            {
                productType = new ProductType
                {
                    Name = typeName,
                    Description = typeDescription
                };
            }

            var product = new Product
            {
                Name = name,
                Price = price,
                Description = productDescription,
                ProductType = productType
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public ProductVIewModel GetProductByName(string name)
        {
            StringCheck(name, nameof(Product), nameof(name));

            var product = this.db.Products
                .Select(x => new ProductVIewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    ProductType = x.ProductType.Name,
                })
                .FirstOrDefault(x => x.Name == name.Trim());

            return product;
        }


        public IEnumerable<ProductVIewModel> GetProductByPrice(decimal minPrice = 0, decimal maxPrice = int.MaxValue)
        {
            if (minPrice < 0 || maxPrice < 0)
            {
                var message = $"{nameof(minPrice)}/{nameof(maxPrice)} cannot be less than zero";

                throw new ArgumentException(message);
            }
            else if (minPrice > maxPrice)
            {
                var message = $"{nameof(minPrice)} cannot be more than {nameof(maxPrice)}";

                throw new ArgumentException();
            }

            return this.db.Products
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .Select(x => new ProductVIewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    ProductType = x.ProductType.Name
                });
        }

        public IEnumerable<ProductVIewModel> GetProductsByType(string type)
        {
            StringCheck(type, nameof(Product), nameof(type));

            return this.db.Products
                .Where(x => x.ProductType.Name == type.Trim())
                .Select(x => new ProductVIewModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    ProductType = x.ProductType.Name
                });
        }

        private void StringCheck(string name, string className, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                var message = $"{className} {parameterName} cannot be null or whitespace!!!";

                throw new ArgumentException(message);
            }
        }
    }
}
