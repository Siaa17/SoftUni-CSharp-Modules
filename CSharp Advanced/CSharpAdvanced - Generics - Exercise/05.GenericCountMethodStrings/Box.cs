using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    public class Box<T> where T : IComparable<T>
    {
        public Box(List<T> elements)
        {
            this.Elements = elements;
        }

        public Box(T element)
        {
            this.Element = element;
        }

        public List<T> Elements { get; }

        public T Element { get; }

        public int CompareTo(T other) => this.Element.CompareTo(other);

        public int CountOfElementsGraterThan(T inputElement)
        {
            int counter = 0;

            foreach (T element in this.Elements)
            {
                if (element.CompareTo(inputElement) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
