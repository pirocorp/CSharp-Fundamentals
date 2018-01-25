using System;
using System.IO;
using System.Text;

namespace _07.Index_of_Letters
{
    class Program
    {
        static void Main()
        {
            var inputLines = File.ReadAllLines("Input.txt");
            var resultedString = new StringBuilder();

            for (int i = 0; i < inputLines .Length; i++)
            {
                var chars = inputLines[i].ToCharArray();

                for (var j = 0; j < chars.Length; j++)
                {
                    var result = chars[j] - 'a';
                    resultedString.AppendLine($"{chars[j]} -> {result}");
                }

                resultedString.AppendLine(Environment.NewLine);
            }

            File.WriteAllText("Output.txt", resultedString.ToString());
        }
    }
}
