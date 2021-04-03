using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
    {
        public List<T> Value { get; set; }

        public Box()
        {
            Value = new List<T>();
        }

        public void Swap(int oldIndex, int newIndex)
        {
            var element = Value[oldIndex];
            Value[oldIndex] = Value[newIndex];
            Value[newIndex] = element;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Value)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString();
        }
    }
}
