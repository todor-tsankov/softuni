using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop
{
    public class CustomList
    {
        private const int intitalCapacity = 2;
        private int[] items;

        public CustomList(int capacity = intitalCapacity)
        {
            this.items = new int[capacity];

            this.Count = 0;
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                CheckIfIndexIsValid(index);

                return this.items[index];
            }
            set
            {
                CheckIfIndexIsValid(index);

                this.items[index] = value;
            }
        }

        public void Add(int element)
        {
            ResizeIfNeeded();

            this.items[this.Count] = element;
            this.Count++;
        }
        private bool ResizeIfNeeded()
        {
            var currentLength = this.items.Length;

            if (this.Count < currentLength)
            {
                return false;
            }

            var newLength = currentLength * 2;

            var newArrray = new int[newLength];

            for (int i = 0; i < currentLength; i++)
            {
                newArrray[i] = this.items[i];
            }

            this.items = newArrray;
            return true;
        }
        private void CheckIfIndexIsValid(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException("Index was outside the boundaries of the list!");
            }
        }
    }
}
