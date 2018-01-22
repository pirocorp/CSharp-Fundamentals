using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Average_Grades
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ').ToList();
                var name = tokens[0];
                var listOfGrades = tokens.Skip(1).Select(double.Parse).ToList();
                var currentStudent = new Student()
                {
                    Name = name,
                    Grades = listOfGrades
                };
                students.Add(currentStudent);
            }

            var result = students
                .Where(x => x.AverageGrade >= 5)
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.AverageGrade)
                .ToList();

            result.ForEach(x => Console.WriteLine($"{x.Name} -> {x.AverageGrade:f2}"));
        }
    }
}
