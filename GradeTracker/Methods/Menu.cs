using GradeTracker.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GradeTracker.Methods.MenuOptions;
using GradeTracker.Methods.MenuOptions.EditStudent;
using GradeTracker.Classes;

namespace GradeTracker.Methods
{
    internal static class Menu
    {
        //the add menu was one of the first things i worked on, so it's a damn mess
        //usually works tho, so I can't complain
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
                    Save(students, aClasses, assignments);
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
                    student.SetID(students);
                    Console.WriteLine($"Assigned ID: {student.ID}\n");
                    if (aClasses.Any())
                    {
                        string input;
                        do
                        {
                            Console.WriteLine($"Type \"add\" to assign {student.Name} to any subjects now");
                            Console.WriteLine($"Type \"later\" to assign subjects later");
                            input = Console.ReadLine();
                            Console.WriteLine();
                            if (input == "add")
                            {
                                (aClasses, student) = MenuOptions.Add.AClassesToStudent(aClasses, student, false);
                                break;
                            }
                        } while (input != "add" && input != "later");
                    }
                    students.Add(student);
                    Add(students, aClasses, assignments);
                    break;
                case "subj":
                    AClass aClass = MenuOptions.Add.AClass();
                    aClass.SetID(aClasses);
                    Console.WriteLine($"Assigned ID: {aClass.ID}\n");
                    if (students.Any())
                    {
                        string input;
                        do
                        {
                            Console.WriteLine("Type \"add\" to add students now");
                            Console.WriteLine("Type \"later\" to add students later");
                            input = Console.ReadLine();
                            Console.WriteLine();
                            if (input == "add")
                            {
                                (students, aClass) = MenuOptions.Add.StudentsToAClass(students, aClass, false);
                                break;
                            }
                        } while (input != "add" && input != "later");
                    }
                    aClasses.Add(aClass);
                    Add(students, aClasses, assignments);
                    break;
                case "as":
                    if (!aClasses.Any())
                    {
                        Console.WriteLine("Assignments cannont be created without any existing subjects");
                        break;
                    }
                    Assignment assignment = MenuOptions.Add.Assignment(aClasses);
                    assignment.SetID(assignments);
                    Console.WriteLine($"Assigned ID: {assignment.ID}\n");
                    assignments.Add(assignment);

                    AClass selectedClass = Find.AClassByID(aClasses, assignment.AClassID);
                    selectedClass.AddAssignment(assignment);

                    MenuOptions.Add.AssignmentToStudents(students, assignment);
                    Add(students, aClasses, assignments);
                    break;
                case "back":
                    Console.WriteLine();
                    Start(students, aClasses, assignments);
                    break;
                default:
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
                    if (Checks.IfAny(students, "student"))
                    {
                        students = Checks.Student(students);
                    }
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
                    if (Checks.IfAny(students, "students"))
                    {
                        Student selectedStudent = Find.StudentInputID(students);
                        EditMenu.Student(students, aClasses, assignments, selectedStudent);
                    } 
                    else
                    {
                        Edit(students, aClasses, assignments);
                    }
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
            switch (Template("view", false))
            {
                case "stu":
                    if (Checks.IfAny(students, "students"))
                    {
                        Student student = Find.StudentInputID(students);
                        student.WriteInfo();
                    }
                    View(students, aClasses, assignments);
                    break;
                case "subj":
                    if (Checks.IfAny(aClasses, "subjects"))
                    {
                        AClass aClass = Find.AClassInputID(aClasses);
                        aClass.WriteInfo();
                    }
                    View(students, aClasses, assignments);
                    break;
                case "as":
                    if (Checks.IfAny(assignments, "assignments"))
                    {
                        Assignment assignment = Find.AssignmentInputID(assignments);
                        assignment.CalculateAverageGrade(students);
                        assignment.WriteInfo(true);
                    }
                    View(students, aClasses, assignments);
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
                    if (Checks.IfAny(students, "students"))
                    {
                        students = MenuOptions.DeleteData.DeleteList(students, Paths.student, "students");
                    }
                    DeleteData(students, aClasses, assignments);
                    break;
                case "subj":
                    if (Checks.IfAny(aClasses, "subjects"))
                    {
                        aClasses = MenuOptions.DeleteData.DeleteList(aClasses, Paths.aClass, "subjects and assignments");
                        if (!aClasses.Any())
                        {
                            assignments = new List<Assignment>();
                        }
                    }
                    DeleteData(students, aClasses, assignments);
                    break;
                case "as":
                    if (Checks.IfAny(assignments, "assignments"))
                    {
                        assignments = MenuOptions.DeleteData.DeleteList(assignments, Paths.assignment, "assignments");
                    }
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
        static void Save(List<Student> students, List<AClass> aClasses, List<Assignment> assignments)
        {
            if (students.Any())
            {
                string cerialStudents = JsonSerializer.Serialize(students);
                File.WriteAllText(Paths.student, cerialStudents);
            }
            if (aClasses.Any())
            {
                string cerialAClasses = JsonSerializer.Serialize(aClasses);
                File.WriteAllText(Paths.aClass, cerialAClasses);
            }
            if (assignments.Any())
            {
                string cerialAssignments = JsonSerializer.Serialize(assignments);
                File.WriteAllText(Paths.assignment, cerialAssignments);
            }
        }
        static string Template(string menuType, bool delete)
        {
            
            if (delete)
            {
                Console.WriteLine();
                Console.WriteLine($"Type \"stu\" to {menuType} all student data");
                Console.WriteLine($"Type \"subj\" to {menuType} all subject and assignment data");
                Console.WriteLine($"Type \"as\" to {menuType} all assignment data");
            } 
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Type \"stu\" to {menuType} a student");
                Console.WriteLine($"Type \"subj\" to {menuType} a subject");
                Console.WriteLine($"Type \"as\" to {menuType} an assignment");
            }
            Console.WriteLine($"Type \"back\" to go back to the start menu");

            string input = Console.ReadLine().ToLower();
            return input;
        }
    }
}
