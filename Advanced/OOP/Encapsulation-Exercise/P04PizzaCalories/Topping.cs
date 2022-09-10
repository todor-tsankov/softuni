using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories
{
    public class Topping
    {
        private const double MEAT_MODIFIER = 1.2;
        private const double VEGGIES_MODIFIER = 0.8;
        private const double CHEESE_MODIFIER = 1.1;
        private const double SAUCE_MODIFIER = 0.9;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            ValidateArguments(type, weight);

            this.type = type.ToLower();
            this.weight = weight;
        }

        public double TotalCalories
        {
            get
            {
                return this.GetCaloriesPerGram() * this.weight;
            }
        }

        private static void ValidateArguments(string type, double weight)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException("Topping type cannot be null, emtpy or whitespace");
            }

            if (type != "meat" && type != "veggies" && type != "cheese" && type != "sauce" &&
                type != "Meat" && type != "Veggies" && type != "Cheese" && type != "Sauce")
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }

            if (weight < 1 || weight > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }
        }

        private double GetCaloriesPerGram()
        {
            var result = 2.0;

            if (this.type == "meat")
            {
                result *= MEAT_MODIFIER;
            }
            else if (this.type == "veggies")
            {
                result *= VEGGIES_MODIFIER;
            }
            if (this.type == "cheese")
            {
                result *= CHEESE_MODIFIER;
            }
            else if (this.type == "sauce")
            {
                result *= SAUCE_MODIFIER;
            }

            return result;
        }
    }
}
