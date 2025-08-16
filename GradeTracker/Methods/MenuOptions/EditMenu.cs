using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeTracker.Methods.MenuOptions.EditStudent;
using GradeTracker.Classes;

namespace GradeTracker.Methods.MenuOptions
{
    internal static class EditMenu
    {
        //i always start with students when i'm making a new menu, and i usually just copy pase that one twice cuz i didn't figure out how to make generic methods
        //the edit menu is probably a case where a generic menu wouldn't work even if i knew how to make one
        static public void Student(List<Student> students, List<AClass> aClasses, List<Assignment> assignments, Student selectedStudent)
        {
            int studentID = selectedStudent.ID;

            Console.WriteLine($"\nWrite \"name\" to edit {selectedStudent.Name}'s name");
            Console.WriteLine($"Write \"age\" to edit {selectedStudent.Name}'s age");
            Console.WriteLine($"Write \"subj\" to edit {selectedStudent.Name}'s subjects");
            Console.WriteLine($"Write \"grd\" to edit {selectedStudent.Name}'s grades");
            Console.WriteLine("Write \"back\" to go back");

            string input = Console.ReadLine();

            switch (input) {
                case "name":
                    Console.WriteLine("Write new name");
                    string newName = Console.ReadLine();
                    (students, aClasses) = Name.FullStudent(students, aClasses, studentID, newName);
                    Student(students, aClasses, assignments, selectedStudent);
                    break;
                case "age":
                    Console.WriteLine("Write new age");
                    int newAge = Find.WriteAnIntDummy();
                    (students, aClasses) = Age.FullStudent(students, aClasses, studentID, newAge);
                    Student(students, aClasses, assignments, selectedStudent);
                    break;
                case "subj":
                    Console.WriteLine($"Write \"add\" to add {selectedStudent.Name} to a subject");
                    Console.WriteLine($"Write \"rem\" to remove {selectedStudent.Name} from a subject");
                    break;
                case "grd":
                    students = Grades.UngradedAssignment(students, selectedStudent);
                    Student(students, aClasses, assignments, selectedStudent);
                    break;
                case "back":
                    Menu.Edit(students, aClasses, assignments);
                    break;
                default:
                    Student(students, aClasses, assignments, selectedStudent);
                    break;
            }
        }

    }
}
