namespace _03.JSON_Stringify
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine();
            var students = new List<Student>();

            while (inputData != "stringify")
            {
                students.Add(Student.Parse(inputData));
                inputData = Console.ReadLine();
            }

            Console.WriteLine($"[{String.Join(",", students)}]");
        }
    }
}