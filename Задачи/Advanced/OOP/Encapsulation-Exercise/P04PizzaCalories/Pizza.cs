using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        private Pizza()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name, Dough dough)
            : this()
        {
            if (dough == null)
            {
                throw new ArgumentException();
            }

            this.Name = name;
            this.dough = dough;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                if (value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }
        public int NumberOfToppings => this.toppings.Count;
        public double TotalCalories => this.GetTotalCalories();

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new InvalidOperationException("Number of toppings should be in range [0..10].");
            }

            if (topping == null)
            {
                throw new ArgumentException();
            }

            this.toppings.Add(topping);
        }

        private double GetTotalCalories()
        {
            var totalCalories = dough.TotalCalories;
            toppings.ForEach(t => totalCalories += t.TotalCalories);

            return totalCalories;
        }
    }
}
