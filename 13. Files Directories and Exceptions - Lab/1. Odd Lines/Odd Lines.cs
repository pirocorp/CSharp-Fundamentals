using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Odd_Lines
{
    class Program
    {
        static void Main()
        {
            var lines = File.ReadAllLines("input.txt");
            var oddLines = lines.Where((line, index) => index % 2 == 1);
            File.WriteAllLines("Output.txt", oddLines);
        }
    }
}
