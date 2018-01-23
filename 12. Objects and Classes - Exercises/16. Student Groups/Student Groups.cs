using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Student_Groups
{
    class Program
    {
        static void Main()
        {
            var towns = new List<Town>();
            ParseTowns(towns);
            var resultedGroups = DistributeStudentsIntoGroups(towns);
            var countOfGroups = resultedGroups.Count;
            var countOfTowns = towns.Distinct().Count();
            Console.WriteLine($"Created {countOfGroups} groups in {countOfTowns} towns:");

            foreach (var group in resultedGroups)
            {
                var townName = group.Town.Name;
                var studentsList = group.Students;
                Console.WriteLine($"{townName} => {String.Join(", ", studentsList.Select(x => x.Email))}");
            }
        }

        private static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            var groups = new List<Group>();

            foreach (var town in towns.OrderBy(x => x.Name))
            {
                var townName = town.Name;
                var townSeatCount = town.SeatCount;
                var students = town.Students.OrderBy(x => x.RegistrationDate).ThenBy(x => x.Name).ThenBy(x => x.Email).ToList();

                while (students.Any())
                {
                    var group = new Group();
                    group.Town = town;
                    group.Students = students.Take(group.Town.SeatCount).ToList();
                    students = students.Skip(group.Town.SeatCount).ToList();
                    groups.Add(group);
                }
            }

            return groups;
        }

        private static void ParseTowns(List<Town> towns)
        {
            var inputData = Console.ReadLine();
            var currentTownName = String.Empty;

            while (inputData != "End")
            {
                if (inputData.Contains("=>"))
                {
                    var tokens = inputData
                        .Split(new[] {"=>"}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    currentTownName = tokens[0];
                    var seatsString = tokens[1].Split(' ').Select(x => x.Trim()).First();
                    var currentSeatCount = int.Parse(seatsString);
                    var currentStudentList = new List<Student>();

                    var currentTown = new Town()
                    {
                        Name = currentTownName,
                        SeatCount = currentSeatCount,
                        Students = currentStudentList
                    };

                    towns.Add(currentTown);
                    inputData = Console.ReadLine();
                    continue;
                }

                var currentStudent = Student.Parse(inputData);
                var thisTown = towns.Where(x => x.Name == currentTownName).First();
                thisTown.Students.Add(currentStudent);
                inputData = Console.ReadLine();
            }
        }
    }
}
