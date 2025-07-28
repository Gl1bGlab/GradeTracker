using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker
{
    public class Student
    {
        private string Name { get; set; }
        private int Age { get; set; }
        private List<AClass> Classes { get; set; }
        public Student(string name,  int age)
        {
            this.Name = name.ToLower();
            this.Age = age;
        }
        public override string ToString()
        {
            return this.Name + ", age " + this.Age + " years";
        }
    }
}
