using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Short_Words_Sorted
{
    class Program
    {
        static void Main()
        {
            char[] separators = new char[]
                {'.',',',':',';','(',')','[',']','\\','\"','\'','/','!','?',' '};
            string sentence = Console.ReadLine().ToLower();
            string[] words = sentence.Split(separators);
            var result = words
                .Where(w => w != "")
                .Where(w => w.Length < 5)
                .OrderBy(w => w).Distinct();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
