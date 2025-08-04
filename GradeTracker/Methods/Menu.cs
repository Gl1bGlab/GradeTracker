using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Methods
{
    internal class Menu
    {
        static public void Start(List<Student> students, List<AClass> aClasses, List<Assignment> assignments)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Grade Tracker");
            Console.WriteLine("Type \"add\" for the add menu");
            Console.WriteLine("Type \"rem\" for the remove menu");
            Console.WriteLine("Type \"edit\" for the edit menu");
            Console.WriteLine("Type \"view\" for the view menu");
            Console.WriteLine("Type \"del\" to delete current saved data");
            Console.WriteLine("Type \"end\" to save and quit the program");

            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "add":
                    Add(students, aClasses, assignments);
                    break;
                case "rem":
                    Remove(students, aClasses, assignments);
                    break;
                case "edit":
                    Edit(students, aClasses, assignments);
                    break;
                case "view":
                    View(students, aClasses, assignments);
                    break;
                case "del":
                    DeleteData(students, aClasses, assignments);
                    break;
                case "end":
                    break;
                default:
                    Start(students, aClasses, assignments);
                    break;
            }
        }
        static public void Add(List<Student> students, List<AClass> aClasses, List<Assignment> assignments)
        {
            switch (Template("add", false))
            {
                case "stu":
                    Student student = MenuOptions.Add.Student();
                    students.Add(student);
                    Console.WriteLine($"Student {student}");
                    Console.WriteLine();
                    if (aClasses.Any())
                    {
                        Console.WriteLine($"Write \"add\" to add {student.Name} to a subject now");
                        if (Console.ReadLine() == "add")
                        {
                            AClass selectedAClass = Find.AClass(aClasses);
                            student.AddAClass(selectedAClass);
                            selectedAClass.AddStudent(student);
                        }
                    }

                    Add(students, aClasses, assignments);
                    break;

                case "subj":
                    AClass aClass = MenuOptions.Add.AClass();
                    aClasses.Add(aClass);

                    if (students.Any())
                    {
                        Console.WriteLine("Write \"add\" to add students now");
                        Console.WriteLine("Write anything else to add students later");
                        if (Console.ReadLine().ToLower() == "add")
                        {
                            Student selectedStudent = Find.Student(students);
                            aClass.AddStudent(selectedStudent);
                            selectedStudent.AddAClass(aClass);
                        }
                    }

                    Add(students, aClasses, assignments);
                    break;

                case "as":
                    if (!aClasses.Any())
                    {
                        Console.WriteLine("Assignments cannont be created without any existing subjects");
                    }
                    else
                    {
                        Assignment assignment = MenuOptions.Add.Assignment(aClasses);
                        assignments.Add(assignment);

                        AClass selectedClass = Find.AClass(aClasses);

                        selectedClass.AddAssignment(assignment);
                        assignment.AssignToAClass(selectedClass.Name);
                    }

                    Add(students, aClasses, assignments);
                    break;

                case "back":
                    Console.WriteLine();
                    Start(students, aClasses, assignments);
                    break;

                default:
                    //TODO: remove later

                    Add(students, aClasses, assignments);
                    break;
            }

        }
        static public void Remove(List<Student> students, List<AClass> aClasses, List<Assignment> assignments)
        {
            //TODO
            switch (Template("remove", false))
            {
                case "stu":
                    students = RemoveCheck.Student(students);
                    Remove(students, aClasses, assignments);
                    break;
                case "subj":

                    Remove(students, aClasses, assignments);
                    break;
                case "as":

                    Remove(students, aClasses, assignments);
                    break;
                case "back":
                    Console.WriteLine();
                    Start(students, aClasses, assignments);
                    break;
                default:
                    Remove(students, aClasses, assignments);
                    break;
            }
        }
        static public void Edit(List<Student> students, List<AClass> aClasses, List<Assignment> assignments)
        {
            //TODO
            switch (Template("edit", false))
            {
                case "stu":

                    break;
                case "subj":

                    break;
                case "as":

                    break;
                case "back":
                    Console.WriteLine();
                    Start(students, aClasses, assignments);
                    break;
                default:
                    Edit(students, aClasses, assignments);
                    break;
            }
        }
        static public void View(List<Student> students, List<AClass> aClasses, List<Assignment> assignments)
        {
            //TODO
            switch (Template("view", false))
            {
                case "stu":
                    Student student = Find.Student(students);
                    MenuOptions.View.Student(student);
                    View(students, aClasses, assignments);
                    break;
                case "subj":

                    break;
                case "as":

                    break;
                case "back":
                    Console.WriteLine();
                    Start(students, aClasses, assignments);
                    break;
                default:
                    View(students, aClasses, assignments);
                    break;
            }
        }
        static public void DeleteData(List<Student> students, List<AClass> aClasses, List<Assignment> assignments)
        {
            switch (Template("delete", true))
            {
                case "stu":
                    students = MenuOptions.DeleteData.Student(students);
                    DeleteData(students, aClasses, assignments);
                    break;
                case "subj":
                    aClasses = MenuOptions.DeleteData.AClass(aClasses);
                    DeleteData(students, aClasses, assignments);
                    break;
                case "as":
                    assignments = MenuOptions.DeleteData.Assignment(assignments);
                    DeleteData(students, aClasses, assignments);
                    break;
                case "back":
                    Console.WriteLine();
                    Start(students, aClasses, assignments);
                    break;
                default:
                    View(students, aClasses, assignments);
                    break;
            }
        }
        static string Template(string menuType, bool delete)
        {
            
            if (delete)
            {
                Console.WriteLine();
                Console.WriteLine($"Write \"stu\" to {menuType} all student data");
                Console.WriteLine($"Write \"subj\" to {menuType} all subject and assignment data");
                Console.WriteLine($"Write \"as\" to {menuType} all assignment data");
            } 
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Write \"stu\" to {menuType} a student");
                Console.WriteLine($"Write \"subj\" to {menuType} a subject");
                Console.WriteLine($"Write \"as\" to {menuType} an assignment");
            }
            Console.WriteLine($"Write \"back\" to go back to the start menu");


            string input = Console.ReadLine().ToLower();
            return input;
        }
    }
}
