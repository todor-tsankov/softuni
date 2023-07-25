using System;
using System.Collections.Generic;
using System.Text;

namespace P04PizzaCalories
{
    public class Dough
    {
        private const double WHITE_MODIFIER = 1.5;
        private const double WHOLEGRAIN_MODIFIER = 1.0;
        private const double CRISPY_MODIFIER = 0.9;
        private const double CHEWY_MODIFIER = 1.1;
        private const double HOMEMODE_MODIFIER = 1.0;
        
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string type, string technique, double weight)
        {
            var typeLowercase = type.ToLower();
            var techniqueLowercase = technique.ToLower();

            ValidateArguments(typeLowercase.ToLower(), techniqueLowercase, weight);

            this.flourType = typeLowercase;
            this.bakingTechnique = techniqueLowercase;
            this.weight = weight;
        }

        public double TotalCalories
        {
            get
            {
                return this.GetCaloriesPerGram() * this.weight;
            }
        }

        private double GetCaloriesPerGram()
        {
            var result = 2.0;

            if (this.flourType == "white")
            {
                result *= WHITE_MODIFIER;
            }
            else if (this.flourType == "wholegrain")
            {
                result *= WHOLEGRAIN_MODIFIER;
            }

            if (this.bakingTechnique == "crispy")
            {
                result *= CRISPY_MODIFIER;
            }
            else if (this.bakingTechnique == "chewy")
            {
                result *= CHEWY_MODIFIER;
            }
            else if (this.bakingTechnique == "homemade")
            {
                result *= HOMEMODE_MODIFIER;
            }

            return result;
        }

        private static void ValidateArguments(string type, string technique, double weight)
        {
            var invalidDough = false;

            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(technique))
            {
                invalidDough = true;
            }
            else if (type != "white" && type != "wholegrain")
            {
                invalidDough = true;
            }
            else if (technique != "crispy" && technique != "chewy" && technique != "homemade")
            {
                invalidDough = true;
            }

            if (invalidDough)
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            if (weight < 1 || weight > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
        }
    }
}
