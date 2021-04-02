using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public List<T> Data { get; set; }
        public int Count => this.Data.Count;

        public Box()
        {
            Data = new List<T>();
        }

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public T Remove()
        {
            var removeElement = Data[this.Count - 1];
            Data.RemoveAt(this.Count - 1);
            return removeElement;
        }
    }
}
