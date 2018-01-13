using System;

namespace VaporStore
{
    class VaporStore
    {
        static void Main()
        {
            decimal balance = decimal.Parse(Console.ReadLine());

            //Game prices
            var OutFall4 = 39.99m;
            var CSOG = 15.99m;
            var ZplinterZell = 19.99m;
            var Honored2 = 59.99m;
            var RoverWatch = 29.99m;
            var RoverWatchOriginsEdition = 39.99m;

            string game;
            decimal totalSpend = 0.0m;

            do
            {
                if (balance <= 0.0m)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                game = Console.ReadLine();
                var price = 0.0m;

                switch (game)
                {
                    case "OutFall 4":
                        {
                            price = OutFall4;

                            if (price > balance)
                            {
                                Console.WriteLine("Too Expensive");
                                continue;
                            }
                            else
                            {
                                totalSpend += price;
                            }

                            Console.WriteLine("Bought OutFall 4");
                            break;
                        }
                    case "CS: OG":
                        {
                            price = CSOG;

                            if (price > balance)
                            {
                                Console.WriteLine("Too Expensive");
                                continue;
                            }
                            else
                            {
                                totalSpend += price;
                            }

                            Console.WriteLine("Bought CS: OG");
                            break;
                        }
                    case "Zplinter Zell":
                        {
                            price = ZplinterZell;

                            if (price > balance)
                            {
                                Console.WriteLine("Too Expensive");
                                continue;
                            }
                            else
                            {
                                totalSpend += price;
                            }

                            Console.WriteLine("Bought Zplinter Zell");
                            break;
                        }
                    case "Honored 2":
                        {
                            price = Honored2;

                            if (price > balance)
                            {
                                Console.WriteLine("Too Expensive");
                                continue;
                            }
                            else
                            {
                                totalSpend += price;
                            }

                            Console.WriteLine("Bought Honored 2");
                            break;
                        }
                    case "RoverWatch":
                        {
                            price = RoverWatch;

                            if (price > balance)
                            {
                                Console.WriteLine("Too Expensive");
                                continue;
                            }
                            else
                            {
                                totalSpend += price;
                            }

                            Console.WriteLine("Bought RoverWatch");
                            break;
                        }
                    case "RoverWatch Origins Edition":
                        {
                            price = RoverWatchOriginsEdition;

                            if (price > balance)
                            {
                                Console.WriteLine("Too Expensive");
                                continue;
                            }
                            else
                            {
                                totalSpend += price;
                            }

                            Console.WriteLine("Bought RoverWatch Origins Edition");
                            break;
                        }
                    default:
                        {
                            if (game != "Game Time")
                            {
                                Console.WriteLine("Not Found");
                            }
                            break;
                        }
                }

                balance -= price;
            }
            while (game != "Game Time");

            Console.WriteLine($"Total spent: ${totalSpend:f2}. Remaining: ${balance:f2}");
        }
    }
}
