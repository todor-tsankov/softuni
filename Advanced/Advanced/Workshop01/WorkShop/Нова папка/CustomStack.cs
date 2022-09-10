using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop
{
    public class CustomStack
    {
        private const int intitialCapacity = 4;
        private int[] items;
        
        public CustomStack(int capacity = intitialCapacity)
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

        public void Push(int element)
        {
            ResizeIfNeeded();

            this.items[this.Count] = element;

            this.Count++;
        }
        public int Pop()
        {
            CheckForEmpyStack();
            this.Count--;

            return this.items[this.Count];
        }
        public int Peek()
        {
            CheckForEmpyStack();

            return this.items[this.Count - 1];
        }
        public void ForEach(Action<object> action)
        {
            CheckForEmpyStack();

            var customStack = new CustomStack();

            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
        private void CheckForEmpyStack()
        {
            if (this.Count == 0)
            {
                throw new Exception("The stack is empty!");
            }
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
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index was outside the boundaries of the list!");
            }
        }
    }
}
