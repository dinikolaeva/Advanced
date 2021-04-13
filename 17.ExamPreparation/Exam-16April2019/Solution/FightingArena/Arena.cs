﻿using System.Collections.Generic;
using System.Linq;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }
        public int Count { get => this.gladiators.Count; }

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var gladiatorToRemove = this.gladiators.FirstOrDefault(g => g.Name == name);
            this.gladiators.Remove(gladiatorToRemove);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            return this.gladiators.OrderByDescending(g => g.GetStatPower()).FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return this.gladiators.OrderByDescending(g => g.GetWeaponPower()).FirstOrDefault();
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return this.gladiators.OrderByDescending(g => g.GetTotalPower()).FirstOrDefault();
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
