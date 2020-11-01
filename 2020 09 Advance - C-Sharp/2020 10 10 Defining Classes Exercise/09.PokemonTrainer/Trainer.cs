using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemon;

        public Trainer()
        {

        }

        public Trainer(string name, int numberOfBadges, List<Pokemon> pokemon) :this()
        {
            this.Name = name;
            this.NumberOfBadges = numberOfBadges;
            this.Pokemon = pokemon;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemon { get; set; }
    }
}
