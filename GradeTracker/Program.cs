using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GradeTracker.Constants;

namespace GradeTracker
{
    class Program
    {
        int aClassNum = 0;
        int assignmentNum = 0;
        
        

        static public Tuple<int, string, bool> example()
        {
            return new Tuple<int, string, bool> ( 1, "ex", false );
        }

        static public void ble()
        {
            var sumname = example();
            Console.WriteLine( sumname.Item1 );
        }

        static public Student AddStudent()
        {
            Console.WriteLine();
            Console.Write("Input new student name and age: ");
            Student student = new Student(Console.ReadLine(), Convert.ToInt16(Console.ReadLine()));

            return student;
        }

        static public AClass AddAClass()
        {
            Console.WriteLine();
            Console.Write("Input new subject name: ");
            AClass aClass = new AClass(Console.ReadLine());

            Console.WriteLine("Write \"add\" to add assignments now");
            Console.WriteLine("Write anything else to add assignments later");
            if (Console.ReadLine().ToLower() == "add")
            {
                
            }

            return aClass;
        }

        static public void AddAssignment()
        {
            Console.WriteLine();
            Console.WriteLine("Input new assignment name: ");
            string assName = Console.ReadLine();
            Console.WriteLine("Input new assignment type: ");
            //TODO: List enums, fix mess, add fix for different cases
            Assignment assignment = new Assignment(assName, (AssignmentTypeEnum)Convert.ToInt16(Console.ReadLine()));
        }

        static public void Add()
        {
            List<Student> students = new List<Student>();
            List<AClass> aClasses = new List<AClass>();
            string input;
            

            Console.WriteLine("Write \"stu\" to add a new student");
            Console.WriteLine("Write \"subj\" to add a new subject");
            Console.WriteLine("Write \"as\" to add a new assignment");
            //TODO: add back
            input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "stu":
                    Student student = AddStudent();
                    students.Add(student);
                    Console.WriteLine($"Student {student}");
                    if (aClasses.Any())
                    {
                        Console.WriteLine("Write a class name to add new student to it");
                        string className = Console.ReadLine().ToLower();
                        AClass selectedClass = aClasses.First(c => c.Name == className);
                        student.AddClass(selectedClass);
                    }

                    Add();
                    break;
                case "subj":
                    AClass aclass = AddAClass();
                    aClasses.Add(aclass);

                    Add(); 
                    break;
                case "as":

                    break;
                default:
                    foreach (Student i in students)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine();

                    foreach (AClass i in  aClasses)
                    {
                        Console.WriteLine(i);
                    }
                    
                    break;
            }
            
        }
        static public void Remove()
        {
            

            string input;
            Console.WriteLine("Write \"stu\" to remove a student");
            Console.WriteLine("Write \"subj\" to remove a subject");
            Console.WriteLine("Write \"as\" to remove a assignment");
            input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "stu":

                    break;
                case "subj":

                    break;
                case "as":

                    break;
                default:

                    break;
            }
        }
        static public void Edit()
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Grade Tracker");
            Add();
            
            

        }
    }
}
