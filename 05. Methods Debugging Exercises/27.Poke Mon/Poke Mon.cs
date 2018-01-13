using System;

namespace _27.Poke_Mon
{
    class PokeMon
    {
        static void Main(string[] args)
        {
            long pokePower = long.Parse(Console.ReadLine());
            long powerNeedForPoke = long.Parse(Console.ReadLine());
            long exhaustionFactor = long.Parse(Console.ReadLine());

            long pokeCounter = 0;
            long pokeing = pokePower;
            while (pokeing >= powerNeedForPoke)
            {
                pokeing -= powerNeedForPoke;
                pokeCounter++;
                if (pokeing == pokePower * 0.5 && exhaustionFactor > 0)
                {
                    pokeing /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokeing);
            Console.WriteLine(pokeCounter);
        }
    }
}
