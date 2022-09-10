using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;
        public ListyIterator(IEnumerable<T> elements)
        {
            this.index = 0;

            this.elements = elements.ToList();
        }
        private List<T> elements { get;}

        public bool Move()
        {
            if (this.index + 1 < this.elements.Count)
            {
                this.index++;

                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index + 1 < this.elements.Count)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[index]);
        }
        public void PrintAll()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            foreach (var el in this.elements)
            {
                Console.Write(el + " ");
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.elements.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
