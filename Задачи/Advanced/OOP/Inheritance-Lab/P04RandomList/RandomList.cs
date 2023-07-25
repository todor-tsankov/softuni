using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            var random = new Random();
            var index = random.Next(0, this.Count);

            var removedItem = this[index];
            this.RemoveAt(index);

            return removedItem;
        }
    }
}
