using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Trainer> trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                List<Pokemon> pokemons = new List<Pokemon>();

                string[] info = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                Trainer currentTrainer = new Trainer();
                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                bool matches = trainers.Exists(t => t.Name == trainerName);
                if (!matches)
                {
                    pokemons.Add(currentPokemon);
                    currentTrainer = new Trainer(trainerName, 0, pokemons);
                    trainers.Add(currentTrainer);
                }

                else
                {
                    int index = trainers.FindIndex(t => t.Name == trainerName);
                    trainers[index].Pokemon.Add(currentPokemon);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    bool matches = trainer.Pokemon.Exists(t => t.Element == input);

                    if (matches)
                    {
                        trainer.NumberOfBadges += 1;
                    }

                    else
                    {
                        for (int i = 0; i < trainer.Pokemon.Count; i++)
                        {
                            var currentPokemon = trainer.Pokemon[i];
                            currentPokemon.Health -= 10;

                            if (currentPokemon.Health <= 0)
                            {
                                trainer.Pokemon.Remove(currentPokemon);
                                i--;
                            }
                        }
                    }
                }
            }

            trainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemon.Count}");
            }
        }
    }
}