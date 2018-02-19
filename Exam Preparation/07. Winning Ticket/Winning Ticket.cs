namespace _07.Winning_Ticket
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            const string winPattern = @".*?(?<win>[\@]{6,10}|[\#]{6,10}|[\^]{6,10}|[\$]{6,10}).*?";

            var tickets = Console.ReadLine().Split(", \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            var winRegex = new Regex(winPattern);

            for (var i = 0; i < tickets.Length; i++)
            {
                var currentTicket = tickets[i];

                if (currentTicket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var leftPart = currentTicket.Substring(0, 10);
                var rightPart = currentTicket.Substring(10, 10);
                var leftMatch = winRegex.Match(leftPart).Groups["win"].Value;
                var rightMatch = winRegex.Match(rightPart).Groups["win"].Value;

                if (string.IsNullOrEmpty(leftMatch) || string.IsNullOrEmpty(rightMatch) || leftMatch[0] != rightMatch[0])
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                    continue;
                }

                var commonLenght = Math.Min(leftMatch.Length, rightMatch.Length);

                if (commonLenght == 10)
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - {commonLenght}{leftMatch[0]} Jackpot!");
                }
                else if (commonLenght >= 6)
                {
                    Console.WriteLine($"ticket \"{currentTicket}\" - {commonLenght}{rightMatch[0]}");
                }
            }
        }
    }
}