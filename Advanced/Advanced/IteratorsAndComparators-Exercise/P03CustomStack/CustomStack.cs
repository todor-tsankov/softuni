using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P03CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private StackNode<T> firstElement;

        private int Count;

        public void Push(IEnumerable<T> elements)
        {
            foreach (var item in elements)
            {
                var savedFirstElement = this.firstElement;

                this.firstElement = new StackNode<T>(item);
                this.firstElement.nextNode = savedFirstElement;

                this.Count++;
            }
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            if (this.Count == 1)
            {
                var firstEL = this.firstElement.Value;
                this.firstElement = null;

                this.Count = 0;

                return firstEL;
            }

            var element = this.firstElement.Value;
            this.firstElement = this.firstElement.nextNode;

            this.Count--;

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var el = this.firstElement;

            while (el != null)
            {
                yield return el.Value;

                el = el.nextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
