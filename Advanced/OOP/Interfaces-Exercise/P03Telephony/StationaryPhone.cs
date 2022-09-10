using System;
using System.Linq;

namespace P03Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }
    }
}
