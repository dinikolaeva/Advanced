﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name, string element, int helth)
        {
            this.Name = name;
            this.Element = element;
            this.Helth = helth;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Helth { get; set; }
    }
}
