using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.DTOs;
using ProductShop.Models;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));

            CreateMap<ICollection<Product>, SoldProductsDTO>()
                .ForMember(x => x.Products, y => y.MapFrom(z => z));

            CreateMap<User, UserDTO>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.Age))
                .ForMember(x => x.SoldProducts, y => y.MapFrom(z => z.ProductsSold));

            CreateMap<DbSet<User>, UsersProductsDTO>()
                .ForMember(x => x.Users, y => y.MapFrom(z => z));
        }
    }
}
