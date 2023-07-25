using System;
using System.Collections.Generic;
using System.Text;

namespace P03CustomStack
{
    public class StackNode<T>
    {
        public StackNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public StackNode<T> nextNode { get; set; }
    }
}
