using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        private const int DEFAULT_REMOVE_INDEX = 0;

        public int Used => this.data.Count;

        public override T Remove()
        {
            var item = this.data[DEFAULT_REMOVE_INDEX];
            this.data.RemoveAt(DEFAULT_REMOVE_INDEX);

            return item;
        }
    }
}
