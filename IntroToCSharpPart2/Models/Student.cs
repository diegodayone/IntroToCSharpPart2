using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2.Models
{
    class Student
    {
        public string Name;
        public string Surname;
        public int ID;

        public static int NumberOfStudents = 0;

        public Student()
        {
            NumberOfStudents++;
            ID = NumberOfStudents;
        }
    }

    class MasterDegreeStudent : Student
    {
        public string Specialization;


    }
}
