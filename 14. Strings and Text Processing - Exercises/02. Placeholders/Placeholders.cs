namespace _02.Placeholders
{
    using System;

    class Placeholders
    {
        static void Main()
        {
            var readLine = Console.ReadLine();

            while (readLine != "end")
            {
                var inputData = readLine.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var inputString = inputData[0];
                var dataForPlaceholders = inputData[1].Split(new []{ ", " }, StringSplitOptions.RemoveEmptyEntries);

                for (var i = 0; i < dataForPlaceholders.Length; i++)
                {
                    inputString = inputString.Replace("{" + $"{i}" + "}", dataForPlaceholders[i]);
                }

                Console.WriteLine(inputString);
                readLine = Console.ReadLine();
            }
        }
    }
}
