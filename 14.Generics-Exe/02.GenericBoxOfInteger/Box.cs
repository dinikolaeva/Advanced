﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {
        public T Value { get; set; }

        public Box(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }
    }
}
