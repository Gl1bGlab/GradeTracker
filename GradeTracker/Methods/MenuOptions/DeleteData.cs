using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Methods.MenuOptions
{
    internal class DeleteData
    {
//TODO: get rid of potential left over data
        static public List<Student> Student(List<Student> students)
        {
            bool conformation = false;
            while (conformation == false)
            {
                Console.WriteLine("Are you sure you want to delete all student data? Y/N");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    string path = Paths.student;
                    File.Delete(path);
                    students = new List<Student>();
                    conformation = true;
                } 
                else if (answer == "n")
                {
                    conformation = true;
                }
            }
            return students;
        }
        static public List<AClass> AClass(List<AClass> aClasses)
        {
            bool conformation = false;
            while (conformation == false)
            {
                Console.WriteLine("Are you sure you want to delete all subject and assignment data? Y/N");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    string path = Paths.aClass;
                    File.Delete(path);
                    aClasses = new List<AClass>();
                    conformation = true;
                }
                else if (answer == "n")
                {
                    conformation = true;
                }
            }
            return aClasses;
        }
        static public List<Assignment> Assignment(List<Assignment> assignments)
        {
            bool conformation = false;
            while (conformation == false)
            {
                Console.WriteLine("Are you sure you want to delete all student data? Y/N");
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    string path = Paths.assignment;
                    File.Delete(path);
                    assignments = new List<Assignment>();
                    conformation = true;
                }
                else if (answer == "n")
                {
                    conformation = true;
                }
            }
            return assignments;
        }
    }
}
