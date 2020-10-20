using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.Data = new List<T>();
        }

        public List<T> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove()
        {
            T last = this.data.Last();
            this.data.RemoveAt(this.data.Count - 1);
            return last;
        }

        public int Count
        {
            get { return this.data.Count; }
        }
    }
}
