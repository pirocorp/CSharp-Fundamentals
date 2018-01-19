using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Lambada_Expressions
{
    class Program
    {
        static void Main()
        {
            var lamdaDict = new Dictionary<string, string>();
            var inputData = Console.ReadLine();

            while (inputData != "lambada")
            {
                var tokens = inputData.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length > 1)
                {
                    var key = tokens[0];
                    var value = tokens[1];

                    if (!lamdaDict.ContainsKey(key))
                    {
                        lamdaDict[key] = value;
                    }

                    lamdaDict[key] = value;
                }
                else
                {
                    lamdaDict = lamdaDict.ToDictionary(x => x.Key, x => x.Key + "." + x.Value);
                }

                inputData = Console.ReadLine();
            }

            lamdaDict.ToList().ForEach(x => Console.WriteLine($"{x.Key} => {x.Value}"));
        }
    }
}
