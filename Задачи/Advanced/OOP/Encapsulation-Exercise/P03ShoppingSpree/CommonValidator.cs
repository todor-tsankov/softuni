using System;

namespace P03ShoppingSpree
{
    public class CommonValidator
    {
        public static void ValidateName(string name, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{propertyName} cannot be empty");
            }
        }

        public static void ValidateMoney(decimal money, string propertyName)
        {
            if (money < 0)
            {
                throw new ArgumentException($"{propertyName} cannot be negative");
            }
        }
    }
}
