using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var infoForCars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = infoForCars[0];
                int engineSpeed = int.Parse(infoForCars[1]);
                int enginePower = int.Parse(infoForCars[2]);
                int cargoWeight = int.Parse(infoForCars[3]);
                string cargoType = infoForCars[4];
                double pressure1Tire = double.Parse(infoForCars[5]);
                int age1Tire = int.Parse(infoForCars[6]);
                double pressure2Tire = double.Parse(infoForCars[7]);
                int age2Tire = int.Parse(infoForCars[8]);
                double pressure3Tire = double.Parse(infoForCars[9]);
                int age3Tire = int.Parse(infoForCars[10]);
                double pressure4Tire = double.Parse(infoForCars[11]);
                int age4Tire = int.Parse(infoForCars[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tires[] tires = new Tires[4];
                {
                    tires[0] = new Tires(pressure1Tire, age1Tire);
                    tires[1] = new Tires(pressure2Tire, age2Tire);
                    tires[2] = new Tires(pressure3Tire, age3Tire);
                    tires[3] = new Tires(pressure4Tire, age4Tire);
                }

                Car currensCar = new Car(model, cargo, engine, tires);
                cars.Add(currensCar);
            }

            string input = Console.ReadLine();

            if (input == "fragile")
            {
                foreach (Car currentCar in cars.Where(x => x.Cargo.CargoType == "fragile"))
                {
                    if (currentCar.Tires.Any(x => x.TirePressure < 1))
                    {
                        Console.WriteLine($"{currentCar.Model}");
                    }
                }
            }
            
            if (input == "flamable")
            {
                foreach (Car currentCar in cars.Where(x => x.Cargo.CargoType == "flamable")
                                               .Where(x => x.Engine.EnginePower > 250))
                {
                    Console.WriteLine($"{currentCar.Model}");
                }
            }
        }
    }
}
