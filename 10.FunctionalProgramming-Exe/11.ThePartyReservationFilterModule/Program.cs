using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .ToList();

            string input = Console.ReadLine();
            List<string> removedGuests = new List<string>();

            while (input != "Print")
            {
                var command = input.Split(';', StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                string operation = command[0];
                string filterType = command[1];
                string filterParametre = command[2];

                AddOrRemoveFilter(guests, removedGuests, operation, filterType, filterParametre);

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ',guests));
        }

        private static void AddOrRemoveFilter(List<string> guests, List<string> removedGuests, string operation, string filterType, string filterParametre)
        {
            switch (operation)
            {
                case "Add filter":
                    if (filterType == "Starts with")
                    {
                        removedGuests.AddRange(guests.Where(name => name.StartsWith(filterParametre)));
                        guests.RemoveAll(names => names.StartsWith(filterParametre));
                    }
                    else if (filterType == "Ends with")
                    {
                        removedGuests.AddRange(guests.Where(name => name.EndsWith(filterParametre)));
                        guests.RemoveAll(names => names.EndsWith(filterParametre));
                    }
                    else if (filterType == "Length")
                    {
                        int lenght = int.Parse(filterParametre);

                        foreach (var guest in guests)
                        {
                            removedGuests.AddRange(guests.Where(name => guest.Length == lenght));
                            guests.RemoveAll(name => guest.Length == lenght);
                        }
                    }
                    else
                    {
                        removedGuests.AddRange(guests.Where(x => x.Contains(filterParametre)));
                        guests.RemoveAll(name => name.Contains(filterParametre));
                    }
                    break;
                case "Remove filter":
                    if (filterType == "Starts with")
                    {
                        guests.AddRange(removedGuests.Where(name => name.StartsWith(filterParametre)));
                    }
                    else if (filterType == "Ends with")
                    {
                        guests.AddRange(removedGuests.Where(name => name.EndsWith(filterParametre)));
                    }
                    else if (filterType == "Length")
                    {
                        int lenght = int.Parse(filterParametre);
                        foreach (var guest in removedGuests)
                        {
                            guests.AddRange(removedGuests.Where(name => guest.Length == lenght));
                        }
                    }
                    else
                    {
                        guests.AddRange(removedGuests.Where(name => name.Contains(filterParametre)));
                    }
                    break;
            }
        }
    }
}
