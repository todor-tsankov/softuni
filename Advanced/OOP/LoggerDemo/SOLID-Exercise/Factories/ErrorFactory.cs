using System;
using System.Globalization;

using SOLID_Exercise.Models.Errors;
using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Enumerations;

namespace SOLID_Exercise.Factories
{
    public class ErrorFactory
    {
        private const string DATE_FORMAT = "M/dd/yyyy h:mm:ss tt";
        public IError ProduceError(string dateStr, string message, string levelStr)
        {
            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateStr, DATE_FORMAT, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid date format!", e);
            }

            var hasParsed = Enum.TryParse<Level>(levelStr, true, out Level level);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid level!");
            }

            IError error = new Error(dateTime, message, level);

            return error;
        }
    }
}
