namespace _15.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Files
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var files = new Dictionary<string, long>();

            for (var i = 0; i < n; i++)
            {
                var inputData = Console.ReadLine().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                var fileFullName = inputData[0].Trim();
                var size = long.Parse(inputData[1]);

                if (!files.ContainsKey(fileFullName))
                {
                    files[fileFullName] = size;
                }

                files[fileFullName] = size;
            }

            var command = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var extension = command[0];
            var extensionRegex = new Regex($@"\.{extension}$", RegexOptions.Compiled);
            var root = command[2];
            var rootRegex = new Regex($@"^{root}\\", RegexOptions.Compiled);
            const string filenamePattern = @"\\(?<filename>[^\\]+\.[^\\]+)(?!\\)$";
            var filenameRegex = new Regex(filenamePattern, RegexOptions.Compiled);
            var resultFiles = files
                .Where(x => rootRegex.IsMatch(x.Key))
                .Where(x => extensionRegex.IsMatch(x.Key))
                .Select(x =>
                {
                    var currentX = new KeyValuePair<string, long>(filenameRegex.Match(x.Key).Groups["filename"].Value, x.Value);
                    return currentX;
                })
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToArray();

            if (resultFiles.Length == 0)
            {
                Console.WriteLine("No");
                return;
            }

            foreach (var file in resultFiles)
            {
                Console.WriteLine($"{file.Key} - {file.Value} KB");
            }
        }
    }
}