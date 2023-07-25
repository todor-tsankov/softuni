using System;
using System.Collections.Generic;
using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddCollection<T> : IAddCollection<T>
    {
        private const int DEFAULT_SIZE = 100;

        protected List<T> data;

        public AddCollection()
        {
            this.data = new List<T>(DEFAULT_SIZE);
        }

        public virtual int Add(T item)
        {
            this.data.Add(item);

            return this.data.Count - 1;
        }
    }
}
