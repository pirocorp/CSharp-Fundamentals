using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _14.Mentor_Group
{
    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine();
            var students = new Dictionary<string, Student>();

            while (inputData != "end of dates")
            {
                var tokens = inputData.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var currentStudentName = tokens[0];
                var format = "dd/MM/yyyy";
                var listOfDates = new List<DateTime>();

                if (tokens.Length > 1)
                {
                    var list = tokens[1].Split(new[] { ',' })
                        .Select(x => DateTime.ParseExact(x, format, CultureInfo.InvariantCulture)).ToList();
                    listOfDates.AddRange(list);
                }

                if (!students.ContainsKey(currentStudentName))
                {
                    var currentStudent = new Student()
                    {
                        Name = currentStudentName,
                        Dates = listOfDates,
                        Comments = new List<string>()
                    };

                    students[currentStudentName] = currentStudent;
                    inputData = Console.ReadLine();
                    continue;
                }

                students[currentStudentName].Dates.AddRange(listOfDates);
                inputData = Console.ReadLine();
            }

            inputData = Console.ReadLine();

            while (inputData != "end of comments")
            {
                var tokens = inputData.Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                var currentStudentName = tokens[0];
                var currentStudentComment = tokens[1];

                if (students.ContainsKey(currentStudentName))
                {
                    students[currentStudentName].Comments.Add(currentStudentComment);
                }

                inputData = Console.ReadLine();
            }

            students.OrderBy(x => x.Key).ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Key}");
                Console.WriteLine("Comments:");
                x.Value.Comments.ForEach(y => Console.WriteLine($"- {y}"));
                Console.WriteLine("Dates attended:");
                x.Value.Dates.OrderBy(o => o).ToList().ForEach(z => Console.WriteLine($"-- {z.Day}/{z.Month:d2}/{z.Year}"));
            });
        }
    }
}
