using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _13.Average_Grades
{
    class Program
    {
        static void Main()
        {
            var students = new List<Student>();
            var inputLines = File.ReadAllLines("Input.txt");

            for (int i = 0; i < inputLines.Length; i++)
            {
                var tokens = inputLines[i].Split(' ').ToList();
                var name = tokens[0];
                var listOfGrades = tokens.Skip(1).Select(double.Parse).ToList();
                var currentStudent = new Student(name, listOfGrades);
                students.Add(currentStudent);
            }

            var result = students
                .Where(x => x.AverageGrade >= 5)
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.AverageGrade)
                .ToList();

            result.ForEach(x => File.AppendAllLines("Output.txt", new []{ $"{x.Name} -> {x.AverageGrade:f2}" }));
        }
    }
}
