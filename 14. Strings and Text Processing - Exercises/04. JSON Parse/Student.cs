namespace _03.JSON_Stringify
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public Student(string name, int age, List<double> grades)
        {
            Name = name;
            Age = age;
            Grades = grades;
        }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
            Grades = new List<double>();
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public List<double> Grades { get; set; }

        public static Student Parse(string inputData)
        {
            var tokens = inputData.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
            var studentData = tokens[0]
                .Trim()
                .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            var studentName = studentData[0];
            var studentAge = int.Parse(studentData[1]);

            if (tokens.Length == 1)
            {
                return new Student(studentName, studentAge);
            }

            var grades = tokens[1]
                .Trim()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Select(double.Parse)
                .ToList();

            return new Student(studentName, studentAge, grades);
        }

        //name:"{name}",age:{age},grades:[{grade1}, {grade2}. . .]
        public static Student JsonParse(string inputData)
        {
            var tokens = inputData.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[1].Split('\"').Skip(1).First();
            var age = int.Parse(tokens[2].Split(',').First());
            var stringGrades = tokens[3];

            if (stringGrades.Length > 2)
            {
                var grades = stringGrades.Trim('[').Trim(']').Split(',').Select(double.Parse).ToList();
                return new Student(name, age, grades);
            }

            return new Student(name, age);
        }

        public override string ToString()
        {
            return $"{{name:\"{this.Name}\",age:{this.Age},grades:[{String.Join(", ", this.Grades)}]}}";
        }
    }
}