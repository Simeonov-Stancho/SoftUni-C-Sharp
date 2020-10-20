using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] data = new T[length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = item;
            }

            return data;
        }
    }
}
