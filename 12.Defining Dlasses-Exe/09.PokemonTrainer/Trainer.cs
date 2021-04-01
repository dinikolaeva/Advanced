using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.CollectionOfPokemons = new List<Pokemon>();
        }

        public string Name { get ; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemons { get; set; }
    }
}
