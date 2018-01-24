using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04.Merge_Files
{
    class Program
    {
        static void Main()
        {
            var linesFileOne = File.ReadAllLines("FileOne.txt");
            var linesFileTwo = File.ReadAllLines("FileTwo.txt");
            var count = Math.Min(linesFileOne.Length, linesFileTwo.Length);
            var resultetLines = new List<string>();

            for (var i = 0; i < count; i++)
            {
                resultetLines.Add(linesFileOne[i]);
                resultetLines.Add(linesFileTwo[i]);
            }

            if (linesFileOne.Length > linesFileTwo.Length)
            {
                for (int i = count; i < linesFileOne.Length; i++)
                {
                    resultetLines.Add(linesFileOne[i]);
                }
            }

            if (linesFileTwo.Length > linesFileOne.Length)
            {
                for (int i = count; i < linesFileTwo.Length; i++)
                {
                    resultetLines.Add(linesFileTwo[i]);
                }
            }

            File.WriteAllLines("Output.txt", resultetLines);
        }
    }
}
