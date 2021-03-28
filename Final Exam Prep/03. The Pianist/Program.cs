namespace _03._The_Pianist
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var collection = InitializeCollection(n);

            string input;

            while ((input = Console.ReadLine()) != "Stop")
            {
                var tokens = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var piece = tokens[1];

                switch (command)
                {
                    case "Add":
                        AddPiece(collection, piece, tokens);
                        break;
                    case "Remove":
                        Remove(collection, piece);
                        break;
                    case "ChangeKey":
                        ChangeKey(collection, piece, tokens);
                        break;
                }
            }

            collection
                .Select(x => x.Value)
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Composer)
                .ToList()
                .ForEach(Console.WriteLine);

        }

        private static void ChangeKey(IDictionary<string, Piece> collection, string piece, string[] tokens)
        {
            if (!collection.ContainsKey(piece))
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                return;
            }

            var newKey = tokens[2];
            collection[piece].Key = newKey;
            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
        }

        private static void Remove(IDictionary<string, Piece> collection, string piece)
        {
            if (!collection.ContainsKey(piece))
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                return;
            }

            collection.Remove(piece);
            Console.WriteLine($"Successfully removed {piece}!");
        }

        private static void AddPiece(IDictionary<string, Piece> collection, string piece, string[] tokens)
        {
            if (collection.ContainsKey(piece))
            {
                Console.WriteLine($"{piece} is already in the collection!");
                return;
            }

            var composer = tokens[2];
            var key = tokens[3];

            var newPiece = new Piece()
            {
                Name = piece,
                Composer = composer,
                Key = key
            };

            collection.Add(piece, newPiece);
            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
        }

        private static IDictionary<string, Piece> InitializeCollection(int n)
        {
            var collection = new Dictionary<string, Piece>();

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                var piece = new Piece()
                {
                    Name = tokens[0],
                    Composer = tokens[1],
                    Key = tokens[2]
                };

                collection.Add(piece.Name, piece);
            }

            return collection;
        }

        private class Piece
        {
            public string Name { get; set; }

            public string Composer { get; set; }

            public string Key { get; set; }

            public override string ToString()
            {
                return $"{this.Name} -> Composer: {this.Composer}, Key: {this.Key}";
            }
        }
    }
}
