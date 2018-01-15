using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.Anonymous_Cache
{
    class Program
    {
        static void Main()
        {
            var input = string.Empty;

            var dataDict = new Dictionary<string, Dictionary<string, int>>();
            var cacheDict = new Dictionary<string, Dictionary<string, int>>();

            while (input != "thetinggoesskrra")
            {
                input = Console.ReadLine();
                if (input == "thetinggoesskrra") break;
                var tokens = input.Split(new[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 1)
                {
                    var currentDataSet = tokens[0];
                    dataDict[currentDataSet] = new Dictionary<string, int>();
                    foreach (var cashData in cacheDict)
                    {
                        if (dataDict.ContainsKey(cashData.Key))
                        {
                            dataDict[cashData.Key] = cashData.Value;
                            cacheDict.Remove(cashData.Key);
                            break;
                        }
                    }
                    continue;
                }

                var dataKey = tokens[0];
                var dataSize = int.Parse(tokens[1]);
                var dataSet = tokens[2];

                if (!dataDict.ContainsKey(dataSet))
                {
                    if (!cacheDict.ContainsKey(dataSet))
                    {
                        cacheDict[dataSet] = new Dictionary<string, int>();
                    }
                    cacheDict[dataSet].Add(dataKey, dataSize);
                    continue;
                }

                //testList[key[index]].Add(value[index]);
                dataDict[dataSet].Add(dataKey, dataSize);

                foreach (var cashData in cacheDict)
                {
                    if (dataDict.ContainsKey(cashData.Key))
                    {
                        dataDict[cashData.Key] = cashData.Value;
                        cacheDict.Remove(cashData.Key);
                        break;
                    }
                }
            }

            var maxSum = 0;
            var maxDataSet = string.Empty;
            var maxSet = string.Empty;

            foreach (var data in dataDict)
            {
                var currentSum = 0;
                var currentString = string.Empty;
                foreach (var kvp in data.Value)
                {
                    currentSum += kvp.Value;
                    currentString += $"$.{kvp.Key}" + " ";
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxDataSet = currentString;
                    maxSet = data.Key;
                }
            }

            var result = maxDataSet.Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            Console.WriteLine($"Data Set: {maxSet}, Total Size: {maxSum}");
            Console.WriteLine($"{String.Join(Environment.NewLine, result)}");
        }
    }
}
