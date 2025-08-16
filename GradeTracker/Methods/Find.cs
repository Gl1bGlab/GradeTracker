using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeTracker.Classes;

namespace GradeTracker.Methods
{
    internal static class Find
    {
        //recently switched to using IDs to find stuff to account for name dupes
        //who knew reducing a person to a single number could be so efficient lmao
        static public Student StudentInputID(List<Student> students)
        {
            foreach (Student s in students)
            {
                Console.WriteLine($"\nName: {s.Name}\nID: {s.ID}");
            }

            int studentID = WriteAnIntDummy();
            Student selectedStudent = null;
            bool validID = false;

            foreach (Student s in students)
            {
                if (s.ID == studentID) { validID = true; break; }
            }

            if (validID) { selectedStudent = StudentByID(students, studentID); }
            if (selectedStudent == null)
            {
                Console.WriteLine("Student ID not found, please try again");
                selectedStudent = StudentInputID(students);
            }
            return selectedStudent;
        }
        static public Student StudentByID(List<Student> students, int studentID)
        {
            Student selectedStudent = students.First(s => s.ID == studentID);
            return selectedStudent;
        }
        static public AClass AClassInputID(List<AClass> aClasses)
        {
            foreach (AClass c in aClasses)
            {
                Console.WriteLine($"\nName: {c.Name}\nID: {c.ID}");
            }

            int aClassID = WriteAnIntDummy();
            AClass selectedAClass = null;
            bool validID = false;

            foreach (AClass c in aClasses)
            {
                if (c.ID == aClassID) { validID = true; }
                if (validID) { break; }
            }
            if (validID) { selectedAClass = AClassByID(aClasses, aClassID); }

            if (selectedAClass == null)
            {
                Console.WriteLine("Subject ID not found, please try again");
                selectedAClass = AClassInputID(aClasses);
            }
            return selectedAClass;
        }
        static public AClass AClassByID(List<AClass> aClasses, int aClassID)
        {
            AClass selectedAClass = aClasses.First(c => c.ID == aClassID);
            return selectedAClass;
        }
        static public Assignment AssignmentInputID(List<Assignment> assignments)
        {
            foreach (Assignment a in assignments)
            {
                Console.WriteLine($"\nName: {a.Name}\nID: {a.ID}");
            }

            int assignmentID = WriteAnIntDummy();
            Assignment selectedAssignment = null;
            bool validID = false;

            foreach (Assignment a in assignments)
            {
                if (a.ID == assignmentID) { validID = true; }
                if (validID) { break; }
            }
            if (validID) { selectedAssignment = AssignmentByID(assignments, assignmentID); }

            if (selectedAssignment == null)
            {
                Console.WriteLine("Subject ID not found, please try again");
                selectedAssignment = AssignmentInputID(assignments);
            }
            return selectedAssignment;
        }
        static public Assignment AssignmentByID(List<Assignment> assignments, int assignmentID)
        {
            Assignment selectedAssignment = assignments.First(a => a.ID == assignmentID);
            return selectedAssignment;
        }
        static public Int16 WriteAnIntDummy()
        {
            string input = Console.ReadLine();
            bool valid = Int16.TryParse(input, out Int16 output);
            if (!valid)
            {
                Console.WriteLine("Invalid value, please try again");
                return WriteAnIntDummy();
            } 
            else
            {
                return output;
            }
        }
    }
}
