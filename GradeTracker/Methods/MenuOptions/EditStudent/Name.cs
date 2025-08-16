using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeTracker.Classes;


namespace GradeTracker.Methods.MenuOptions.EditStudent
{
    internal class Name
    {
        static public List<Student> ChangeStudent(List<Student> students, int studentID, string newStudentName)
        {
            foreach (Student s in students)
            {
                if (s.ID == studentID)
                {
                    s.Name = newStudentName;
                }
            }
            return students;
        }
        static public List<AClass> ChangeStudentInClasses(List<AClass> aClasses, int studentID, string newStudentName)
        {
            foreach (AClass c in aClasses)
            {
                foreach (Student s in c.Students)
                {
                    if (s.ID == studentID)
                    {
                        s.Name = newStudentName;
                    }
                }
            }
            return aClasses;
        }
        static public (List<Student>, List<AClass>) FullStudent(List<Student> students, List<AClass> aClasses, int studentID, string newStudentName)
        {
            students = ChangeStudent(students, studentID, newStudentName);
            aClasses = ChangeStudentInClasses(aClasses, studentID, newStudentName);
            return (students, aClasses);
        }
    }
}
