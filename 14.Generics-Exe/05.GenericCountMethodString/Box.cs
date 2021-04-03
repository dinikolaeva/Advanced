using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class Box<T>
        where T : IComparable
    {
        public List<T> Value { get; set; }

        public Box()
        {
            Value = new List<T>();
        }

        public int CountGreater(T element)
        {
            var greaterCount = 0;

            foreach (var item in Value)
            {
                if (item.CompareTo(element) > 0)
                {
                    greaterCount++;
                }
            }

            return greaterCount;
        }
    }
}
