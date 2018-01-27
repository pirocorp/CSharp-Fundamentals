namespace _04.JSON_Parse
{
    using System;
    using System.Collections.Generic;
    using _03.JSON_Stringify;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var students = new List<Student>();
            var inputStudents = Console.ReadLine()
                .Split(new[] {"},{"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim("[{".ToCharArray()))
                .Select(x => x.Trim("}".ToCharArray()))
                .ToArray();

            var lastElement = inputStudents[inputStudents.Length - 1];
            lastElement = lastElement.Substring(0, lastElement.Length - 2);
            inputStudents[inputStudents.Length - 1] = lastElement;

            for (int i = 0; i < inputStudents.Length; i++)
            {
                var currentStudent = Student.JsonParse(inputStudents[i]);
                students.Add(currentStudent);
            }

            foreach (var student in students)
            {
                var grades = student.Grades.Count > 0 ? String.Join(", ", student.Grades) : "None";
                Console.WriteLine($"{student.Name} : {student.Age} -> {grades}");
            }
        }
    }
}
