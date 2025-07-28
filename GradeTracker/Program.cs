using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GradeTracker
{
    class Program
    {
        int aClassNum = 0;
        int assignmentNum = 0;
        
        
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
            Console.Write("Input new assignment name: ");
            Assignment assignment = new Assignment(Console.ReadLine());
        }

        static public void Add()
        {
            List<Student> students = new List<Student>();
            List<AClass> classes = new List<AClass>();
            string input;

            Console.WriteLine("Write \"stu\" to add a new student");
            Console.WriteLine("Write \"subj\" to add a new subject");
            Console.WriteLine("Write \"as\" to add a new assignment");
            input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "stu":
                    Student student = AddStudent();
                    students.Add(student);
                    Console.WriteLine($"Student {student}");

                    Add();
                    break;
                case "subj":
                    AClass aclass = AddAClass();
                    classes.Add(aclass);

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

                    foreach (AClass i in  classes)
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
