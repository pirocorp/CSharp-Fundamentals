using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Bomb_Numbers
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var numbersSequence = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var bombSequence = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int bomb = bombSequence[0];
            int bombPower = bombSequence[1];

            int bombIndex = numbersSequence.IndexOf(bomb);

            while (bombIndex >= 0)
            {
                int bombStartIndex = bombIndex - bombPower;
                if (bombStartIndex < 0)
                {
                    bombStartIndex = 0;
                }

                int bombEndIndex = bombIndex + bombPower;
                if (bombEndIndex >= numbersSequence.Count)
                {
                    bombEndIndex = numbersSequence.Count - 1;
                }

                int boom = bombEndIndex - bombStartIndex + 1;
                while (boom > 0)
                {
                    numbersSequence.RemoveAt(bombStartIndex);
                    boom--;
                }

                bombIndex = numbersSequence.IndexOf(bomb);
            }

            Console.WriteLine(numbersSequence.Sum());
        }
    }
}
