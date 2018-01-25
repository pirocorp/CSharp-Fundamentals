using System.Collections.Generic;
using System.Linq;

namespace _13.Average_Grades
{
    class Student
    {
        public Student(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
        }

        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public double AverageGrade
        {
            get { return Grades.Average(); }
        }

    }
}
