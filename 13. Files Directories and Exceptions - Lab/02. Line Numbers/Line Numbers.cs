using System.IO;
using System.Linq;

namespace _2.Line_Numbers
{
    class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("input.txt");
            var numberedLines = lines.Select((line, index) => $"{index + 1}. {line}");
            File.WriteAllLines("output.txt", numberedLines);
        }
    }
}
