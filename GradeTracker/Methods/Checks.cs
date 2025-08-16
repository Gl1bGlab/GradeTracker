using GradeTracker.Constants;
using GradeTracker.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Methods
{
    internal static class Checks
    {
        static public List<Student> Student(List<Student> students)
        {
            if (!students.Any())
            {
                Console.WriteLine("No students found");
            }
            else
            {
                Student studentToRemove = Find.StudentInputID(students);
                bool validConforamtion = false;

                while (!validConforamtion)
                {
                    Console.WriteLine($"Are you sure you want to remove {studentToRemove.Name}? Y/N");
                    string conformation = Console.ReadLine().ToLower();
                    if (conformation == "y")
                    {
                        students.Remove(studentToRemove);
                        validConforamtion = true;
                    }
                    else if (conformation == "n")
                    {
                        validConforamtion = true;
                    }
                }
            }
            return students;
        }
        static public bool IfAny<T>(List<T> list, string type)
        {
            bool any;
            if (!list.Any())
            {
                any = false;
                Console.WriteLine($"No {type} found");
            } 
            else
                any = true;
            return any;
        }
    }
}
