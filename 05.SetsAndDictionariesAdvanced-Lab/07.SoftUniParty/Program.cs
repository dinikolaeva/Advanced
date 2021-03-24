using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var VIPReservationNumbers = new HashSet<string>();
            var regularReservationNumbers = new HashSet<string>();

            while (input != "PARTY")
            {
                char[] currentCommand = input.ToCharArray();

                if (char.IsDigit(currentCommand[0]))
                {
                    VIPReservationNumbers.Add(input);
                }
                else
                {
                    regularReservationNumbers.Add(input);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                char[] currentCommand = input.ToCharArray();

                if (char.IsDigit(currentCommand[0]))
                {
                    VIPReservationNumbers.Remove(input);
                }
                else
                {
                    regularReservationNumbers.Remove(input);
                }

                input = Console.ReadLine();
            }

            int count = VIPReservationNumbers.Count + regularReservationNumbers.Count;

            Console.WriteLine(count);

            foreach (var VIP in VIPReservationNumbers)
            {
                Console.WriteLine(VIP);
            }
            foreach (var regular in regularReservationNumbers)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
