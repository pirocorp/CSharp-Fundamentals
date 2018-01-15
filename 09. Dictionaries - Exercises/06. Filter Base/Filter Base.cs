using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Filter_Base
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var listOfEmployees = new Dictionary<string, List<string>>();

            while (input != "filter base")
            {
                var inputStrings = input.Split(new[] {'-', '>'}, StringSplitOptions.RemoveEmptyEntries);
                var key = inputStrings[0].Trim();
                var dataToBeSorted = inputStrings[1].Trim();

                if (!listOfEmployees.ContainsKey(key))
                {
                    var listOfEmployeeData = MakeList();
                    listOfEmployees.Add(key, listOfEmployeeData);
                }

                var newList = NewListOfData(listOfEmployees[key], dataToBeSorted);
                listOfEmployees[key] = newList;
                input = Console.ReadLine();
            }

            var filterBase = Console.ReadLine();
            PrintData(listOfEmployees, filterBase);
        }

        private static void PrintData(Dictionary<string, List<string>> listOfEmployees, string filterBase)
        {
            //0 - age, 1 - salary, 2 - position
            if (filterBase == "Age")
            {
                foreach (var employee in listOfEmployees)
                {
                    if (employee.Value[0] != "-1")
                    {
                        Console.WriteLine($"Name: {employee.Key}");
                        Console.WriteLine($"Age: {employee.Value[0]}");
                        Console.WriteLine(new string('=', 20));
                    }
                }
            }
            else if (filterBase == "Salary")
            {
                foreach (var employee in listOfEmployees)
                {
                    if (employee.Value[1] != "-1")
                    {
                        Console.WriteLine($"Name: {employee.Key}");
                        Console.WriteLine($"Salary: {double.Parse(employee.Value[1]):f2}");
                        Console.WriteLine(new string('=', 20));
                    }
                }
            }
            else if (filterBase == "Position")
            {
                foreach (var employee in listOfEmployees)
                {
                    if (!String.IsNullOrEmpty(employee.Value[2]))
                    {
                        Console.WriteLine($"Name: {employee.Key}");
                        Console.WriteLine($"Position: {employee.Value[2]}");
                        Console.WriteLine(new string('=', 20));
                    }
                }
            }
        }

        private static List<string> NewListOfData(List<string> employeeData, string dataToBeSorted)
        {
            var resultedList = new List<string>();
            //0 - age, 1 - salary, 2 - position

            if (int.TryParse(dataToBeSorted, out var intNumber))
            {
                resultedList.Add($"{intNumber}");
                resultedList.Add(employeeData[1]);
                resultedList.Add(employeeData[2]);
            }
            else if (double.TryParse(dataToBeSorted, out var doubleNumber))
            {
                resultedList.Add(employeeData[0]);
                resultedList.Add($"{doubleNumber}");
                resultedList.Add(employeeData[2]);
            }
            else
            {
                resultedList.Add(employeeData[0]);
                resultedList.Add(employeeData[1]);
                resultedList.Add(dataToBeSorted);
            }

            return resultedList;
        }

        private static List<string> MakeList()
        {
            var resultedList = new List<string>();
            //0 - age, 1 - salary, 2 - position
            resultedList.Add("-1");
            resultedList.Add("-1");
            resultedList.Add(string.Empty);
            return resultedList;
        }
    }
}
