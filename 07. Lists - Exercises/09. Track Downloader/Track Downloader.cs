using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Track_Downloader
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var blackList = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            string filename = Console.ReadLine();
            var filenameList = new List<string>();

            while (filename != "end")
            {
                if (NotContain(blackList, filename))
                {
                    filenameList.Add(filename);
                }

                filename = Console.ReadLine();
            }

            filenameList.Sort();
            Console.WriteLine(String.Join(Environment.NewLine, filenameList));
        }

        private static bool NotContain(string[] blackList, string filename)
        {
            for (int i = 0; i < blackList.Length; i++)
            {
                string currentWord = blackList[i];
                if (filename.Contains(currentWord))
                    {
                        return false;
                    }
                
            }

            return true;
        }
    }
}
