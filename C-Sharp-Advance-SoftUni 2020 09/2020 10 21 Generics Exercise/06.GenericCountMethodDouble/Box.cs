using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        public Box(List<T> data)
        {
            this.Data = data;
        }

        public List<T> Data { get; set; }

        public int ReturnCount(T value)
        {
            int count = 0;
            foreach (var item in this.Data)
            {
                if (item.CompareTo(value) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.Data)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString();
        }
    }
}
