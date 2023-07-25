using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, List<Pokemon> pokemon)
        {
            this.Name = name;
            this.Pokemon = pokemon;
            this.NumberOfBadges = 0;
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemon { get; set; }
    }
}
