using CarDealer.Common;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using ProductShop.XMLHelper;
using System;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            //ImportSuppliers(db, File.ReadAllText(DatasetPath.Suppliers));
            //ImportParts(db, File.ReadAllText(DatasetPath.Parts));
            //ImportCars(db, File.ReadAllText(DatasetPath.Cars));
            //ImportCustomers(db, File.ReadAllText(DatasetPath.Customers));
            //ImportSales(db, File.ReadAllText(DatasetPath.Sales));
            //GetCarsWithDistance(db);
            //GetCarsFromMakeBmw(db);
            //GetLocalSuppliers(db);
            //GetCarsWithTheirListOfParts(db);
            //GetTotalSalesByCustomer(db);

            var result = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(result);


        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var suppliers = XmlConverter.Deserializer<ImportSupplierDTO>(inputXml, "Suppliers")
                .Select(x => new Supplier()
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter
                })
                .ToArray();

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            var parts = XmlConverter.Deserializer<ImportPartDTO>(inputXml, "Parts")
                .Where(x => supplierIds.Contains(x.SupplierId))
                .Select(x => new Part()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToArray();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var cars = XmlConverter.Deserializer<ImportCarDTO>(inputXml, "Cars")
                .Select(x => new Car()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    PartCars = x.PartCars
                    .Distinct()
                    .Select(y => new PartCar()
                    {
                        PartId = y.Id
                    })
                    .ToList()
                })
                .ToList();

            foreach (var car in cars)
            {
                foreach (var carPart in car.PartCars)
                {
                    carPart.Car = car;
                }
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var customers = XmlConverter.Deserializer<ImportCustomerDTO>(inputXml, "Customers")
                .Select(x => new Customer()
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var carIds = context.Cars.Select(x => x.Id);

            var sales = XmlConverter.Deserializer<ImportSaleDTO>(inputXml, "Sales")
                .Where(x => carIds.Contains(x.CarId))
                .Select(x => new Sale()
                {
                    Discount = x.Discount,
                    CustomerId = x.CustomerId,
                    CarId = x.CarId
                })
                .ToList();

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance >= 2000000)
                .Select(x => new ExportCarWIthDistanceDTO()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();

            return XmlConverter.Serialize(cars, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new ExportCarBmwDTO()
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            return XmlConverter.Serialize(cars, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new ExportLocalSupplierDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            return XmlConverter.Serialize(suppliers, "suppliers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new ExportCarWithPartsDTO()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(y => new ExportPartDTO()
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price
                    })
                    .OrderByDescending(y => y.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            return XmlConverter.Serialize(cars, "cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new ExportCustomerWithSalesDTO()
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales
                        .SelectMany(y => y.Car.PartCars
                        .Select(z => z.Part.Price))
                        .Sum()
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            return XmlConverter.Serialize(customers, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new ExportSaleWithAppliedDiscountDTO()
                {
                    Car = new ExportCarDTO()
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(y => y.Part.Price).ToString("0.#######"),
                    PriceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) * (1 - x.Discount / 100M)).ToString("0.#######")
                })
                .ToList();

            return XmlConverter.Serialize(sales, "sales");
        }
    }
}