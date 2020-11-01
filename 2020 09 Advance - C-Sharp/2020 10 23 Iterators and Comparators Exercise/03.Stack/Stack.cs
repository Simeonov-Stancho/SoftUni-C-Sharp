using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> data;

        public Stack()
        {
            this.Data = new List<T>();
        }

        public List<T> Data { get; set; }

        public void Push(T element)
        {
            this.Data.Add(element);
        }

        public void Pop()
        {
            if (this.Data.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            this.Data.RemoveAt(this.Data.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Data.Count - 1; i >= 0; i--)
            {
                yield return this.Data[i];
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
