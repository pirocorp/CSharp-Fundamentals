namespace _01._BonusScoringSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var studentsCount = int.Parse(Console.ReadLine());
            var lecturesCount = int.Parse(Console.ReadLine());
            var initialBonus = int.Parse(Console.ReadLine());

            var studentAttendances = new List<int>();

            for (var i = 0; i < studentsCount; i++)
            {
                var att = int.Parse(Console.ReadLine());
                studentAttendances.Add(att);
            }

            var result = studentAttendances
                .Select(s => new
                {
                    Attend = s,
                    Bonus = s / (double) lecturesCount * (5 + initialBonus)
                })
                .OrderByDescending(x => x.Bonus)
                .FirstOrDefault();

            Console.WriteLine($"Max Bonus: {Math.Ceiling(result?.Bonus ?? 0)}.");
            Console.WriteLine($"The student has attended {result?.Attend ?? 0} lectures.");
        }
    }
}