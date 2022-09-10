using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    class Person
    {
        public Person(string personInformation)
        {
            ListOfProducts = new List<Product>();
            string[] personalInfoParts = personInformation.Split('=');
            Name = personalInfoParts[0];
            Money = double.Parse(personalInfoParts[1]);
        }

        public string Name { get; set; }
        public double Money { get; set; }
        public List<Product> ListOfProducts { get; set; }
    }
}
