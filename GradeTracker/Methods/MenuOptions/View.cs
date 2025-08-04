using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Methods.MenuOptions
{
    internal class View
    {
        static public void Student(Student student) 
        {
            Console.WriteLine(student.ToString());
            foreach (AClass c in student.Classes) 
            {
                Console.WriteLine(c.Name);
            }
        }
        static public void AClass(List<AClass> aClasses)
        {
            //TODO
        }
        static public void Assignment(List<Assignment> assignments)
        {
            //TODO
        }
    }
}
