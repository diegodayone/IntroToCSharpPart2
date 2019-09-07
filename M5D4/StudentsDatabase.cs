using IntroToCSharpPart2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace M5D4
{
    class StudentsDatabase
    {
        private static List<Student> studentDB;
        private static List<Student> StudentDB
        {
            get
            {
                if (studentDB == null)
                {
                    if (File.Exists("students.json"))
                        studentDB = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText("students.json"));
                    else
                    {
                        studentDB = new List<Student>();
                        var file = File.Create("students.json");
                        file.Dispose();
                    }
                }

                return studentDB;
            }
        }

        public static Student[] StudentList() => StudentDB.ToArray();

        public static void AddStudent(Student toAdd)
        {
            StudentDB.Add(toAdd);
            File.WriteAllText("students.json", JsonConvert.SerializeObject(toAdd));
        }

        public static void RemoveStudent(Student toRemove)
        {
            StudentDB.Remove(toRemove);
            File.WriteAllText("students.json", JsonConvert.SerializeObject(toRemove));
        }
    }
}
