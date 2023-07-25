using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    class ShoppingSpree
    {
        static void Main(string[] args)
        {
            List<Person> listPeople = new List<Person>();
            List<Product> listProducts = new List<Product>();
            string[] allPeople = Console.ReadLine().Split(';');
            string[] allProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in allPeople)
            {
                listPeople.Add(new Person(person));
            }

            foreach (var product in allProducts)
            {
                listProducts.Add(new Product(product));
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandParts = command.Split();

                int currentPersonIndex = listPeople.FindIndex(i => i.Name == commandParts[0]);
                int currentProductIndex = listProducts.FindIndex(i => i.Name == commandParts[1]);

                Person currentPerson = listPeople[currentPersonIndex];
                Product currentProduct = listProducts[currentProductIndex];

                if (currentPerson.Money >= currentProduct.Cost)
                {
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                    currentPerson.Money -= currentProduct.Cost;
                    currentPerson.ListOfProducts.Add(currentProduct);
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                }
            }

            foreach (var person in listPeople)
            {

                if (person.ListOfProducts.Count != 0)
                {
                    Console.Write($"{person.Name} - ");
                    Console.Write($"{string.Join(", ", person.ListOfProducts.Select(i => i.Name))}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }

        }
    }
}