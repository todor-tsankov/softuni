using System;
using System.Collections.Generic;
using System.Linq;

namespace P03ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                var peopleInput = ReadInput();
                var people = GetPeople(peopleInput);

                var productsInput = ReadInput();
                var products = GetProducts(productsInput);

                BuyProducts(people, products);
                PrintStatistics(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                          .Split(";", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();
        }
        private static List<Person> GetPeople(string[] peopleInput)
        {
            var people = new List<Person>();

            foreach (var personInfo in peopleInput)
            {
                var personInfoArgs = GetInfoArgs(personInfo);

                var name = personInfoArgs[0];
                var money = decimal.Parse(personInfoArgs[1]);

                var currentPerson = new Person(name, money);

                people.Add(currentPerson);
            }

            return people;
        }
        private static string[] GetInfoArgs(string info)
        {
            return info.Split("=")
                       .ToArray();
        }
        private static List<Product> GetProducts(string[] productsInput)
        {
            var products = new List<Product>();

            foreach (var productInfo in productsInput)
            {
                var productInfoArgs = GetInfoArgs(productInfo);

                var name = productInfoArgs[0];
                var cost = decimal.Parse(productInfoArgs[1]);

                var currentProduct = new Product(name, cost);

                products.Add(currentProduct);
            }

            return products;
        }
        private static void BuyProducts(List<Person> people, List<Product> products)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }

                var personProductArgs = command.Split(" ")
                                               .ToArray();

                var personName = personProductArgs[0];
                var productName = personProductArgs[1];

                var person = people.FirstOrDefault(p => p.Name == personName);
                var product = products.FirstOrDefault(p => p.Name == productName);

                if (person == null || product == null)
                {
                    continue;
                }

                var success = person.BuyProduct(product);

                if (success)
                {
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
            }
        }
        private static void PrintStatistics(List<Person> people)
        {
            foreach (var person in people)
            {
                var output = string.Empty;

                if (person.BagOfProducts.Count == 0)
                {
                    output = $"{person.Name} - Nothing bought ";
                }
                else
                {
                    output = $"{person.Name} - {string.Join(", ", person.BagOfProducts.Select(p => p.Name))}";
                }

                Console.WriteLine(output);
            }
        }

    }
}
