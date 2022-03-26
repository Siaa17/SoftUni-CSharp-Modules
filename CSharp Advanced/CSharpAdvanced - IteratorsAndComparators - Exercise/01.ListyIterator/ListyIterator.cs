using System;
using System.Collections;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> itemsCollection;
        private int currentIndex;

        public ListyIterator(List<T> items)
        {
            this.itemsCollection = items;
            currentIndex = 0;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex++;

                return true;
            }

            return false;
        }

        public bool HasNext() => this.currentIndex < this.itemsCollection.Count - 1;

        public void Print()
        {
            if (this.itemsCollection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.itemsCollection[this.currentIndex]);
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", itemsCollection));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in itemsCollection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
