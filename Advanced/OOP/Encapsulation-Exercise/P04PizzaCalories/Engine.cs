using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04PizzaCalories
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                var pizza = CreatePizza();

                AddToppings(pizza);
                Console.WriteLine(pizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private Dough CreateDough()
        {
            var doughInfoArgs = ReadInputLine();

            var doughType = doughInfoArgs[1];
            var doughTechnique = doughInfoArgs[2];
            var doughWeight = double.Parse(doughInfoArgs[3]);

            var dough = new Dough(doughType, doughTechnique, doughWeight);

            return dough;
        }
        private Pizza CreatePizza()
        {

            var pizzaInfoArgs = ReadInputLine();
            var pizzaName = pizzaInfoArgs[1];

            var dough = CreateDough();

            var pizza = new Pizza(pizzaName, dough);

            return pizza;
        }
        private void AddToppings(Pizza pizza)
        {
            while (true)
            {
                var toppingInfo = Console.ReadLine();

                if (toppingInfo == "END")
                {
                    break;
                }

                var toppinfInfoArgs = toppingInfo.Split()
                                                 .ToArray();

                var toppingType = toppinfInfoArgs[1];
                var toppingWeight = double.Parse(toppinfInfoArgs[2]);

                var topping = new Topping(toppingType, toppingWeight);

                pizza.AddTopping(topping);
            }
        }

        private string[] ReadInputLine()
        {
            return Console.ReadLine()
                          .Split()
                          .ToArray();
        }
    }
}
