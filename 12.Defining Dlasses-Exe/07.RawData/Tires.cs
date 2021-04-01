using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tires
    {
        private double tirePressure;
        private int age;

        public Tires(double tirePressure, int age) 
        {
            this.Age = age;
            this.TirePressure = tirePressure;
        }

        public double TirePressure { get => tirePressure; set => tirePressure = value; }
        public int Age { get => age; set => age = value; }
    }
}
