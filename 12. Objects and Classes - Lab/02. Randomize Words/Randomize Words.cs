using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Randomize_Words
{
    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(' ');
            var rnd = new Random();

            for (int pos1 = 0; pos1 < words.Length; pos1++)
            {
                int pos2 = rnd.Next(words.Length);
                var swap = words[pos1];
                words[pos1] = words[pos2];
                words[pos2] = swap;
            }
            Console.WriteLine(string.Join("\r\n", words));

        }
    }
}
