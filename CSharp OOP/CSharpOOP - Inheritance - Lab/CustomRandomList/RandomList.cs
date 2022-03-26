using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random rnd;

        public RandomList()
        {
            this.rnd = new Random();
        }

        public string RandomString()
        {
            int index = rnd.Next(0, this.Count);
            this.RemoveAt(index);
            string removedElement = this[index];

            return removedElement;
        }
    }
}
