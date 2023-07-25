using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            var result = firstBook.Title.CompareTo(secondBook.Title);

            if (result == 0)
            {
                return secondBook.Year.CompareTo(firstBook.Year);
            }

            return result;
        }
    }
}
