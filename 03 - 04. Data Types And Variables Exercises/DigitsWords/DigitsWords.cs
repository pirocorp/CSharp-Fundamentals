﻿using System;

namespace DigitsWords
{
    class DigitsWords
    {
        static void Main()
        {
            string line = Console.ReadLine().ToLower().Trim();
            switch (line)
            {
                case "zero": Console.WriteLine(0); break;
                case "one": Console.WriteLine(1); break;
                case "two": Console.WriteLine(2); break;
                case "three": Console.WriteLine(3); break;
                case "four": Console.WriteLine(4); break;
                case "five": Console.WriteLine(5); break;
                case "six": Console.WriteLine(6); break;
                case "seven": Console.WriteLine(7); break;
                case "eight": Console.WriteLine(8); break;
                case "nine": Console.WriteLine(9); break;
                case "ten": Console.WriteLine(10); break;
                default: Console.WriteLine("too big"); break;
            }
        }
    }
}
