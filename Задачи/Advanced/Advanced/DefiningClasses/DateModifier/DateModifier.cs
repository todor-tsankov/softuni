using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        private int differenceDays;

        public int DifferenceDays
        {
            get
            {
                return this.differenceDays;
            }
            set
            {
                this.differenceDays = value;
            }
        }

        public int FindDifferenceDays(string firstDate, string secondDate)
        {
            var firstDateInfo = firstDate.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();

            var firstDateYear = firstDateInfo[0];
            var firstDateMonth = firstDateInfo[1];
            var firstDateDay = firstDateInfo[2];

            var date1 = new DateTime(firstDateYear, firstDateMonth, firstDateDay);

            var secondDateInfo = secondDate.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();

            var secondDateYear = secondDateInfo[0];
            var secondDateMonth = secondDateInfo[1];
            var secondtDateDay = secondDateInfo[2];

            var date2 = new DateTime(secondDateYear, secondDateMonth, secondtDateDay);

            return Math.Abs((date1 - date2).Days);
        }
    }
}
