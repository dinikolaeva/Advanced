using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();

            while (input != "Tournament")
            {
                var command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = command[0];
                string pokemonName = command[1];
                string element = command[2];
                int helth = int.Parse(command[3]);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    var trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                var existingTrainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                if (!existingTrainer.CollectionOfPokemons.Any(x => x.Name == pokemonName))
                {
                    var currentPokemon = new Pokemon(pokemonName, element, helth);
                    existingTrainer.CollectionOfPokemons.Add(currentPokemon);
                }
                else
                {
                    existingTrainer.CollectionOfPokemons.FirstOrDefault(x => x.Name == pokemonName).Element = element;
                    existingTrainer.CollectionOfPokemons.FirstOrDefault(x => x.Name == pokemonName).Helth += helth;
                }

                input = Console.ReadLine();
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                foreach (Trainer currentTrainer in trainers)
                {
                    if (currentTrainer.CollectionOfPokemons.Any(x => x.Element == line))
                    {
                        currentTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (Pokemon currentPokemon in currentTrainer.CollectionOfPokemons)
                        {
                            currentPokemon.Helth -= 10;
                        }

                        for (int i = 0; i < currentTrainer.CollectionOfPokemons.Count; i++)
                        {
                            if (currentTrainer.CollectionOfPokemons[i].Helth <= 0)
                            {
                                currentTrainer.CollectionOfPokemons.RemoveAt(i);
                                i++;
                            }
                        }
                    }
                }

                line = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemons.Count}");
            }
        }
    }
}
