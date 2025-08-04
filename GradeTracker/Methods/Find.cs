using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Methods
{
    internal class Find
    {
        static public Assignment Assignment(List<Assignment> assignments)
        {
            Console.WriteLine();
            Console.WriteLine("Current list of assignments");
            foreach (Assignment a in assignments)
            {
                Console.WriteLine(a.Name);
            }
            Console.WriteLine("Input name of desired assignment");

            string someName = Console.ReadLine();
            try
            {
                Assignment selectedAssignment = assignments.First(c => c.Name.ToLower() == someName.ToLower());
                return selectedAssignment;
            }
            catch
            {
                Console.WriteLine("Specified assignment not found, please try again");
                Assignment(assignments);
                Assignment selectedAssignment = new Assignment("If you're seeing this, you REALLY fucked up somehow", 0, 0, DateTime.Now, 0);
                return selectedAssignment;
            }
        }
        static public AClass AClass(List<AClass> aClasses)
        {
            Console.WriteLine();
            Console.WriteLine("Current list of subjects");
            foreach (AClass c in aClasses)
            {
                Console.WriteLine(c.Name);
            }
            Console.WriteLine("Input name of desired subject");

            string someName = Console.ReadLine();
            try
            {
                AClass selectedAClass = aClasses.First(c => c.Name.ToLower() == someName.ToLower());
                return selectedAClass;
            } 
            catch
            {
                Console.WriteLine("Specified subject not found, please try again");
                AClass(aClasses);
                AClass selectedAClass = new AClass("If you're seeing this, you REALLY fucked up somehow");
                return selectedAClass;
            }
        }
        static public Student Student(List<Student> students)
        {
            Console.WriteLine();
            Console.WriteLine("Current list of students");
            foreach (Student s in students)
            {
                Console.WriteLine(s.Name);
            }
            Console.WriteLine("Input name of desired student");
            string someName = Console.ReadLine();
            try
            {
                Student selectedStudent = students.First(c => c.Name.ToLower() == someName.ToLower());
                return selectedStudent;
            }
            catch
            {
                Console.WriteLine("Specified student not found, please try again");
                Student(students);
                Student selectedStudent = new Student("If you're seeing this, you REALLY fucked up somehow", 0);
                return selectedStudent;
            }
        }
    }
}
