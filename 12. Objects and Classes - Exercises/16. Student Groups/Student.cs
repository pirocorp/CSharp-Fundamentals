using System;
using System.Globalization;
using System.Linq;

namespace _16.Student_Groups
{
    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public static Student Parse(string inputData)
        {
            var tokens = inputData.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            var name = tokens[0];
            var email = tokens[1];
            var format = "d-MMM-yyyy";
            var regDate = DateTime.ParseExact(tokens[2], format, CultureInfo.InvariantCulture);

            var newStudent = new Student()
            {
                Name = name,
                Email = email,
                RegistrationDate = regDate
            };

            return newStudent;
        }
    }
}
