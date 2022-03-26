using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodStrings
{
    public class Box<T>
    {
        public Box(List<T> elements)
        {
            this.Elements = elements;
        }

        public List<T> Elements { get; private set; }

        public void Swap(List<T> elements, int firstIndex, int secondIndex)
        {
            T firstElement = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstElement;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T element in this.Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
