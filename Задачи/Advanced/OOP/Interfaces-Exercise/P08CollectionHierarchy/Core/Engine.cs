using System;
using System.Collections.Generic;
using CollectionHierarchy.Models;
using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        public void Run()
        {
            var addCollection = new AddCollection<string>();
            var addRemoveCollection = new AddRemoveCollection<string>();
            var myList = new MyList<string>();

            var strings = Console.ReadLine()
                                 .Split();

            var removeOperationsCount = int.Parse(Console.ReadLine());

            Add(addCollection, strings);
            Add(addRemoveCollection, strings);
            Add(myList, strings);

            Remove(addRemoveCollection, removeOperationsCount);
            Remove(myList, removeOperationsCount);
        }

        private void Add<T>(IAddCollection<T> collection, T[] strings)
        {
            foreach (var text in strings)
            {
                var index = collection.Add(text);

                Console.Write(index + " ");
            }

            Console.WriteLine();
        }
        private void Remove<T>(IAddRemoveCollection<T> collection, int removeOperationsCount)
        {
            for (int i = 0; i < removeOperationsCount; i++)
            {
                var removedItem = collection.Remove();

                Console.Write(removedItem + " ");
            }

            Console.WriteLine();
        }
    }
}
