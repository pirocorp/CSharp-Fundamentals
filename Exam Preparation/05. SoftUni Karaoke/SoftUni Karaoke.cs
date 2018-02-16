namespace _05.SoftUni_Karaoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            const string splitPattern = @"\,\s+";
            var participants = Regex.Split(Console.ReadLine(), splitPattern).ToList();
            var songs = Regex.Split(Console.ReadLine(), splitPattern).ToList();
            var inputLine = Console.ReadLine();
            var awards = new Dictionary<string, List<string>>(); //Participant, awards

            while (inputLine != "dawn")
            {
                var tokens = Regex.Split(inputLine, splitPattern);
                var participant = tokens[0];
                var song = tokens[1];
                var award = tokens[2];

                if (participants.Contains(participant) && songs.Contains(song))
                {
                    if (!awards.ContainsKey(participant))
                    {
                        awards[participant] = new List<string>();
                    }

                    awards[participant].Add(award);
                }

                inputLine = Console.ReadLine();
            }

            awards = awards
                .OrderByDescending(x => x.Value.Distinct().ToList().Count)
                .ThenBy(m => m.Key)
                .ToDictionary(x => x.Key, x => x.Value.OrderBy(z => z).Distinct().ToList());

            foreach (var participant in awards)
            {
                var participantName = participant.Key;
                var participantAwards = participant.Value;
                var numberOfAwards = participantAwards.Count;
                Console.WriteLine($"{participantName}: {numberOfAwards} awards");

                foreach (var award in participantAwards)
                {
                    Console.WriteLine($"--{award}");
                }
            }

            if (awards.Count == 0)
            {
                Console.WriteLine("No awards");
            }
        }
    }
}