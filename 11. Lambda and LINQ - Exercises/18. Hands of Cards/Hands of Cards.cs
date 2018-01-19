using System;
using System.Collections.Generic;
using System.Linq;

namespace _18.Hands_of_Cards
{
    class Program
    {
        static void Main()
        {
            var cards = new Dictionary<string, List<string>>();
            var inputData = Console.ReadLine();

            while (inputData != "JOKER")
            {
                var tokens = inputData.Split(':');
                var playerName = tokens[0];
                var listOfCards = tokens[1].Trim().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (!cards.ContainsKey(playerName))
                {
                    cards[playerName] = new List<string>();
                }

                cards[playerName].AddRange(listOfCards);
                cards[playerName] = cards[playerName].Distinct().ToList();
                inputData = Console.ReadLine();
            }

            cards.ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Value.Sum(y => GetCardPower(y))}"));
        }

        private static int GetCardPower(string card)
        {
            var powerOfCard = 0;

            if (card.Length == 2)
            {
                if (!int.TryParse(card[0].ToString(), out powerOfCard))
                {
                    switch (card[0])
                    {
                        case 'J':
                            powerOfCard = 11;
                            break;
                        case 'Q':
                            powerOfCard = 12;
                            break;
                        case 'K':
                            powerOfCard = 13;
                            break;
                        case 'A':
                            powerOfCard = 14;
                            break;
                    }
                }
            }
            else
            {
                powerOfCard = int.Parse(card.Substring(0, 2));
            }

            var typeOfCard = 0;

            switch (card[card.Length - 1])
            {
                case 'C':
                    typeOfCard = 1;
                    break;
                case 'D':
                    typeOfCard = 2;
                    break;
                case 'H':
                    typeOfCard = 3;
                    break;
                case 'S':
                    typeOfCard = 4;
                    break;
            }
            
            return powerOfCard * typeOfCard;
        }
    }
}
