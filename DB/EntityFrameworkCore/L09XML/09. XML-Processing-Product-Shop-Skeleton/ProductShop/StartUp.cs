using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

using AutoMapper;

using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;
using System.Text;
using System;
using ProductShop.XMLHelper;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            var result = GetUsersWithProducts(db);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var rootAttr = new XmlRootAttribute("Users");
            var serializer = new XmlSerializer(typeof(List<Dtos.Import.UserDTO>), rootAttr);

            var stringReader = new StringReader(inputXml);

            var userDTOs = (List<Dtos.Import.UserDTO>)serializer.Deserialize(stringReader);

            var users = userDTOs
                .Select(x => new User()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var stringReader = new StringReader(inputXml);
            var rootAttr = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(List<ProductShop.Dtos.Import.ProductDTO>), rootAttr);

            var productsDTOs = (List<ProductShop.Dtos.Import.ProductDTO>)serializer.Deserialize(stringReader);

            var products = productsDTOs
                .Select(x => new Product()
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerId = x.BuyerId,
                    SellerId = x.SellerId
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var stringReader = new StringReader(inputXml);

            var rootAttr = new XmlRootAttribute("Categories");
            var serializer = new XmlSerializer(typeof(List<Dtos.Import.CategoryDTO>), rootAttr);

            var categoriesDTOs = (List<Dtos.Import.CategoryDTO>)serializer.Deserialize(stringReader);
            var categories = categoriesDTOs.Select(x => new Category()
            {
                Name = x.Name
            })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var stringReader = new StringReader(inputXml);

            var rootAttr = new XmlRootAttribute("CategoryProducts");
            var serializer = new XmlSerializer(typeof(List<CategoryProductDTO>), rootAttr);

            var categoryProductDTOs = (List<CategoryProductDTO>)serializer.Deserialize(stringReader);

            var categoriesProducts = categoryProductDTOs.Select(x => new CategoryProduct()
            {
                CategoryId = x.CategoryId,
                ProductId = x.ProductId
            })
               .ToList();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductShop.Dtos.Export.ProductDTO
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerName = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            return XmlConverter.Serialize(products, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new Dtos.Export.UserDTO()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProductsSold = new SoldProductsDTO()
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold.Select(y => new Dtos.Export.ProductDTO()
                        {
                            Name = y.Name,
                            Price = y.Price
                        })
                            .ToList()
                    }
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();

            return XmlConverter.Serialize(users, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new Dtos.Export.CategoryDTO()
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(y => y.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(y => y.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            return XmlConverter.Serialize(categories, "Categories");
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new UsersDTO()
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),

                Users = context.Users
                    .Include(x => x.ProductsSold)
                    .ToArray()
                    .Where(x => x.ProductsSold.Any())
                    .Select(x => new Dtos.Export.UserDTO()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        ProductsSold = new SoldProductsDTO()
                        {
                            Count = x.ProductsSold.Count,
                            Products = x.ProductsSold
                            .Select(y => new Dtos.Export.ProductDTO()
                            {
                                Name = y.Name,
                                Price = y.Price
                            })
                            .OrderByDescending(y => y.Price)
                            .ToList()
                        }
                    })
                    .OrderByDescending(x => x.ProductsSold.Count)
                    .Take(10)
                    .ToList()
            };

            return XmlConverter.Serialize(users, "Users");
        }
    }
}