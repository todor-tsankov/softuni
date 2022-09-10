using PetStore.Services.Models;
using System.Collections.Generic;

namespace PetStore.Services
{
    public interface IProductsService
    {
        void AddProduct(string name, decimal price, string productDescription, string type, string typeDescription);

        ProductVIewModel GetProductByName(string name);
        IEnumerable<ProductVIewModel> GetProductsByType(string type);
        IEnumerable<ProductVIewModel> GetProductByPrice(decimal minPrice = 0, decimal maxPrice = 0);
    }
}
