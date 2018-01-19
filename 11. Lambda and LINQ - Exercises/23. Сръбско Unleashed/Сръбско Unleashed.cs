using System;
using System.Collections.Generic;
using System.Linq;

namespace _23.Сръбско_Unleashed
{
    class Program
    {
        static void Main()
        {
            var concerts = new Dictionary<string, Dictionary<string, long>>();
            var inputData = Console.ReadLine();

            while (inputData != "End")
            {
                var tokens = inputData.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length >= 4 && tokens.Length <= 8)
                {
                    var name = new List<string>();
                    var i = 0;
                    bool notAllChar = false;

                    while (!tokens[i].Contains('@') && name.Count < 3)
                    {
                        var part = tokens[i];

                        if (!part.All(Char.IsLetter))
                        {
                            notAllChar = true;
                            break;
                        }
                        name.Add(part);
                        i++;
                    }

                    if(notAllChar) { inputData = Console.ReadLine(); continue; };

                    if (name.Count > 3) { inputData = Console.ReadLine(); continue; };

                    var venue = new List<string>();
                    var test = 0L;
                    tokens[i] = tokens[i].Remove(0, 1);
                    
                    while (!long.TryParse(tokens[i], out test) && venue.Count < 3)
                    {
                        var part = tokens[i];
                        venue.Add(part);
                        i++;
                    }

                    if(venue.Count > 3) { inputData = Console.ReadLine(); continue; };

                    if(i < tokens.Length && !long.TryParse(tokens[i], out test)) { inputData = Console.ReadLine(); continue; };

                    var ticketsPrice = test;
                    i++;

                    if (i < tokens.Length && !long.TryParse(tokens[i], out test)) { inputData = Console.ReadLine(); continue; };

                    var ticketsCount = test;

                    var nameString = String.Join(" ", venue);

                    if (!concerts.ContainsKey(nameString))
                    {
                        concerts[nameString] = new Dictionary<string, long>();
                    }

                    var venueString = String.Join(" ", name);

                    if (!concerts[nameString].ContainsKey(venueString))
                    {
                        concerts[nameString][venueString] = 0;
                    }

                    concerts[nameString][venueString] += ticketsPrice * ticketsCount;
                }

                inputData = Console.ReadLine();

            }

            concerts.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Key}");
                x.Value.OrderByDescending(v => v.Value).ToList().ForEach(r => Console.WriteLine($"#  {r.Key} -> {r.Value}"));
            });

        }
    }
}
