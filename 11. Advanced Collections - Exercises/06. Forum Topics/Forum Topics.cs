using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Forum_Topics
{
    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine();
            var topicDict = new Dictionary<string, HashSet<string>>();

            while (inputData != "filter")
            {
                var tokens = inputData.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var key = tokens[0];
                var listOfTags = tokens[1].Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);

                if (!topicDict.ContainsKey(key))
                {
                    topicDict[key] = new HashSet<string>();
                }

                topicDict[key].UnionWith(listOfTags);
                inputData = Console.ReadLine();
            }

            inputData = Console.ReadLine();
            var listOfSearchedTags = inputData.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var topic in topicDict)
            {
                var topicName = topic.Key;
                var topicTagsList = topic.Value;
                bool contained = true;

                for (int i = 0; i < listOfSearchedTags.Length; i++)
                {
                    if (!topicTagsList.Contains(listOfSearchedTags[i]))
                    {
                        contained = false;
                        break;
                    }
                }

                if (contained)
                {
                    Console.WriteLine($"{topicName} | #{String.Join(", #", topicTagsList)}");
                }
            }
        }
    }
}

