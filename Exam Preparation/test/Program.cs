using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Event> events = new List<Event>();

            while (true)
            {
                input = Console.ReadLine();
                if (input == "Time for Code")
                    break;

                string[] inputArr = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                string name = string.Empty;
                if (inputArr[1].First() == '#')
                    name = inputArr[1].Remove(0, 1);
                else
                    continue;

                HashSet<string> participants = new HashSet<string>();
                for (int index = 2; index < inputArr.Length; index++)
                {
                    if (inputArr[index].First() == '@')
                        participants.Add(inputArr[index]);
                    else
                        continue;
                }

                int id = int.Parse(inputArr[0]);

                Event tempEvent = new Event(id, name, participants);

                if (events.Contains(tempEvent))
                {
                    int index = events.IndexOf(tempEvent);
                    if (events[index].Name == name)
                    {
                        events[index].Participants.AddRange(participants);
                        events[index].Participants = events[index].Participants.Distinct().ToList();
                    }
                }
                else
                    events.Add(tempEvent);
            }

            foreach (Event ev in events.OrderByDescending(ev => ev.Participants.Count).ThenBy(ev => ev.Name))
            {
                Console.WriteLine($"{ev.Name} - {ev.Participants.Count}");
                foreach (string participant in ev.Participants.OrderBy(name => name))
                {
                    Console.WriteLine(participant);
                }
            }

            Console.ReadLine();
        }
    }

    class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<string> Participants { get; set; }

        public Event(int id, string name, HashSet<string> participants)
        {
            this.ID = id;
            this.Name = name;
            this.Participants = participants.ToList();
        }

        public override bool Equals(object obj)
        {
            if (obj is Event)
            {
                Event newEvent = (Event)obj;

                return this.ID == newEvent.ID;
            }

            return false;
        }
    }
}