using System.Collections.Generic;
using System.Linq;

namespace _01.Exercises
{
    using System;

    public class Exercises
    {
        public class Exercise
        {
            public string Topic { get; set; }
            public string CourseName { get; set; }
            public string JudgeContestLink { get; set; }
            public List<string> Problems { get; set; }

            public static Exercise Parse(string inputData)
            {
                //{topic} -> {courseName} -> {judgeContestLink} -> {problem1}, {problem2}
                var tokens = inputData.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                var topic = tokens[0];
                var courseName = tokens[1];
                var judgeContestLink = tokens[2];
                var problems = tokens[3].Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).ToList();

                var result = new Exercise()
                {
                    Topic = topic,
                    CourseName = courseName,
                    JudgeContestLink = judgeContestLink,
                    Problems = problems
                };

                return result;
            }
        }

        public static void Main()
        {
            var listOfExercises = new List<Exercise>();
            var inputData = Console.ReadLine();

            while (inputData != "go go go")
            {
                var currentExercise = Exercise.Parse(inputData);
                listOfExercises.Add(currentExercise);
                inputData = Console.ReadLine();
            }

            foreach (var exercise in listOfExercises)
            {
                var topic = exercise.Topic;
                var courseName = exercise.CourseName;
                var judgeContestLink = exercise.JudgeContestLink;
                var problems = exercise.Problems;
                Console.WriteLine($"Exercises: {topic}");
                Console.WriteLine($"Problems for exercises and homework for the \"{courseName}\" course @ SoftUni.");
                Console.WriteLine($"Check your solutions here: {judgeContestLink}");

                for (int i = 0; i < problems.Count; i++)
                {
                Console.WriteLine($"{i + 1}. {problems[i]}");

                }
            }
        }
    }
}
