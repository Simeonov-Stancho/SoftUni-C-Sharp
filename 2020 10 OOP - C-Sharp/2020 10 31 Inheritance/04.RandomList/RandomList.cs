using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public Random rand;

        public RandomList()
        {
            rand = new Random();
        }

        public string RandomString()
        {
            int index = rand.Next(0, this.Count);
            string removedElement = this[index];
            this.RemoveAt(index);

            return removedElement;
        }
    }
}
