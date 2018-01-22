using System.Collections.Generic;
using System.Linq;

namespace _10.Average_Grades
{
    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public double AverageGrade
        {
            get { return  Grades.Average(); }
        }
    }
}
