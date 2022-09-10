using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    public class ListNode<Т>
    {
        public ListNode(Т value)
        {
            this.Value = value;
        }
        public Т Value { get; set; }
        public ListNode<Т> PreviousNode { get; set; }
        public ListNode<Т> NextNode { get; set; }
    }
}
