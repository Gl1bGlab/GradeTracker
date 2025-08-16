using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeTracker.Classes;

namespace GradeTracker.Methods.MenuOptions.EditStudent
{
    internal class Age
    {
        //i thought about combining age and name into the same class, but i had already made both so meh
        //inefficienct design is just a sign of personality or something like that
        static public List<Student> ChangeStudent(List<Student> students, int studentID, int newStudentAge)
        {
            foreach (Student s in students)
            {
                if (s.ID == studentID)
                {
                    s.Age = newStudentAge;
                }
            }
            return students;
        }
        static public List<AClass> ChangeStudentInClasses(List<AClass> aClasses, int studentID, int newStudentAge)
        {
            foreach (AClass c in aClasses)
            {
                foreach (Student s in c.Students)
                {
                    if (s.ID == studentID)
                    {
                        s.Age = newStudentAge;
                    }
                }
            }
            return aClasses;
        }
        static public (List<Student>, List<AClass>) FullStudent(List<Student> students, List<AClass> aClasses, int studentID, int newStudentAge)
        {
            students = ChangeStudent(students, studentID, newStudentAge);
            aClasses = ChangeStudentInClasses(aClasses, studentID, newStudentAge);
            return (students, aClasses);
        }
    }
}
