using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
    {
        private const int DEFAULT_ADD_INDEX = 0;

        public override int Add(T item)
        {
            this.data.Insert(DEFAULT_ADD_INDEX, item);

            return DEFAULT_ADD_INDEX;
        }

        public virtual T Remove()
        {
            var item = this.data[^1];
            this.data.RemoveAt(this.data.Count - 1);

            return item;
        }
    }
}
