namespace _23.Hornet_Assault
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var beehives = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            var hornets = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            var hornetSummedUpPower = hornets.Sum();

            while (beehives.Count > 0 && beehives[0] < hornetSummedUpPower)
            {
                beehives.RemoveAt(0);
            }

            for (var i = 0; i < beehives.Count; i++)
            {
                var currentBeeHive = beehives[i];
                var currentHornetSummedUpPower = hornets.Sum();

                if (currentBeeHive >= currentHornetSummedUpPower)
                {
                    if (hornets.Count != 0)
                    {
                        hornets.RemoveAt(0);
                    }
                }

                beehives[i] = beehives[i] - currentHornetSummedUpPower;

                if (beehives[i] <= 0)
                {
                    beehives.RemoveAt(i);
                    i--;
                }
            }

            if (beehives.Count > 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
