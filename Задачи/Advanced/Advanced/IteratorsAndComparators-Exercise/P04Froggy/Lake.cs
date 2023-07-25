using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace P04Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(IEnumerable<int> items)
        {
            this.Items = new List<int>(items);
        }
        public List<int> Items { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                yield return this.Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
