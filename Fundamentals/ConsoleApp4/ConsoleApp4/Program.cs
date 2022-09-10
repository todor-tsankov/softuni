using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDontGo
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<int> pokemonList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;

            while (pokemonList.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int currentElement = 0;

                if (index < 0)
                {
                    currentElement = pokemonList[0];
                    pokemonList[0] = pokemonList[pokemonList.Count - 1];
                }
                else if (index >= pokemonList.Count)
                {
                    currentElement = pokemonList[pokemonList.Count - 1];
                    pokemonList[pokemonList.Count - 1] = pokemonList[0];
                }
                else
                {
                    currentElement = pokemonList[index];
                    pokemonList.RemoveAt(index);
                }

                sum += currentElement;

                for (int i = 0; i < pokemonList.Count; i++)
                {
                    if (pokemonList[i] > currentElement)
                    {
                        pokemonList[i] -= currentElement;
                    }
                    else if (pokemonList[i] <= currentElement)
                    {
                        pokemonList[i] += currentElement;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
