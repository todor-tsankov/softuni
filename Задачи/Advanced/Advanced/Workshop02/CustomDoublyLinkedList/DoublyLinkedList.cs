using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    class DoublyLinkedList<Т>
    {
        private ListNode<Т> head;
        private ListNode<Т> tail;
        
        public int Count { get; private set; }

        public void AddFirst(Т element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<Т>(element);
            }
            else
            {
                var newHead = new ListNode<Т>(element);
                var oldHead = this.head;

                oldHead.PreviousNode = newHead;
                newHead.NextNode = oldHead;

                this.head = newHead;
            }

            this.Count++;
        }
        public void AddLast(Т element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<Т>(element);
            }
            else
            {
                var newTail = new ListNode<Т>(element);
                var oldTail = this.tail;

                oldTail.NextNode = newTail;
                newTail.PreviousNode = oldTail;

                this.tail = newTail;
            }

            this.Count++;
        }
        public Т RemoveFirst()
        {
            CheckIfListIsEmpty();

            Т element = this.head.Value;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
                this.head.PreviousNode = null;
            }

            this.Count--;

            return element;
        }
        public Т RemoveLast()
        {
            CheckIfListIsEmpty();

            Т element = this.tail.Value;

            if (this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = this.tail.PreviousNode;
                this.tail.NextNode = null;
            }

            this.Count--;

            return element;
        }
        public void ForEach(Action<Т> action)
        {
            var currentElement = this.head;

            while (currentElement != null)
            {
                action(currentElement.Value);

                currentElement = currentElement.NextNode;
            }
        }
        public Т[] ToArray()
        {
            var count = this.Count;
            var array = new Т[count];

            var currentElement = this.head;

            for (int i = 0; i < count; i++)
            {
                if (currentElement != null)
                {
                    array[i] = currentElement.Value;
                }
                else
                {
                    break;
                }

                currentElement = currentElement.NextNode;
            }

            return array;
        }

        private void CheckIfListIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("The list is empty!");
            }
        }
    }
}
