using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _11.Roli_The_Coder
{
    class Program
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var events = new List<Event>();

            while (inputLine != "Time for Code")
            {
                var match = Regex.Match(inputLine,
                    @"^(?<id>\d+)\s+#(?<eventName>[^@]+)(?<participant>@[A-Za-z0-9'\-]+\s*)*$");

                if (!match.Success)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                var id = int.Parse(match.Groups["id"].Value);
                var eventName = match.Groups["eventName"].Value.Trim();
                var participants = match.Groups["participant"]
                    .Captures.Cast<Capture>()
                    .ToArray().Select(x => x.Value)
                    .Select(x => x.Trim())
                    .Distinct()
                    .ToArray();

                if (events.All(x => x.Id != id))
                {
                    var currentEvent = new Event(id, eventName, participants.ToList());
                    events.Add(currentEvent);
                    inputLine = Console.ReadLine();
                    continue;
                }

                if (events.First(x => x.Id == id).EventName == eventName)
                {
                    var currentEvent = events.First(x => x.Id == id);
                    currentEvent.ListOfParticipants.AddRange(participants);
                    currentEvent.ListOfParticipants = currentEvent.ListOfParticipants.Distinct().ToList();
                    inputLine = Console.ReadLine();
                    continue;
                }

                inputLine = Console.ReadLine();
            }

            events = events
                .OrderByDescending(x => x.ListOfParticipants.Count)
                .ThenBy(a => a.EventName)
                .Select(x =>
                {
                    x.ListOfParticipants = x.ListOfParticipants.OrderBy(s => s).ToList();
                    return x;
                })
                .ToList();

            foreach (var @event in events)
            {
                var eventName = @event.EventName;
                var eventParticipantsNumber = @event.ListOfParticipants.Count;
                var participants = @event.ListOfParticipants;
                Console.WriteLine($"{eventName} - {eventParticipantsNumber}");

                foreach (var participant in participants)
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}