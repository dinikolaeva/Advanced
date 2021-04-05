using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private int index;
        private List<T> collection;

        public ListyIterator(List<T> elements)
        {
            this.index = 0;
            this.collection = elements;
        }
        public int Count { get => this.collection.Count; }

        public bool HasNext()
        {
            if (index < Count - 1)
            {
                return true;
            }
            return false;
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.collection[this.index]);
        }
    }
}
