using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.String_Decryption
{
    class Program
    {
        static void Main()
        {
            var inputMN = Console.ReadLine().Split(' ');
            var skip = int.Parse(inputMN[0]);
            var take = int.Parse(inputMN[1]);
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList().Where(x => x > 64 && x < 91).Skip(skip).Take(take);
            Console.WriteLine(string.Join("", numbers.Select(x => (char)x)));
        }
    }
}
