using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Car
    {
        private string model;
        private Cargo cargo;
        private Engine engine;
        private Tires[] tires;

        public Car(string model, Cargo cargo, Engine engine, Tires[] tires)
        {
            this.Model = model;
            this.Cargo = cargo;
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Model 
        { 
            get => model; 
            set => model = value;
        }
        public Cargo Cargo { get; set; }
        public Engine Engine{ get; set; }
        public Tires[] Tires { get; set; }
    }
}
