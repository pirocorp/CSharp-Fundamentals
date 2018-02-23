using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _20.Critical_Breakpoint
{

    class Program
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var listOfLines = new List<Line>();

            while (inputLine != "Break it.")
            {
                var currentLine = Line.Parse(inputLine);
                listOfLines.Add(currentLine);
                inputLine = Console.ReadLine();
            }

            var actualCriticalRatio = listOfLines.First(x => x.CriticalRatio != 0).CriticalRatio;
            var isCriticalbreakpointExist =
                !listOfLines.Any(x => x.CriticalRatio != actualCriticalRatio && x.CriticalRatio != 0);

            if (isCriticalbreakpointExist)
            {
                var criticalBreakpoint = BigInteger.Pow(actualCriticalRatio, listOfLines.Count) % listOfLines.Count;
                listOfLines.ForEach(line => Console.WriteLine($"Line: [{line.PointOne.X}, {line.PointOne.Y}, {line.PointTwo.X}, {line.PointTwo.Y}]"));
                Console.WriteLine($"Critical Breakpoint: {criticalBreakpoint}");
            }
            else
            {
                Console.WriteLine("Critical breakpoint does not exist.");
            }
        }
    }
}