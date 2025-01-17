﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }
        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            bool isTrue = this.Weight == 0;
            bool isTrueEngine = this.Engine.Displacement == 0;
            result.AppendLine($"{Model}:");
            result.AppendLine($"  {Engine.Model}:");
            result.AppendLine($"   Power: {Engine.Power}");
            result.AppendLine(isTrueEngine ? "   Displacement: n/a" : $"   Displacement: {Engine.Displacement}");
            result.AppendLine($"   Efficiency: {Engine.Efficiency}");
            result.AppendLine(isTrue ? $"  Weight: n/a" : $"  Weight: {Weight}");
            result.Append($"  Color: {Color}");
            return result.ToString();
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
    }
}
