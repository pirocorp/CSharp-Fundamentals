namespace _01._The_Imitation_Game
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var encryptedMessage = Console.ReadLine() ?? string.Empty;

            string input;

            while ((input = Console.ReadLine()) != "Decode")
            {
                var tokens = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];

                switch (command)
                {
                    case "Move":
                        encryptedMessage = Move(tokens, encryptedMessage);
                        break;
                    case "Insert":
                        encryptedMessage = Insert(tokens, encryptedMessage);
                        break;
                    case "ChangeAll":
                        encryptedMessage = ChangeAll(tokens, encryptedMessage);
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }

        private static string ChangeAll(string[] tokens, string encryptedMessage)
        {
            var target = tokens[1];
            var value = tokens[2];

            encryptedMessage = encryptedMessage.Replace(target, value);
            return encryptedMessage;
        }

        private static string Insert(string[] tokens, string encryptedMessage)
        {
            var index = int.Parse(tokens[1]);
            var value = tokens[2];

            var newMessage = encryptedMessage
                .ToCharArray()
                .ToList();

            newMessage.InsertRange(index, value.ToCharArray());

            return new string(newMessage.ToArray());
        }

        private static string Move(string[] tokens, string encryptedMessage)
        {
            var n = int.Parse(tokens[1]);
            n %= encryptedMessage.Length;

            var newEnd = encryptedMessage.Take(n);
            var newMessage = encryptedMessage
                .Skip(n)
                .Take(encryptedMessage.Length - n)
                .Concat(newEnd);

            return new string(newMessage.ToArray());
        }
    }
}
