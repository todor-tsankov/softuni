using System;
using System.Linq;

namespace ValidationAttributes.Models.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            var result = false;

            if ( obj != null)
            {
                result = true;
            }

            return result;
        }
    }
}
