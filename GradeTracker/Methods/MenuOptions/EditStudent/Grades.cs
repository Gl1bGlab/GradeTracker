using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeTracker.Classes;

namespace GradeTracker.Methods.MenuOptions.EditStudent
{
    internal class Grades
    {
        //ironically, tracking grades is probably the biggest thing this project is missing
        //it's implemented a little bit, but it's still really rough so don't be suprised if it breaks in some weird way
        public static List<Student> UngradedAssignment(List<Student> students, Student selectedStudent)
        {
            Student student = Find.StudentByID(students, selectedStudent.ID);
            List<Assignment> ungradedAssignments = new List<Assignment>();
            bool ungradedAssignmentsInAClass;
            foreach (AClass c in student.AClasses)
            {
                ungradedAssignmentsInAClass = false;
                Console.WriteLine("\n" + c.Name);
                if (!c.Assignments.Any())
                {
                    Console.WriteLine("No assignments found\n");
                    continue;
                }
                foreach (Assignment a in c.Assignments)
                {
                    if (!a.IsGraded)
                    {
                        ungradedAssignments.Add(a);
                        ungradedAssignmentsInAClass = true;
                        a.WriteInfo(false);
                        Console.WriteLine();
                    }
                }
                if (!ungradedAssignmentsInAClass)
                {
                    Console.WriteLine("No ungraded assignments found\n");
                }
            }
            if (!ungradedAssignments.Any())
            {
                Console.WriteLine($"No ungraded assignments found for {selectedStudent.Name}");
            } 
            else
            {
                Console.WriteLine("Select assignment ID to grade");
                int assignmentID = Find.WriteAnIntDummy();
                Console.WriteLine($"Input desired grade");
                student.GradeAssignment(assignmentID);
                student.WriteInfo();
            }
            return students;
        }
    }
}
