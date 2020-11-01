using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        public Box(List<T> data)
        {
            this.Data = data;
        }

        public List<T> Data { get; set; }

        public void SwapElements(int firstIndex, int secondIndex)
        {
            T firstToSwap = this.Data[firstIndex];
            this.Data[firstIndex] = this.Data[secondIndex];
            this.Data[secondIndex] = firstToSwap;
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
