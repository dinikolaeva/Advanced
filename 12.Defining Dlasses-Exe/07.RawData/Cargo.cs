using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Cargo
    {
        private string cargoType;
        private int cargoWeight;

        public Cargo(string cargoType, int cargoWeight)
        {
            this.CargoType = cargoType;
            this.CargoWeight = cargoWeight;
        }

        public string CargoType
        {
            get { return this.cargoType; }
            set { this.cargoType = value; }
        }
        public int CargoWeight
        {
            get { return this.cargoWeight; }
            set { this.cargoWeight = value; }
        }
    }
}
