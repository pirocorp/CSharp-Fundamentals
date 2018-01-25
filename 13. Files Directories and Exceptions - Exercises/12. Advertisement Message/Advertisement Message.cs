using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Advertisement_Message
{
    class Program
    {
        static void Main()
        {
            var phrases = File.ReadAllLines("Phrases.txt");
            var events = File.ReadAllLines("Events.txt");
            var authors = File.ReadAllLines("Authors.txt");
            var cities = File.ReadAllLines("Cities.txt");

            var n = 100;
            var randomGenerator = new Random();

            for (int i = 0; i < n; i++)
            {
                var p = randomGenerator.Next(0, phrases.Length);
                var e = randomGenerator.Next(0, events.Length);
                var a = randomGenerator.Next(0, authors.Length);
                var c = randomGenerator.Next(0, cities.Length);
                File.AppendAllLines("Output.txt", new []{ $"{phrases[p]} {events[e]} {authors[a]} – {cities[c]}." });
            }
        }
    }
}
