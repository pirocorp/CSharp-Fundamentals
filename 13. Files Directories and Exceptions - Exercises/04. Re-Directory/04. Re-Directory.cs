using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Re_Directory
{
    class Program
    {
        static void Main()
        {
            var inputDir = new DirectoryInfo("../../input");
            var files = inputDir.GetFiles().Select(x => x.Extension).Distinct().ToArray();
            Directory.CreateDirectory("../../output");

            for (var i = 0; i < files.Length; i++)
            {
                var currentExtension = files[i];
                Directory.CreateDirectory($"../../output/{currentExtension.Remove(0, 1)}s");
                var filesToMove = inputDir
                    .GetFiles()
                    .Where(x => x.Extension == currentExtension)
                    .ToList();

                foreach (var file in filesToMove)
                {
                    File.Copy(file.FullName, $"../../output/{currentExtension.Remove(0, 1)}s/{file.Name}");
                }
            }

        }
    }
}
