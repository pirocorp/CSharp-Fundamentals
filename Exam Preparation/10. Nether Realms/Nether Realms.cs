namespace _10.Nether_Realms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            const string splitPattern = @"(\s*\,+\s*)";
            var splitRegex = new Regex(splitPattern);
            var demons = splitRegex.Split(Console.ReadLine()).Where(s => s.Length > 0).Where(x => !splitRegex.IsMatch(x)).ToArray();
            const string healthPattern = @"(?<healthCharacters>[^0-9+\-*\/.])";
            var healthRegex = new Regex(healthPattern);
            var demonsHealth = demons.Select(x => healthRegex.Matches(x).Cast<Match>().Sum(y => y.Value[0])).ToArray();
            const string digitsPattern = @"[+\-]?\d+(\.\d+)*";
            var digitsRegex = new Regex(digitsPattern);
            var demonsBaseDamage = demons.Select(x =>
                digitsRegex.Matches(x).Cast<Match>().Select(y => y.Value).Select(double.Parse).Sum(s => s)).ToArray();
            const string modifingDamagePattern = @"[*\/]";
            var modifingDamageRegex = new Regex(modifingDamagePattern);
            var demonsDamageModifier = demons.Select(x =>
                string.Join("", modifingDamageRegex.Matches(x).Cast<Match>().Select(m => m.Value).ToArray())).ToArray();
            var demonsDamage = DemonsDamage(demonsBaseDamage, demonsDamageModifier);

            var demonsResult = new List<Demon>();

            for (var i = 0; i < demons.Length; i++)
            {
                var currentDemonName = demons[i];
                var currentDemonHealth = demonsHealth[i];
                var currentDemonDamage = demonsDamage[i];
                var currentDemon = new Demon(currentDemonName, currentDemonHealth, currentDemonDamage);
                demonsResult.Add(currentDemon);
            }

            demonsResult = demonsResult.OrderBy(x => x.DemonName).ToList();

            foreach (var demon in demonsResult)
            {
                var name = demon.DemonName;
                var health = demon.DemonHealth;
                var damage = demon.DemonDamage;
                Console.WriteLine($"{name} - {health} health, {damage:F2} damage");
            }
        }

        private static double[] DemonsDamage(double[] demonsBaseDamage, string[] demonsDamageModifier)
        {
            var demonsDamage = new double[demonsBaseDamage.Length];

            for (var i = 0; i < demonsDamage.Length; i++)
            {
                var currentBaseDamage = demonsBaseDamage[i];
                var currentDamageModifier = demonsDamageModifier[i];
                var currentDamage = currentBaseDamage;

                if (string.IsNullOrEmpty(currentDamageModifier))
                {
                    demonsDamage[i] = currentDamage;
                    continue;
                }

                for (var j = 0; j < currentDamageModifier.Length; j++)
                {
                    var currentChar = currentDamageModifier[j];
                    if (currentChar == '*')
                    {
                        currentDamage *= 2;
                    }
                    else if (currentChar == '/')
                    {
                        currentDamage /= 2;
                    }
                }

                demonsDamage[i] = currentDamage;
            }

            return demonsDamage;
        }
    }
}