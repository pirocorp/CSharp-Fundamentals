using System;

namespace NeighbourWars
{
    class NeighbourWars
    {
        static void Main()
        {
            var peshoDamage = int.Parse(Console.ReadLine());
            var goshoDamage = int.Parse(Console.ReadLine());

            var round = 0;
            var peshoHealth = 100;
            var goshoHealth = 100;
            bool peshoWin;

            while (true)
            {
                if (round %2 == 0)
                {
                    goshoHealth -= peshoDamage;
                    round++;
                    if (goshoHealth <= 0)
                    {
                        peshoWin = true;
                        break;
                    }
                    Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {goshoHealth} health.");
                    
                }
                else
                {
                    peshoHealth -= goshoDamage;
                    round++;
                    if (peshoHealth <= 0)
                    {
                        peshoWin = false;
                        break;
                    }
                    Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {peshoHealth} health.");

                }

                if (round % 3 == 0 && round > 0)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }
            }

            if (peshoWin)
            {
                Console.WriteLine($"Pesho won in {round}th round.");
            }
            else
            {
                Console.WriteLine($"Gosho won in {round}th round.");
            }
        }
    }
}
