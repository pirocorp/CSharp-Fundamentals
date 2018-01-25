using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20.Write_to_File
{
    class Program
    {
        static void Main()
        {
            var inputLines = File.ReadAllLines("sample_text.txt").ToList();
            var listOfChars = ".,!?:".ToCharArray();
            inputLines = inputLines
                .Select(x => String.Join("", x.Split(listOfChars, StringSplitOptions.RemoveEmptyEntries)))
                .ToList();
            File.WriteAllLines("../../output.txt", inputLines);
        }
    }
}
