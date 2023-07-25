using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class CommonValidator
    {
        public static void ValidateForNull(string item, string text)
        {
            if (item == null)
            {
                throw new ArgumentException(text);
            }
        }

        public static void ValidateLength(string item, int minLength, string text)
        {
            ValidateForNull(item, text);

            if (item.Length < minLength)
            {
                throw new ArgumentException(text);
            }
        }

        public static void ValidateMin<T>(T item, T minLength, string text)
            where T : IComparable
        {
            if (item.CompareTo(minLength) < 0)
            {
                throw new ArgumentException(text);
            }
        }
    }
}
