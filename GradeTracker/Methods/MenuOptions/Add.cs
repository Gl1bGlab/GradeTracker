using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeTracker.Classes;

namespace GradeTracker.Methods.MenuOptions
{
    internal static class Add
    {
        //the process of adding stuff is probably what i've changed the most so far
        static public Student Student()
        {
            Console.WriteLine();
            Console.WriteLine("Input new student name and age");
            Console.Write("Name: ");
            string studentName = Console.ReadLine();
            Console.Write("Age: ");

            Int16 studentInt = Find.WriteAnIntDummy();
            Student student = new Student(studentName, studentInt);
            return student;
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
            while (assType != "5" && assType != "1" && assType != "2" && assType != "3" && assType != "4")
            {
                Console.WriteLine("Invalid input, please try again");
                assType = Console.ReadLine();
            }

            Console.WriteLine("Input new assignment max score as a number");
            int maxScore = Find.WriteAnIntDummy();

            DateTime dateTime = DateTime.Now;

            int aClassesID = Find.AClassInputID(aClasses).ID;

            Assignment assignment = new Assignment(assName, (AssignmentTypeEnum)Convert.ToInt16(assType)-1, maxScore, dateTime, aClassesID);
            return assignment;
        }
        static public (List<Student>, AClass) StudentsToAClass(List<Student> students, AClass aClass, bool createdYet)
        {
            List<Student> unaddedStudents = new List<Student>();
            foreach (Student s in students)
            {
                if (!createdYet)
                    unaddedStudents.Add(s);
                else
                {
                    foreach (AClass c in s.AClasses)
                    {
                        if (!s.AClasses.Contains(c))
                            unaddedStudents.Add(s);
                    }
                }
            }
            string input;
            do
            {
                Console.WriteLine("Type \"add\" to add more students\nType \"done\" if you are done adding students");
                input = Console.ReadLine();
                if (input != "add")
                {
                    continue;
                }
                Student selectedStudent = Find.StudentInputID(unaddedStudents);
                Student student = Find.StudentByID(students, selectedStudent.ID);
                unaddedStudents.Remove(selectedStudent);
                aClass.AddStudent(student);
                student.AddAClass(aClass);
            }
            while (input != "done" && unaddedStudents.Any());
            return (students, aClass);
        }
        static public (List<AClass>, Student) AClassesToStudent(List<AClass> aClasses, Student student, bool createdYet)
        {
            List<AClass> unaddedAClass = new List<AClass>();
            foreach (AClass c in aClasses)
            {
                if (!createdYet)
                    unaddedAClass.Add(c);
                else
                {
                    foreach (Student s in c.Students)
                    {
                        if (!c.Students.Contains(s))
                            unaddedAClass.Add(c);
                    }
                }
            }
            string input;
            do
            {
                Console.WriteLine("Type \"add\" to add more subjects\nType \"done\" if you are done adding subjects");
                input = Console.ReadLine();
                if (input != "add")
                {
                    continue;
                }
                AClass selectedAClass = Find.AClassInputID(unaddedAClass);
                AClass aClass = Find.AClassByID(aClasses, selectedAClass.ID);
                unaddedAClass.Remove(selectedAClass);
                aClass.AddStudent(student);
                student.AddAClass(aClass);
            }
            while (input != "done" && unaddedAClass.Any());
            return (aClasses, student);
        }
        static public void AssignmentToStudents(List<Student> students, Assignment assignment)
        {
            foreach (Student s in students)
            {
                foreach (AClass c in s.AClasses)
                {
                    if (assignment.AClassID == c.ID)
                    {
                        c.AddAssignment(assignment);
                        continue;
                    }
                }
            }
        }
    }
}
