using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using GradeTracker.Classes;

namespace GradeTracker.Methods
{
    internal static class Load
    {
        //figuring out Json stuff was kinda annoying cuz i kept seeing info about 2 entirely different versions
        //was super satisfying to finally get it tho
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
    }
}
