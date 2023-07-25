using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();

            ReadTrainers(trainers);

            var trainersList = trainers.Values.ToList();

            PlayTournament(trainersList);
            SortAndPrint(trainersList);
        }

        private static void SortAndPrint(List<Trainer> trainersList)
        {
            trainersList.OrderByDescending(t => t.NumberOfBadges)
                                    .ToList()
                                    .ForEach(t => Console.WriteLine($"{t.Name} {t.NumberOfBadges} {t.Pokemon.Count}"));
        }

        private static void PlayTournament(List<Trainer> trainersList)
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                for (int i = 0; i < trainersList.Count; i++)
                {
                    var currentTrainer = trainersList[i];

                    if (currentTrainer.Pokemon.Any(p => p.Element == command))
                    {
                        currentTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        var pokemon = currentTrainer.Pokemon;

                        for (int j = 0; j < pokemon.Count; j++)
                        {
                            var currentPokemon = pokemon[j];

                            currentPokemon.Health -= 10;

                            if (currentPokemon.Health <= 0)
                            {
                                pokemon.RemoveAt(j);
                            }
                        }
                    }
                }
            }
        }

        private static void ReadTrainers(Dictionary<string, Trainer> trainers)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Tournament")
                {
                    break;
                }

                var infoArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var trainerName = infoArgs[0];

                var pokemonName = infoArgs[1];
                var pokemonElement = infoArgs[2];
                var pokemonHealth = double.Parse(infoArgs[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName, new List<Pokemon>());
                }

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainers[trainerName].Pokemon.Add(pokemon);
            }
        }
    }
}
