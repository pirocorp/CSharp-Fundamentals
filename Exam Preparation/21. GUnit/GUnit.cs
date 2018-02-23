using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _21.GUnit
{
    class GUnit
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Trim();
            var database = new List<Class>();
            
            while (inputLine != @"It's testing time!")
            {
                ParseLine(database, inputLine);
                inputLine = Console.ReadLine().Trim();
            }

            database = database
                .OrderByDescending(x => x.Methods.Sum(y => y.Tests.Distinct().Count()))
                .ThenBy(x => x.Methods.Count)
                .ThenBy(x => x.ClassName)
                .Select(x =>
                {
                    var className = x.ClassName;
                    var methods = x.Methods
                        .OrderByDescending(c => c.Tests.Count)
                        .ThenBy(n => n.MethodName)
                        .Select(y =>
                        {
                            var methodName = y.MethodName;
                            var tests = y.Tests.OrderBy(l => l.Length).ThenBy(s => s).ToList();
                            return new Method(methodName, tests);
                        })
                        .ToList();
                    return new Class(className, methods);
                })
                .ToList();

            foreach (var @class in database)
            {
                var className = @class.ClassName;
                var methods = @class.Methods;
                Console.WriteLine($"{className}:");

                foreach (var method in methods)
                {
                    var methodName = method.MethodName;
                    var tests = method.Tests.OrderBy(x => x.Length).ThenBy(s => s);
                    Console.WriteLine($"##{methodName}");

                    foreach (var test in tests)
                    {
                        Console.WriteLine($"####{test}");
                    }
                }
            }
        }

        private static void ParseLine(List<Class> database, string inputLine)
        {
            var validPattern = @"^(?<className>[A-Z][A-Za-z0-9]+)(?: \| )(?<methodName>[A-Z][A-Za-z0-9]+)(?: \| )(?<testName>[A-Z][A-Za-z0-9]+)$";
            var match = Regex.Match(inputLine, validPattern);

            if (!match.Success)
            {
                return;
            }

            var className = match.Groups["className"].Value.Trim();
            var methodName = match.Groups["methodName"].Value.Trim();
            var testName = match.Groups["testName"].Value.Trim();

            if (database.All(x => x.ClassName != className))
            {
                var currentListOfTests = new List<string>();
                currentListOfTests.Add(testName);
                var currentMethod = new Method(methodName, currentListOfTests);
                var currentListOfMethods = new List<Method>();
                currentListOfMethods.Add(currentMethod);
                var currentClass = new Class(className, currentListOfMethods);
                database.Add(currentClass);
            }

            if (database.First(x => x.ClassName == className).Methods.All(x => x.MethodName != methodName))
            {
                var currentListOfTest = new List<string>();
                currentListOfTest.Add(testName);
                var currentMethod = new Method(methodName, currentListOfTest);
                database.First(x => x.ClassName == className).Methods.Add(currentMethod);
            }

            if (database.First(x => x.ClassName == className).Methods.First(x => x.MethodName == methodName).Tests.All(x => x != testName ))
            {
                database.First(x => x.ClassName == className).Methods.First(x => x.MethodName == methodName).Tests.Add(testName);
            }
        }
    }
}
