using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeTracker.Classes;


namespace GradeTracker.Methods.MenuOptions.EditStudent
{
    internal class Subject
    {
        //having groups of methods in their own classes made it feel nice to delete old methods, like chopping off a tumor
        //i left this one as an example, but i've had a ton of depreciated systems that i got rid of entirely
        public static (Student, AClass) AddAClass(Student selectedStudent, AClass selectedAClasses)
        {
            selectedStudent.AddAClass(selectedAClasses);
            selectedAClasses.AddStudent(selectedStudent);
            return (selectedStudent, selectedAClasses);
        }
        public static (Student, AClass) RemoveAClass(Student selectedStudent, AClass selectedAClasses)
        {
            selectedStudent.RemoveAClass(selectedAClasses);
            selectedAClasses.RemoveStudent(selectedStudent);
            return (selectedStudent, selectedAClasses);
        }
    }
}
