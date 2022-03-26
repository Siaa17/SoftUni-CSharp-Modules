using System;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T element)
        {
            this.Element = element;
        }

        public T Element { get; private set; }

        public override string ToString()
        {
            return $"{this.Element.GetType()}: {this.Element}";
        }
    }
}
