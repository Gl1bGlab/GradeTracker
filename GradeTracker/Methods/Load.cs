using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GradeTracker.Methods
{
    internal class Load
    {
        public static List<Student> Students(List<Student> students)
        {
            string path = Paths.student;
            if (File.Exists(path))
            {
                string jason = File.ReadAllText(path);
                students = JsonSerializer.Deserialize<List<Student>>(jason);
                Console.WriteLine("Student file loaded");
            }
            else
            {
                Console.WriteLine("No student file found");
            }
                return students;
        }
        public static List<AClass> AClasses(List<AClass> aClasses)
        {
            string path = Paths.aClass;
            if (File.Exists(path))
            {
                string jason = File.ReadAllText(path);
                aClasses = JsonSerializer.Deserialize<List<AClass>>(jason);
                Console.WriteLine("Subject file loaded");
            }
            else
            {
                Console.WriteLine("No subject file found");
            }
            return aClasses;
        }
        public static List<Assignment> Assignments(List<Assignment> assignment)
        {
            string path = Paths.assignment;
            if (File.Exists(path))
            {
                string jason = File.ReadAllText(path);
                assignment = JsonSerializer.Deserialize<List<Assignment>>(jason);
                Console.WriteLine("Assignment file loaded");
            }
            else
            {
                Console.WriteLine("No assignment file found");
            }
            return assignment;
        }
        /*public static List<Student> Students(List<Student> students)
        {
            string studentPath = $"GradeTracker{TypeFilesEnum.Students}.json";
            if (!File.Exists(studentPath))
            {
                File.Create(studentPath);
                Console.WriteLine("No student data found, new save file created");
            }
            else
            {
                string file = File.ReadAllText(studentPath);
                if (file != "[]")
                {
                    students = JsonSerializer.Deserialize<List<Student>>(file);
                }
                else
                {
                    Console.WriteLine("No data found in student folder");
                }
            }
            return students;
        }
        public static List<AClass> AClasses(List<AClass> aClasses)
        {
            string aClassPath = $"GradeTracker{TypeFilesEnum.AClasses}.json";

            if (!File.Exists(aClassPath))
            {
                File.Create(aClassPath);
                Console.WriteLine("No subject data found, new save file created");
            }
            else
            {
                string file = File.ReadAllText(aClassPath);
                if (file != "[]")
                {
                    aClasses = JsonSerializer.Deserialize<List<AClass>>(file);
                }
                else
                {
                    Console.WriteLine("No data found in subject folder");
                }
            }
            return aClasses;
        }
        public static List<Assignment> Assignments(List<Assignment> assignments)
        {
            string assignmentPath = $"GradeTracker{TypeFilesEnum.Assignments}.json";
            if (!File.Exists(assignmentPath))
            {
                File.Create(assignmentPath);
                Console.WriteLine("No assignment data found, new save file created");
            }
            else
            {
                string file = File.ReadAllText(assignmentPath);
                if (file != "[]")
                {
                    assignments = JsonSerializer.Deserialize<List<Assignment>>(file);
                }
                else
                {
                    Console.WriteLine("No data found in assignment folder");
                }

            }
            return assignments;
        }
        public static void Close()
        {
            string studentPath = $"GradeTracker{TypeFilesEnum.Students}.json";
            string aClassPath = $"GradeTracker{TypeFilesEnum.AClasses}.json";
            string assignmentPath = $"GradeTracker{TypeFilesEnum.Assignments}.json";

            StreamWriter studentWriter = new StreamWriter(studentPath);
            studentWriter.Close();
            StreamWriter aClassWriter = new StreamWriter(aClassPath);
            aClassWriter.Close();
            StreamWriter assignmentWriter = new StreamWriter(assignmentPath);
            assignmentWriter.Close();
        }*/
    }
}
