using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left,T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public T Left { get; }
        public T Right { get; }

        public bool AreEqual()
        {
            bool result = this.Left.Equals(this.Right);
            return result;
        }
    }
}
