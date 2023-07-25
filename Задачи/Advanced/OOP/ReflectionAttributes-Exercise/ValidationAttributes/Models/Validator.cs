using System;
using System.Linq;

using ValidationAttributes.Models.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType()
                                .GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false)
                                         .Where(a => a is MyValidationAttribute)
                                         .Cast<MyValidationAttribute>()
                                         .ToArray();

                foreach (var attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
