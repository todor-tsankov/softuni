using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Newtonsoft.Json;

using ProductShop.Data;
using ProductShop.Models;
using System.Diagnostics.Contracts;
using Newtonsoft.Json.Serialization;
using ProductShop.DTOs;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile(new ProductShopProfile()));
            var context = new ProductShopContext();

            context.Database.EnsureCreated();

            var inputJson = File.ReadAllText(@"F:\SoftUni\Solutions\DB\EntityFrameworkCore\L08JSON\08. JSON-Processing-Product-Shop-Skeleton\ProductShop\Datasets\categories-products.json");
            var count = GetUsersWithProducts(context);

            Console.WriteLine(count);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var productsCategories = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(productsCategories);
            context.SaveChanges();

            return $"Successfully imported {productsCategories.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
            {
                x.Name,
                x.Price,
                seller = x.Seller.FirstName + " " + x.Seller.LastName
            })
                .OrderBy(x => x.Price)
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            return JsonConvert.SerializeObject(products, Formatting.Indented, settings);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold
                        .Select( y => new
                        {
                            y.Name,
                            y.Price,
                            BuyerFirstName = y.Buyer.FirstName,
                            BuyerLastName = y.Buyer.LastName
                        })
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToList();

            return JsonConvert.SerializeObject(users, Formatting.None, settings);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var categories = context.Categories
                .Select(x => new
                {
                    Category = x.Name,
                    ProductsCount = x.CategoryProducts.Count(),
                    AveragePrice = x.CategoryProducts
                        .Average(y => y.Product.Price)
                        .ToString("F2"),
                    TotalRevenue = x.CategoryProducts
                        .Sum(y => y.Product.Price)
                        .ToString("F2")
                })
                .OrderByDescending(x => x.ProductsCount)
                .ToList();

            return JsonConvert.SerializeObject(categories, Formatting.Indented, settings);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,

                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var usersProducts = new UsersProductsDTO()
            {
                Users = context.Users
                .AsEnumerable()
                    .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                    .Select(x => new UserDTO()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        SoldProducts = new SoldProductsDTO()
                        {
                            Products = x.ProductsSold
                                .Where(y => y.Buyer != null)
                                .Select(y => new ProductDTO()
                                {
                                    Name = y.Name,
                                    Price = y.Price
                                })
                            .ToList()
                        }
                    })
                    .OrderByDescending(x => x.SoldProducts.Count)
                    .ToList()
            };

            return JsonConvert.SerializeObject(usersProducts, Formatting.Indented, settings);
        }
    }
}