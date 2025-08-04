using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Methods
{
    internal class RemoveCheck
    {
        static public List<Student> Student(List<Student> students)
        {
            if (!students.Any())
            {
                Console.WriteLine("No students found");
            }
            else
            {
                Student studentToRemove = Find.Student(students);
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
    }
}
