using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
       public static T[] Create<T>(int size, T element)
        {
            T[] arr = new T[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = element;
            }
            return arr;
        }
    }
}
