using System;
using System.Collections.Generic;
using System.Text;

namespace P05GenericCountMethodStrings
{
    public class Box<T>
    {
        public Box(T item)
        {
            this.Item = item;
        }
        public T Item { get; set; }

        public override string ToString()
        {
            return $"{this.Item.GetType()}: {this.Item}";
        }

        public bool IsGreaterThan(T element)
        {
            if (element is int intEl && this.Item is int intItem)
            {
                return intItem > intEl;
            }

            if (element is double doubleEl && this.Item is double doubleItem)
            {
                return doubleItem > doubleEl;
            }

            if (element is string stringEl && this.Item is string stringItem)
            {
                if (stringItem.CompareTo(stringEl) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
