namespace _06.Fish_Statistics
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var pattern = @"(?<tail>>*)<(?<body>\(+)(?<status>['\-x])>";
            var inputData = Console.ReadLine();
            var fishIsFound = Regex.IsMatch(inputData, pattern);

            if (fishIsFound)
            {
                var fishes = Regex.Matches(inputData, pattern).Cast<Match>().ToList();
                var currentFishNumber = 0;

                foreach (var fish in fishes)
                {
                    currentFishNumber++;
                    ProcessFish(fish, currentFishNumber);
                }
            }
            else
            {
                Console.WriteLine($"No fish found.");
            }
        }

        private static void ProcessFish(Match fish, int currentFishNumber)
        {
            var fishTail = fish.Groups["tail"].Value;
            var fishBody = fish.Groups["body"].Value;
            var fishStatus = fish.Groups["status"].Value;

            var tailType = string.Empty;

            if (fishTail.Length > 5)
            {
                tailType = "Long";
            }
            else if (fishTail.Length > 1)
            {
                tailType = "Medium";
            }
            else if (fishTail.Length == 1)
            {
                tailType = "Short";
            }
            else
            {
                tailType = "None";
            }

            var bodyType = string.Empty;

            if (fishBody.Length > 10)
            {
                bodyType = "Long";
            }
            else if (fishBody.Length > 5)
            {
                bodyType = "Medium";
            }
            else
            {
                bodyType = "Short";
            }

            var status = string.Empty;

            if (fishStatus == "'")
            {
                status = "Awake";
            }
            else if (fishStatus == "-")
            {
                status = "Asleep";
            }
            else if (fishStatus == "x")
            {
                status = "Dead";
            }

            Console.WriteLine($"Fish {currentFishNumber}: {fish.Value}");
            if (fishTail.Length * 2 == 0)
            {
                Console.WriteLine($"Tail type: {tailType}");
            }
            else
            {
                Console.WriteLine($"Tail type: {tailType} ({fishTail.Length * 2} cm)");
            }
            Console.WriteLine($"Body type: {bodyType} ({fishBody.Length * 2} cm)");
            Console.WriteLine($"Status: {status}");
        }
    }
}
