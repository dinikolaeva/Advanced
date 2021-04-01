using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public static bool CanCarMove(double fuelAmount, double amountOfKm, double fuelConsumptionPerKm)
        {
            double neededFuel = amountOfKm * fuelConsumptionPerKm;
            double leftFuel = fuelAmount-neededFuel;

            if (leftFuel < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
        }
    }
}
