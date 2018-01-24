using System.IO;
using System.Text;

namespace _02.HTML_Contents
{
    class Program
    {
        static void Main()
        {
            var inputLines = File.ReadAllLines("Input.txt");
            var body = new StringBuilder();
            var title = string.Empty;

            for (int i = 0; i < inputLines.Length; i++)
            {
                if (inputLines[i] == "exit")
                {
                    break;
                }

                var currentElements = inputLines[i].Split(' ');

                if (currentElements[0] == "title")
                {
                    title = currentElements[1];
                    continue;
                }

                body.AppendLine($"\t<{currentElements[0]}>{currentElements[1]}</{currentElements[0]}>");
            }

            var result = new StringBuilder();

            result.AppendLine($"<!DOCTYPE html>");
            result.AppendLine($"<html>");
            result.AppendLine($"<head>");
            result.AppendLine($"<title>{title}</title>");
            result.AppendLine($"</head>");
            result.AppendLine($"<body>");
            result.AppendLine(body.ToString().TrimEnd());
            result.AppendLine($"</body>");
            result.AppendLine($"</html>");

            File.WriteAllText("index.html", result.ToString());
        }
    }
}

