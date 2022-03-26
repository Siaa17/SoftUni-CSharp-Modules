using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;

        public Stack()
        {
            this.collection = new List<T>();
        }

        public int Count => this.collection.Count;

        public void Push(T element)
        {
            this.collection.Add(element);
        }

        public T Pop()
        {
            T element = this.collection[this.collection.Count - 1];
            //T element = this.collection[^1];

            this.collection.Remove(element);

            return element;          
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.collection.Count - 1; i >= 0; i--)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();        
    }
}
