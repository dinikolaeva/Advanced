using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);

                Car newCar = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(newCar);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                var info = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var carModel = info[1];
                double amountOfKm = double.Parse(info[2]);

                foreach (Car currentCar in cars)
                {
                    if (carModel == currentCar.Model)
                    {
                        if (Car.CanCarMove(currentCar.FuelAmount, amountOfKm, currentCar.FuelConsumptionPerKilometer))
                        {
                            currentCar.FuelAmount -= (amountOfKm * currentCar.FuelConsumptionPerKilometer);
                            currentCar.TravelledDistance += amountOfKm;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                            break;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (Car currentCar in cars)
            {
                Console.WriteLine($"{currentCar.Model} {currentCar.FuelAmount:f2} {currentCar.TravelledDistance}");
            }
        }
    }
}
