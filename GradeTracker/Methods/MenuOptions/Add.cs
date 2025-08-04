using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Methods.MenuOptions
{
    internal class Add
    {
        static public Student Student()
        {
            Console.WriteLine();
            Console.WriteLine("Input new student name and age");
            Console.Write("Name: ");
            string studentName = Console.ReadLine();
            Console.Write("Age: ");
            string studentAge = Console.ReadLine();

            bool converted = Int32.TryParse(studentAge, out Int32 studentInt);
            if (converted)
            {
                Student student = new Student(studentName, studentInt);
                return student;
            }
            else
            {
                Console.WriteLine("Failed to assign age, please edit later");
                Student student = new Student(studentName, 0);
                return student;
            }
        }

        static public AClass AClass()
        {
            Console.WriteLine();
            Console.Write("Input new subject name: ");
            AClass aClass = new AClass(Console.ReadLine());

            return aClass;
        }

        static public Assignment Assignment(List<AClass> aClasses)
        {
            Console.WriteLine();
            Console.WriteLine("Input new assignment name:");
            string assName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Input new assignment type as a number:");
            Console.WriteLine("Homework - 0");
            Console.WriteLine("Quiz - 1");
            Console.WriteLine("Test - 2");
            Console.WriteLine("Exam - 3");
            Console.WriteLine("Project - 4");

            string assType = Console.ReadLine();
            if (assType != "0" && assType != "1" && assType != "2" && assType != "3" && assType != "4")
            {
                Console.WriteLine("Failed to assign a type, set to default (Homework)");
                assType = "0";
            }

            Console.WriteLine("Input new assignment max score as a number");
            bool isNumeric = int.TryParse(Console.ReadLine(), out int maxScore);
            if (!isNumeric)
            {
                Console.WriteLine("Failed to assign a max score, set to default (100)");
                maxScore = 100;
            }

            DateTime dateTime = DateTime.Now;

            Assignment assignment = new Assignment(assName, (AssignmentTypeEnum)Convert.ToInt16(assType), maxScore, dateTime, 0);
            return assignment;
        }
    }
}
