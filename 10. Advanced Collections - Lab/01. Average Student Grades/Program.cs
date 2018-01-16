using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _01.Average_Student_Grades
{
    class Program
    {
        static void Main()
        {
            var gradesDict = new Dictionary<string, List<double>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var student = tokens[0];
                var grade = double.Parse(tokens[1]);

                if (!gradesDict.ContainsKey(student))
                {
                    gradesDict[student] = new List<double>();
                }

                gradesDict[student].Add(grade);
            }

            foreach (var studentData in gradesDict)
            {
                var student = studentData.Key;
                var gradesList = studentData.Value;
                string result = string.Empty;
                foreach (var grade in gradesList)
                {
                    result += $"{grade:f2} ";
                }
                Console.WriteLine($"{student} -> {result}(avg: {gradesList.Average():f2})");
            }
        }
    }
}
