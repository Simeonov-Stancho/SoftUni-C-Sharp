using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private int index;
        private List<T> data;

        public ListyIterator(params T[] data)
        {
            this.index = 0;
            this.Data = new List<T>(data);
        }

        public List<T> Data { get; set; }

        public bool HasNext()
        {
            return this.index < this.Data.Count - 1;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (this.Data.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.Data[this.index]);
        }
    }
}
