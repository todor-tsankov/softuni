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
        public int RemoveAt(int index)
        {
            CheckIfIndexIsValid(index);
            var item = Shift(index);

            this.Count--;
            ShrinkIfNeeded();

            return item;
        }
        public void Insert(int index, int item)
        {
            if (index != this.Count)
            {
                CheckIfIndexIsValid(index);
            }

            ResizeIfNeeded();
            ShiftToRight(index);

            this.items[index] = item;
            this.Count++;
        }
        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIfIndexIsValid(firstIndex);
            CheckIfIndexIsValid(secondIndex);

            var first = this.items[firstIndex];

            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = first;
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
        private bool ShrinkIfNeeded()
        {
            var currentLength = this.items.Length;

            if (this.Count >= this.items.Length / 4)
            {
                return false;
            }

            var newLength = currentLength / 2;
            var newArr = new int[newLength];

            for (int i = 0; i < newLength; i++)
            {
                newArr[i] = this.items[i];
            }

            this.items = newArr;

            return true;
        }
        private int Shift(int index)
        {
            var item = this.items[index];

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            return item;
        }
        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i >= index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        private void CheckIfIndexIsValid(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index was outside the boundaries of the list!");
            }
        }
    }
}
