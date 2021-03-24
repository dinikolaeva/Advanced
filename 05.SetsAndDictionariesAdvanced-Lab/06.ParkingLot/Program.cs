using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var carsInParkingLot = new HashSet<string>();

            while (input != "END")
            {                
                var currentCarInfo = Regex.Split(input, ", ");

                if (currentCarInfo[0] == "IN")
                {
                    carsInParkingLot.Add(currentCarInfo[1]);
                }
                else
                {
                    carsInParkingLot.Remove(currentCarInfo[1]);
                }

                input = Console.ReadLine();
            }

            if (carsInParkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in carsInParkingLot)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
