using System;
using System.Globalization;

namespace SnakeGame.Common
{
    public static class CommonValidator
    {
        public static void ValidateRange(int element, int minValue, int maxValue, string paramName)
        {
            if (element < minValue || element > maxValue)
            {
                var message = string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentOutOfRange, new object[] { paramName, minValue, maxValue });

                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void ValidateForNull(object obj, string paramName)
        {
            if (obj == null)
            {
                var message = string.Format(CultureInfo.InvariantCulture, ExceptionMessages.ArgumentNull, paramName);

                throw new ArgumentNullException(message);
            }
        }
    }
}
