using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _22.Hornet_Comm
{
    class Program
    {
        static void Main()
        {
            const string privateMessagePattern = @"^(?<recipientCode>\d+)(?: <-> )(?<message>[A-Za-z0-9]+)$";
            var privateMessageRegex = new Regex(privateMessagePattern, RegexOptions.Compiled);
            const string broadcastPattern = @"^(?<message>[^0-9]+)(?: <-> )(?<frequency>[A-Za-z0-9]+)$";
            var broadcastRegex = new Regex(broadcastPattern, RegexOptions.Compiled);
            var inputLine = Console.ReadLine();
            var privateMessages = new List<KeyValuePair<string, string>>(); // recipient message
            var broadcasts = new List<KeyValuePair<string, string>>(); // frequency message

            while (inputLine != "Hornet is Green")
            {
                var privateMessage = privateMessageRegex.Match(inputLine);
                var broadcast = broadcastRegex.Match(inputLine);

                if (privateMessage.Success)
                {
                    var recipientCode = new string(privateMessage.Groups["recipientCode"].Value.Reverse().ToArray());
                    var message = privateMessage.Groups["message"].Value;
                    var currentPrivateMessage = new KeyValuePair<string, string>(recipientCode, message);
                    privateMessages.Add(currentPrivateMessage);
                    inputLine = Console.ReadLine();
                    continue;
                }

                if (broadcast.Success)
                {
                    var message = broadcast.Groups["message"].Value;
                    var frequencyChars = broadcast.Groups["frequency"].Value.Select(x =>
                    {
                        if (char.IsUpper(x))
                        {
                            var newX = char.ToLower(x);
                            return newX;
                        }

                        if (char.IsLower(x))
                        {
                            var newX = char.ToUpper(x);
                            return newX;
                        }

                        return x;
                    }).ToArray();

                    var frequency = new string(frequencyChars);
                    var currentBroadCast = new KeyValuePair<string, string>(frequency, message);
                    broadcasts.Add(currentBroadCast);
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"Broadcasts:");

            if (broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }

            foreach (var broadcast in broadcasts)
            {
                var frequency = broadcast.Key;
                var message = broadcast.Value;
                Console.WriteLine($"{frequency} -> {message}");
            }

            Console.WriteLine($"Messages:");

            if (privateMessages.Count == 0)
            {
                Console.WriteLine("None");
            }

            foreach (var message in privateMessages)
            {
                var recipient = message.Key;
                var privateMessage = message.Value;
                Console.WriteLine($"{recipient} -> {privateMessage}");
            }
        }
    }
}
